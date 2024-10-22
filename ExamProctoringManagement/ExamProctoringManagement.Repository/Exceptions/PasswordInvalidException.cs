using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Exceptions
{
    public class PasswordInvalidException : Exception
    {
        public PasswordInvalidException() : base("Password is invalid")
        {
        }
    }
}
