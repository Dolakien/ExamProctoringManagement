using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Exceptions
{
    public class ReportNotFoundException : NotFoundException
    {
        public ReportNotFoundException(string id) : base($"This report with id: {id} was not found")
        {
        }
    }
}
