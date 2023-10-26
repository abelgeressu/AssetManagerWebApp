using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssetManager.Data;
using AssetManager.Model;

namespace AssetManager.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly AssetTrackerContext _context;

        public AssignmentsController(AssetTrackerContext context)
        {
            _context = context;
        }

        // GET: Assignments
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["ModelSortParam"] = string.IsNullOrEmpty(sortOrder) ? "model_desc" : "";
            ViewData["BrandSortParam"] = sortOrder == "brand_asc" ? "brand_desc" : "brand_asc";
            ViewData["StartDateSortParam"] = sortOrder == "startdate_asc" ? "startdate_desc" : "startdate_asc";
            ViewData["EndDateSortParam"] = sortOrder == "enddate_asc" ? "enddate_desc" : "enddate_asc";

            IQueryable<Assignment> assignments = _context.Assignments
                .Include(a => a.Asset)
                .Include(a => a.ChangeLog)
                .Include(a => a.Contract)
                .Include(a => a.Employee);

            switch (sortOrder)
            {
                case "model_desc":
                    assignments = assignments.OrderByDescending(a => a.Asset.Model);
                    break;
                case "brand_asc":
                    assignments = assignments.OrderBy(a => a.Asset.Brand);
                    break;
                case "brand_desc":
                    assignments = assignments.OrderByDescending(a => a.Asset.Brand);
                    break;
                case "startdate_asc":
                    assignments = assignments.OrderBy(a => a.AssignmentDate);
                    break;
                case "startdate_desc":
                    assignments = assignments.OrderByDescending(a => a.AssignmentDate);
                    break;
                case "enddate_asc":
                    assignments = assignments.OrderBy(a => a.ReturnDate);
                    break;
                case "enddate_desc":
                    assignments = assignments.OrderByDescending(a => a.ReturnDate);
                    break;
                default:
                    assignments = assignments.OrderBy(a => a.Asset.Model);
                    break;
            }

            return View(await assignments.ToListAsync());
        }



        /* // GET: Assignments
         public async Task<IActionResult> Index()
         {
             var assetTrackerContext = _context.Assignments.Include(a => a.Asset).Include(a => a.ChangeLog).Include(a => a.Contract).Include(a => a.Employee);
             return View(await assetTrackerContext.ToListAsync());
         }*/

        // GET: Assignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Assignments == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .Include(a => a.Asset)
                .Include(a => a.ChangeLog)
                .Include(a => a.Contract)
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }


            // GET: Assignments/Create
            public IActionResult Create()
            {

             
            // Determine the next available AssignmentId
                 int? maxId = _context.Assignments.Max(a => a.AssignmentId);
                int newId = (maxId ?? 0) + 1;

                // Check if newId is taken and find the next available ID
                while (_context.Assignments.Any(a => a.AssignmentId == newId))
                {
                    newId++;
                }

                // Send the available AssignmentId to the View
                ViewData["AvailableAssignmentId"] = newId;

                // Get all employees, assets, and contracts
                var allEmployees = _context.Employees.ToList();
                var allAssets = _context.Assets.ToList();
                var allContracts = _context.Contracts.ToList();

                // Concatenate Employee's FirstName and LastName
                var employeeNames = allEmployees.Select(e => new
                {
                    EmployeeId = e.EmployeeId,
                    FullName = $"{e.FirstName} {e.LastName}"
                });

                // Concatenate Asset's Brand, Model, and SerialNumber
                var assetDetails = allAssets.Select(a => new
                {
                    AssetId = a.AssetId,
                    Description = $"{a.Brand} - {a.Model} (S/N: {a.SerialNumber})"
                });

                // Concatenate Contract's Provider and PhoneNumber
                var contractDetails = allContracts.Select(c => new
                {
                    ContractId = c.ContractId,
                    Details = $"{c.Provider} - {c.PhoneNumber}"
                });

                // Populate the selection lists
                ViewData["AssetId"] = new SelectList(assetDetails, "AssetId", "Description");
                ViewData["ChangeLogId"] = new SelectList(_context.ChangeLogs, "ChangeLogId", "ChangeLogId");
                ViewData["ContractId"] = new SelectList(contractDetails, "ContractId", "Details");
                ViewData["EmployeeId"] = new SelectList(employeeNames, "EmployeeId", "FullName");

                return View();
            }



        /*     public IActionResult Create()
             {
                 // Get all employees and assets
                 var allEmployees = _context.Employees.ToList();
                 var allAssets = _context.Assets.ToList();

                 // Populate the selection lists with LastName (for employees) and Model (for assets)
                 ViewData["AssetId"] = new SelectList(allAssets, "AssetId", "Model");
                 ViewData["ChangeLogId"] = new SelectList(_context.ChangeLogs, "ChangeLogId", "ChangeLogId");
                 ViewData["ContractId"] = new SelectList(_context.Contracts, "ContractId", "ContractId");
                 ViewData["EmployeeId"] = new SelectList(allEmployees, "EmployeeId", "LastName");

                 return View();
             }
     */

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignmentId,EmployeeId,AssetId,ContractId,AssignmentDate,ReturnDate,Status,ChangeLogId")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetId"] = new SelectList(_context.Assets, "AssetId", "AssetId", assignment.AssetId);
            ViewData["ChangeLogId"] = new SelectList(_context.ChangeLogs, "ChangeLogId", "ChangeLogId", assignment.ChangeLogId);
            ViewData["ContractId"] = new SelectList(_context.Contracts, "ContractId", "ContractId", assignment.ContractId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", assignment.EmployeeId);
            return View(assignment);
        }

        // GET: Assignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Assignments == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            ViewData["AssetId"] = new SelectList(_context.Assets, "AssetId", "AssetId", assignment.AssetId);
            ViewData["ChangeLogId"] = new SelectList(_context.ChangeLogs, "ChangeLogId", "ChangeLogId", assignment.ChangeLogId);
            ViewData["ContractId"] = new SelectList(_context.Contracts, "ContractId", "ContractId", assignment.ContractId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", assignment.EmployeeId);
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignmentId,EmployeeId,AssetId,ContractId,AssignmentDate,ReturnDate,Status,ChangeLogId")] Assignment assignment)
        {
            if (id != assignment.AssignmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentExists(assignment.AssignmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetId"] = new SelectList(_context.Assets, "AssetId", "AssetId", assignment.AssetId);
            ViewData["ChangeLogId"] = new SelectList(_context.ChangeLogs, "ChangeLogId", "ChangeLogId", assignment.ChangeLogId);
            ViewData["ContractId"] = new SelectList(_context.Contracts, "ContractId", "ContractId", assignment.ContractId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", assignment.EmployeeId);
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Assignments == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .Include(a => a.Asset)
                .Include(a => a.ChangeLog)
                .Include(a => a.Contract)
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Assignments == null)
            {
                return Problem("Entity set 'AssetTrackerContext.Assignments'  is null.");
            }
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignmentExists(int id)
        {
          return (_context.Assignments?.Any(e => e.AssignmentId == id)).GetValueOrDefault();
        }
    }
}
