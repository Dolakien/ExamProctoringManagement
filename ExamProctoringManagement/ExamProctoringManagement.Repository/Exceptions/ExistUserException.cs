using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Exceptions
{
    public class ExistUserException : BadRequestException
    {
        public ExistUserException(string Id) : base($"The User with Id: {Id} is already exist")
        {
        }
    }
}
