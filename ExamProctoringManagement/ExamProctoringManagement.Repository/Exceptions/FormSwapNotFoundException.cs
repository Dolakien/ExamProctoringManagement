using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Exceptions
{
    public class FormSwapNotFoundException : NotFoundException
    {
        public FormSwapNotFoundException(string id) : base($"This formSwap with id: {id} was not found")
        {
        }
    }
}
