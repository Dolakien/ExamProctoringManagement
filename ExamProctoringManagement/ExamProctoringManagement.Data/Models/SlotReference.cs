﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ExamProctoringManagement.Data.Models;

public partial class SlotReference
{
    public string SlotReferenceId { get; set; }

    public string SlotId { get; set; }

    public string RoomId { get; set; }

    public string GroupId { get; set; }

    public virtual Group Group { get; set; }

    public virtual ICollection<ProctoringSchedule> ProctoringSchedules { get; set; } = new List<ProctoringSchedule>();

    public virtual Room Room { get; set; }

    public virtual Slot Slot { get; set; }

    public virtual ICollection<SlotRoomSubject> SlotRoomSubjects { get; set; } = new List<SlotRoomSubject>();
}