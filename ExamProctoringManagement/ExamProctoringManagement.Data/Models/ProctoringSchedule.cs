﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ExamProctoringManagement.Data.Models;

public partial class ProctoringSchedule
{
    public string ScheduleId { get; set; }

    public string UserId { get; set; }

    public string ProctorType { get; set; }

    public string SlotReferenceId { get; set; }

    public bool? Status { get; set; }

    public bool? IsFinished { get; set; }
    public int? Count { get; set; }

    public virtual SlotReference SlotReference { get; set; }

    public virtual User User { get; set; }
}