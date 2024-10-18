using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.Enum
{
    public abstract class Role : Enumeration<Role>
    {
        public static readonly Role Lecturer = new LecturerRole();
        public static readonly Role Admin = new AdminRole();
        public static readonly Role Staff = new StaffRole();

        protected Role(int value, string name) : base(value, name)
        {
        }

        private sealed class LecturerRole : Role
        {
            public LecturerRole() : base(1, nameof(Lecturer))
            {
            }
        }
        private sealed class AdminRole : Role
        {
            public AdminRole() : base(2, nameof(Admin))
            {
            }
        }
        private sealed class StaffRole : Role
        {
            public StaffRole() : base(3, nameof(Staff))
            {
            }
        }
    }
}
