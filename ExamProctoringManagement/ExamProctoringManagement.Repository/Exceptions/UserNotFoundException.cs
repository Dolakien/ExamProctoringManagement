using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string email) : base($"This user with email: {email} was not found")
        {
        }
    }
}
