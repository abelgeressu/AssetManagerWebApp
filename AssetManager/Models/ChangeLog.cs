﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetManager.Model;

public partial class ChangeLog
{
    public int ChangeLogId { get; set; }

    public string ChangeType { get; set; }

    [DataType(DataType.Date)]
    public DateTime? ChangeDate { get; set; }

    public int? ChangedBy { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual UserTable ChangedByNavigation { get; set; }
}