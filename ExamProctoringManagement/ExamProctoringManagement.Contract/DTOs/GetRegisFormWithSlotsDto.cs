﻿using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.DTOs
{
    public class GetRegisFormWithSlotsDto
    {
        public string FormId { get; set; }
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public List<Slot> Slots { get; set; }
    }
}
