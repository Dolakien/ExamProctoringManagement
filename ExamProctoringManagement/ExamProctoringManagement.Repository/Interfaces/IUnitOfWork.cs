using ExamProctoringManagement.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public UserDAO UserDAO { get; }
        public RefreshTokenDAO RefreshTokenDAO { get; }
        public Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
        public Task<int> SaveChangesWithTransactionAsync();

    }
}
