﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PocEconomicsAPI.Models;

[Table("Customer")]
public partial class Customer
{
    [Required]
    [StringLength(50)]
    public string License { get; set; }

    [Key]
    public int customerNo { get; set; }

    public int? Type { get; set; }

    [Required]
    [StringLength(100)]
    public string CompanyName { get; set; }

    [StringLength(50)]
    public string Name2 { get; set; }

    [Required]
    [StringLength(100)]
    public string Address { get; set; }

    [StringLength(100)]
    public string Address2 { get; set; }

    [Required]
    [StringLength(20)]
    public string Postcode { get; set; }

    [Required]
    [StringLength(30)]
    public string City { get; set; }

    [StringLength(10)]
    public string CountryCode { get; set; }

    [StringLength(50)]
    public string ContactName { get; set; }

    [Required]
    [StringLength(30)]
    public string ContactEmail { get; set; }

    [StringLength(30)]
    public string ContactPhone { get; set; }

    [StringLength(30)]
    public string GLN { get; set; }

    [StringLength(30)]
    public string Endpoint { get; set; }

    [StringLength(13)]
    public string Vat { get; set; }

    [StringLength(30)]
    public string Region { get; set; }

    [InverseProperty("customerNoNavigation")]
    public virtual EntrysFeild EntrysFeild { get; set; }
}