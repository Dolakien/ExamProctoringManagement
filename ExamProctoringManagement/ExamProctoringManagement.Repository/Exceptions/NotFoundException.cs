using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Exceptions
{
    public class NotFoundException : EntityException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
