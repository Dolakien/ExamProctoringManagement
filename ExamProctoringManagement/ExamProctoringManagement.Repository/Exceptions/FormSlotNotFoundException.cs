using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Exceptions
{
    public class FormSlotNotFoundException : NotFoundException
    {
        public FormSlotNotFoundException(string id) : base($"This FormSlot with id: {id} was not found")
        {
        }
    }
}
