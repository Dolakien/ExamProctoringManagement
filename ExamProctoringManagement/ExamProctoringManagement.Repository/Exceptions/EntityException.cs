using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Exceptions
{
    public abstract class EntityException : Exception
    {

        protected EntityException(string message) : base(message) { }

    }
}
