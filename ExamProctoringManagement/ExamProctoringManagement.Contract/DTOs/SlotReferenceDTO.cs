﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.DTOs
{
    public class SlotReferenceDTO
    {
        public string SlotReferenceId { get; set; }

        public string SlotId { get; set; }

        public string RoomId { get; set; }

        public string GroupId { get; set; }

    }
}