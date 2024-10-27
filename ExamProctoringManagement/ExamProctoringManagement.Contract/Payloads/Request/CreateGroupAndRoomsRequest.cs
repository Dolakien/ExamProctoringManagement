using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.Payloads.Request
{
    public class CreateGroupAndRoomsRequest
    {
        public Group Group { get; set; }
        public string GroupRoomId { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
