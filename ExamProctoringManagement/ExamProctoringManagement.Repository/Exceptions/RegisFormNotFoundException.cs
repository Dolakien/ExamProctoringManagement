using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Exceptions
{
    public class RegisFormNotFoundException : NotFoundException
    {
        public RegisFormNotFoundException(string id) : base($"This registration form with id: {id} was not found")
        {
        }
    }
}
