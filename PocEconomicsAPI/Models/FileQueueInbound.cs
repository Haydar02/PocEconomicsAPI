﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PocEconomicsAPI.Models;

[PrimaryKey("Id", "TransportCode", "SubEntryNo", "ProfileId")]
[Table("FileQueueInbound")]
public partial class FileQueueInbound
{
    [Key]
    public long Id { get; set; }

    [Key]
    [StringLength(100)]
    public string TransportCode { get; set; }

    [Key]
    public int SubEntryNo { get; set; }

    [Key]
    public int ProfileId { get; set; }

    public int? Status { get; set; }

    [StringLength(10)]
    public string DocumentType { get; set; }

    [StringLength(100)]
    public string DocumentNo { get; set; }

    [StringLength(100)]
    public string StatusDescription { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedOn { get; set; }

    public long? FileSize { get; set; }

    [StringLength(50)]
    public string FileFormat { get; set; }

    [StringLength(50)]
    public string IdentifiedFormat { get; set; }

    [StringLength(50)]
    public string Codepage { get; set; }

    [StringLength(50)]
    public string ReceiverLicense { get; set; }

    [StringLength(100)]
    public string ReceiverName { get; set; }

    [StringLength(50)]
    public string SenderLicense { get; set; }

    [StringLength(100)]
    public string SenderName { get; set; }

    public string DocumentPath { get; set; }

    public bool? Error { get; set; }
}