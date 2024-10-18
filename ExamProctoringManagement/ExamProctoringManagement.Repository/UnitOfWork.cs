using ExamProctoringManagement.DAO;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExamProctoringManagementDBContext _context;
        private UserDAO _userDAO;
        private RefreshTokenDAO _refreshTokenDAO;


        public UnitOfWork(ExamProctoringManagementDBContext context)
        {
            _context = context;
        }


        public RefreshTokenDAO RefreshTokenDAO => _refreshTokenDAO = new RefreshTokenDAO(_context);
        public UserDAO UserDAO => _userDAO = new UserDAO(_context);

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public IDbTransaction BeginTransaction()
        {
            var transaction = _context.Database.BeginTransaction();

            return transaction.GetDbTransaction();
        }

        public async Task<int> SaveChangesWithTransactionAsync()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }
            return result;
        }
    }
}
