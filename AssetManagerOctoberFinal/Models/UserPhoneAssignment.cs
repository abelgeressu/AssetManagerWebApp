﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AssetManagerOctoberFinal.Model;

public partial class UserPhoneAssignment
{
    public int UserId { get; set; }

    public string Username { get; set; }

    public int? AssetId { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public DateTime? AssignmentDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public DateTime? LastChangeDate { get; set; }

    public string ChangeDescription { get; set; }
}