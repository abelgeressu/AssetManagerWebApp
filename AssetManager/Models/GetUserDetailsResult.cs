﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManager.Model
{
    public partial class GetUserDetailsResult
    {
        public int? ContractID { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? AssignmentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        [Column("Last Change Date")]
        public DateTime? LastChangeDate { get; set; }
        [Column("Change Description")]
        public string ChangeDescription { get; set; }
    }
}
