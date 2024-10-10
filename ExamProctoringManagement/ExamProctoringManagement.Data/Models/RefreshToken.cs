using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Data.Models;

    public partial class RefreshToken
    {
        public int RefreshTokenId { get; set; }

        public string UserID { get; set; }

        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }

        public virtual User user { get; set; }
    }

