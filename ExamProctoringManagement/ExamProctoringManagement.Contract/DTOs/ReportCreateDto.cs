﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.DTOs
{
    public class ReportCreateDto
    {
        public string ReportId { get; set; }

        public string UserId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public decimal? UnitPerHour { get; set; }
    }
}
