using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Exceptions
{
    public sealed class ValidationException : EntityException
    {

        public ValidationException(IDictionary<string, string[]> errors) : base("One or more validation errors occured!")
            => Errors = errors;

        public IDictionary<string, string[]> Errors { get; }
    }
}
