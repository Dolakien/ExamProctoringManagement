﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ExamProctoringManagement.Data.Models;

public partial class RegistrationForm
{
    public string FormId { get; set; }

    public string UserId { get; set; }

    public DateTime? CreateDate { get; set; }

    public bool? Status { get; set; }
    public string ScheduleID { get; set; }

    public virtual ICollection<FormSlot> FormSlots { get; set; } = new List<FormSlot>();

    public virtual User User { get; set; }
}