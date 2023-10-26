﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AssetManager.Model;

public partial class Asset
{
    public int AssetId { get; set; }

    [DisplayName("Asset Type")]
    public string AssetType { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    [DisplayName("Serial Number")]
    public string SerialNumber { get; set; }

    [DisplayName("IMEI Number 1")]
    public string Imeinumber1 { get; set; }

    [DisplayName("IMEI Number 2")]
    public string Imeinumber2 { get; set; }

    public string Accessories { get; set; }

    public string Capacity { get; set; }

    [DisplayName("Asset Status")]
    public string AssetStatus { get; set; }

    [DisplayName("Purchase Date")]
    [DataType(DataType.Date)]
    public DateTime? PurchaseDate { get; set; }

    [DisplayName("Warranty Expiry Date")]
    [DataType(DataType.Date)]
    public DateTime? WarrantyExpiryDate { get; set; }

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
}