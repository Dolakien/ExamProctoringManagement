using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Exceptions
{
    public class OldPasswordInvalidException : Exception
    {
        public OldPasswordInvalidException() : base("Old Password is incorrect")
        {
        }
    }
}
