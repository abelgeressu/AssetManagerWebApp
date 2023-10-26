﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using AssetManagerOctoberFinal.Model;
using Microsoft.EntityFrameworkCore;

namespace AssetManagerOctoberFinal.Data;

public partial class AssetTrackerContext : DbContext
{
    public AssetTrackerContext(DbContextOptions<AssetTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<ChangeLog> ChangeLogs { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<ContractOverview> ContractOverviews { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EurssMobileAssetCsv> EurssMobileAssetCsvs { get; set; }

    public virtual DbSet<MobilePhoneOverview> MobilePhoneOverviews { get; set; }

    public virtual DbSet<UserContractAssignment> UserContractAssignments { get; set; }

    public virtual DbSet<UserPhoneAssignment> UserPhoneAssignments { get; set; }

    public virtual DbSet<UserTable> UserTables { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset>(entity =>
        {
            entity.HasKey(e => e.AssetId).HasName("PK__Asset__43492372409B085E");

            entity.ToTable("Asset");

            entity.Property(e => e.AssetId)
                .ValueGeneratedNever()
                .HasColumnName("AssetID");
            entity.Property(e => e.AssetStatus).HasMaxLength(50);
            entity.Property(e => e.AssetType).HasMaxLength(50);
            entity.Property(e => e.Brand).HasMaxLength(50);
            entity.Property(e => e.Capacity).HasMaxLength(50);
            entity.Property(e => e.Imeinumber1)
                .HasMaxLength(50)
                .HasColumnName("IMEINumber1");
            entity.Property(e => e.Imeinumber2)
                .HasMaxLength(50)
                .HasColumnName("IMEINumber2");
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.PurchaseDate).HasColumnType("date");
            entity.Property(e => e.SerialNumber).HasMaxLength(50);
            entity.Property(e => e.WarrantyExpiryDate).HasColumnType("date");
        });

        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__Assignme__32499E5736AF9293");

            entity.ToTable("Assignment");

            entity.Property(e => e.AssignmentId)
                .ValueGeneratedNever()
                .HasColumnName("AssignmentID");
            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssignmentDate).HasColumnType("date");
            entity.Property(e => e.ChangeLogId).HasColumnName("ChangeLogID");
            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.ReturnDate).HasColumnType("date");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Asset).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK__Assignmen__Asset__4316F928");

            entity.HasOne(d => d.ChangeLog).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.ChangeLogId)
                .HasConstraintName("FK__Assignmen__Chang__44FF419A");

            entity.HasOne(d => d.Contract).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK__Assignmen__Contr__440B1D61");

            entity.HasOne(d => d.Employee).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Assignmen__Emplo__4222D4EF");
        });

        modelBuilder.Entity<ChangeLog>(entity =>
        {
            entity.HasKey(e => e.ChangeLogId).HasName("PK__ChangeLo__6AD2E8E7BDFA7953");

            entity.ToTable("ChangeLog");

            entity.Property(e => e.ChangeLogId)
                .ValueGeneratedNever()
                .HasColumnName("ChangeLogID");
            entity.Property(e => e.ChangeDate).HasColumnType("date");
            entity.Property(e => e.ChangeType).HasMaxLength(50);

            entity.HasOne(d => d.ChangedByNavigation).WithMany(p => p.ChangeLogs)
                .HasForeignKey(d => d.ChangedBy)
                .HasConstraintName("FK__ChangeLog__Chang__3F466844");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PK__Contract__C90D3409B4B8BDF1");

            entity.ToTable("Contract");

            entity.Property(e => e.ContractId)
                .ValueGeneratedNever()
                .HasColumnName("ContractID");
            entity.Property(e => e.ContractEndDate).HasColumnType("date");
            entity.Property(e => e.ContractStartDate).HasColumnType("date");
            entity.Property(e => e.DataLimit).HasMaxLength(50);
            entity.Property(e => e.MonthlyCost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.Pinnumber)
                .HasMaxLength(20)
                .HasColumnName("PINNumber");
            entity.Property(e => e.Provider).HasMaxLength(50);
            entity.Property(e => e.Puknumber)
                .HasMaxLength(20)
                .HasColumnName("PUKNumber");
        });

        modelBuilder.Entity<ContractOverview>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ContractOverview");

            entity.Property(e => e.ActivatedOn)
                .HasColumnType("date")
                .HasColumnName("Activated On");
            entity.Property(e => e.ActiveUntil)
                .HasColumnType("date")
                .HasColumnName("Active Until");
            entity.Property(e => e.AssignedOn)
                .HasColumnType("date")
                .HasColumnName("Assigned On");
            entity.Property(e => e.AssignedTo)
                .HasMaxLength(101)
                .HasColumnName("Assigned To");
            entity.Property(e => e.ChangeDescription).HasColumnName("Change Description");
            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.ContractStatus)
                .IsRequired()
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Contract Status");
            entity.Property(e => e.LastChangeDate)
                .HasColumnType("date")
                .HasColumnName("Last Change Date");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF191DC3FBA");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.GlobalId)
                .HasMaxLength(50)
                .HasColumnName("GlobalID");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Position).HasMaxLength(50);
        });

        modelBuilder.Entity<EurssMobileAssetCsv>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("EURSS_Mobile_Asset_CSV");

            entity.Property(e => e.Accessories).HasMaxLength(100);
            entity.Property(e => e.AssetBrand)
                .HasMaxLength(50)
                .HasColumnName("Asset_Brand");
            entity.Property(e => e.AssetCapacity)
                .HasMaxLength(50)
                .HasColumnName("Asset_Capacity");
            entity.Property(e => e.AssetCondition)
                .HasMaxLength(50)
                .HasColumnName("Asset_Condition");
            entity.Property(e => e.AssetCost)
                .HasMaxLength(1)
                .HasColumnName("Asset_Cost");
            entity.Property(e => e.AssetDueDate2y)
                .HasColumnType("date")
                .HasColumnName("Asset_Due_Date_2y");
            entity.Property(e => e.AssetImei1Number).HasColumnName("Asset_IMEI_1_Number");
            entity.Property(e => e.AssetImei2Number)
                .HasMaxLength(50)
                .HasColumnName("Asset_IMEI_2_Number");
            entity.Property(e => e.AssetModelName)
                .HasMaxLength(50)
                .HasColumnName("Asset_Model_Name");
            entity.Property(e => e.AssetModelNumber)
                .HasMaxLength(50)
                .HasColumnName("Asset_Model_Number");
            entity.Property(e => e.AssetSerialNumber)
                .HasMaxLength(50)
                .HasColumnName("Asset_Serial_Number");
            entity.Property(e => e.AssetSerialNumber2)
                .HasMaxLength(50)
                .HasColumnName("Asset_Serial_Number2");
            entity.Property(e => e.AssetStatus)
                .HasMaxLength(50)
                .HasColumnName("Asset_Status");
            entity.Property(e => e.AssetType)
                .HasMaxLength(50)
                .HasColumnName("Asset_Type");
            entity.Property(e => e.Assignee).HasMaxLength(50);
            entity.Property(e => e.AssigneeCheckIn)
                .HasColumnType("date")
                .HasColumnName("Assignee_Check_In");
            entity.Property(e => e.AssigneeCheckOut)
                .HasColumnType("date")
                .HasColumnName("Assignee_Check_Out");
            entity.Property(e => e.AssigneeGlobalId)
                .HasMaxLength(50)
                .HasColumnName("Assignee_Global_ID");
            entity.Property(e => e.AssigneeNotes)
                .HasMaxLength(50)
                .HasColumnName("Assignee_Notes");
            entity.Property(e => e.AssigneePhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("Assignee_Phone_Number");
            entity.Property(e => e.DateConditionLastEvaluated)
                .HasColumnType("date")
                .HasColumnName("Date_Condition_Last_Evaluated");
            entity.Property(e => e.DateOfPurchase)
                .HasMaxLength(1)
                .HasColumnName("Date_Of_Purchase");
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.DepartmentFinancialCode)
                .HasMaxLength(1)
                .HasColumnName("Department_Financial_Code");
            entity.Property(e => e.ExpectedDaysOfUse).HasColumnName("Expected_Days_Of_Use");
            entity.Property(e => e.FormSignedAndFiled)
                .HasMaxLength(1)
                .HasColumnName("Form_signed_and_filed");
            entity.Property(e => e.GivenBy)
                .HasMaxLength(50)
                .HasColumnName("Given_By");
            entity.Property(e => e.GsmContractEndDate)
                .HasMaxLength(1)
                .HasColumnName("GSM_Contract_End_Date");
            entity.Property(e => e.GsmContractStartingDate)
                .HasMaxLength(1)
                .HasColumnName("GSM_Contract_Starting_Date");
            entity.Property(e => e.GsmPackage)
                .HasMaxLength(1)
                .HasColumnName("GSM_Package");
            entity.Property(e => e.LastMaintenanceCheck)
                .HasMaxLength(1)
                .HasColumnName("Last_Maintenance_Check");
            entity.Property(e => e.NextMaintenanceCheck)
                .HasMaxLength(1)
                .HasColumnName("Next_Maintenance_Check");
            entity.Property(e => e.Pin)
                .HasMaxLength(50)
                .HasColumnName("PIN");
            entity.Property(e => e.Pin2)
                .HasMaxLength(50)
                .HasColumnName("PIN_2");
            entity.Property(e => e.Puk)
                .HasMaxLength(50)
                .HasColumnName("PUK");
            entity.Property(e => e.Puk2)
                .HasMaxLength(50)
                .HasColumnName("PUK_2");
            entity.Property(e => e.ServiceDeliveryDate)
                .HasMaxLength(1)
                .HasColumnName("Service_Delivery_Date");
            entity.Property(e => e.ServiceReturnDate)
                .HasMaxLength(1)
                .HasColumnName("Service_Return_Date");
            entity.Property(e => e.ServiceTrackingNumber)
                .HasMaxLength(1)
                .HasColumnName("Service_Tracking_Number");
            entity.Property(e => e.Spirit)
                .HasMaxLength(50)
                .HasColumnName("SPIRIT");
            entity.Property(e => e.VendorContactInfo)
                .HasMaxLength(1)
                .HasColumnName("Vendor_Contact_Info");
            entity.Property(e => e.VendorName)
                .HasMaxLength(1)
                .HasColumnName("Vendor_Name");
            entity.Property(e => e.WarrantyExpirationDate)
                .HasMaxLength(1)
                .HasColumnName("Warranty_Expiration_Date");
        });

        modelBuilder.Entity<MobilePhoneOverview>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("MobilePhoneOverview");

            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssetStatus).HasMaxLength(50);
            entity.Property(e => e.Brand).HasMaxLength(50);
            entity.Property(e => e.Capacity).HasMaxLength(50);
            entity.Property(e => e.ChangeDescription).HasColumnName("Change Description");
            entity.Property(e => e.HandoutDate)
                .HasColumnType("date")
                .HasColumnName("Handout Date");
            entity.Property(e => e.HandoutTo)
                .HasMaxLength(101)
                .HasColumnName("Handout To");
            entity.Property(e => e.Imeinumber1)
                .HasMaxLength(50)
                .HasColumnName("IMEINumber1");
            entity.Property(e => e.Imeinumber2)
                .HasMaxLength(50)
                .HasColumnName("IMEINumber2");
            entity.Property(e => e.LastChangeDate)
                .HasColumnType("date")
                .HasColumnName("Last Change Date");
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.PurchaseDate).HasColumnType("date");
            entity.Property(e => e.SerialNumber).HasMaxLength(50);
            entity.Property(e => e.WarrantyExpiryDate).HasColumnType("date");
        });

        modelBuilder.Entity<UserContractAssignment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("UserContractAssignment");

            entity.Property(e => e.AssignmentDate).HasColumnType("date");
            entity.Property(e => e.ChangeDescription).HasColumnName("Change Description");
            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.LastChangeDate)
                .HasColumnType("date")
                .HasColumnName("Last Change Date");
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.ReturnDate).HasColumnType("date");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<UserPhoneAssignment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("UserPhoneAssignment");

            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.AssignmentDate).HasColumnType("date");
            entity.Property(e => e.Brand).HasMaxLength(50);
            entity.Property(e => e.ChangeDescription).HasColumnName("Change Description");
            entity.Property(e => e.LastChangeDate)
                .HasColumnType("date")
                .HasColumnName("Last Change Date");
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.ReturnDate).HasColumnType("date");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<UserTable>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserTabl__1788CCAC48C9EB90");

            entity.ToTable("UserTable");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.GlobalId)
                .HasMaxLength(50)
                .HasColumnName("GlobalID");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}