using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Authentication
{
    public class JwtOptions
    {
        public string Issuer { get; init; }
        public string Audience { get; init; }
        public string SecretKey { get; init; }
        public TimeSpan ExpiryTimeFrame { get; init; }
    }
}
