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
    public partial interface IAssetTrackerContextProcedures
    {
        Task<List<GetContractDetailsResult>> GetContractDetailsAsync(int? ContractID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetPhoneDetailsResult>> GetPhoneDetailsAsync(int? AssetID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetUserDetailsResult>> GetUserDetailsAsync(int? UserID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
