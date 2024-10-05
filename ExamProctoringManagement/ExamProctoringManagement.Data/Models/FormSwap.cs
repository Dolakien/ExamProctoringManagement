﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ExamProctoringManagement.Data.Models;

public partial class FormSwap
{
    public string FormId { get; set; }

    public string UserId { get; set; }

    public bool? Type { get; set; }

    public bool? IsAllowed { get; set; }

    public string FromSlot { get; set; }

    public string ToSlot { get; set; }

    public bool? Status { get; set; }

    public virtual Slot FromSlotNavigation { get; set; }

    public virtual Slot ToSlotNavigation { get; set; }

    public virtual User User { get; set; }
}