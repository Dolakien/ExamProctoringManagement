using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Exceptions
{
    public class SemesterNotFoundException : NotFoundException
    {
        public SemesterNotFoundException(string id) : base($"This semester with id: {id} was not found")
        {
        }
    }
}
