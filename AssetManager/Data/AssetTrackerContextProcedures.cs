﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using AssetManager.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace AssetManager.Data
{
    public partial class AssetTrackerContext
    {
        private IAssetTrackerContextProcedures _procedures;

        public virtual IAssetTrackerContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new AssetTrackerContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IAssetTrackerContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetContractDetailsResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<GetPhoneDetailsResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<GetUserDetailsResult>().HasNoKey().ToView(null);
        }
    }

    public partial class AssetTrackerContextProcedures : IAssetTrackerContextProcedures
    {
        private readonly AssetTrackerContext _context;

        public AssetTrackerContextProcedures(AssetTrackerContext context)
        {
            _context = context;
        }

        public virtual async Task<List<GetContractDetailsResult>> GetContractDetailsAsync(int? ContractID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "ContractID",
                    Value = ContractID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<GetContractDetailsResult>("EXEC @returnValue = [dbo].[GetContractDetails] @ContractID", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<GetPhoneDetailsResult>> GetPhoneDetailsAsync(int? AssetID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "AssetID",
                    Value = AssetID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<GetPhoneDetailsResult>("EXEC @returnValue = [dbo].[GetPhoneDetails] @AssetID", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<GetUserDetailsResult>> GetUserDetailsAsync(int? UserID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "UserID",
                    Value = UserID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<GetUserDetailsResult>("EXEC @returnValue = [dbo].[GetUserDetails] @UserID", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
