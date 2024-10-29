using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.DTOs
{
    public class GroupWithListRoomsDto
    {
        public string groupId {  get; set; }

        public List<Room> rooms { get; set; }
    }
}
