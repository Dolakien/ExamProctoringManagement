﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ExamProctoringManagement.Data.Models;

public partial class Report
{
    public string ReportId { get; set; }

    public string UserId { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public float? TotalHours { get; set; }

    public decimal? UnitPerHour { get; set; }

    public decimal? TotalAmount { get; set; }

    public bool? IsPaid { get; set; }

    public virtual User User { get; set; }
}