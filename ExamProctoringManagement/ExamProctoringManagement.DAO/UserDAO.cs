using ExamProctoringManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.DAO
{
    public class UserDAO
    {
        private readonly ExamProctoringManagementDBContext _context;

        public UserDAO(ExamProctoringManagementDBContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailLogin(string email, params Expression<Func<User, object>>[] includeTables)
        {
            // Sử dụng Where thay vì SingleOrDefault để giữ nguyên kiểu IQueryable
            var query = _context.Users.Where(x => x.Email == email);

            // Kiểm tra nếu có các bảng cần Include
            if (includeTables != null)
            {
                foreach (var includeTable in includeTables)
                {
                    query = query.Include(includeTable);
                }
            }

            // Trả về bản ghi đầu tiên hoặc null (FirstOrDefaultAsync) một cách bất đồng bộ
            return await query.FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIDCreate(string userId, params Expression<Func<User, object>>[] includeTables)
        {
            // Sử dụng Where thay vì SingleOrDefault để giữ nguyên kiểu IQueryable
            var query = _context.Users.Where(x => x.UserId == userId);

            // Kiểm tra nếu có các bảng cần Include
            if (includeTables != null)
            {
                foreach (var includeTable in includeTables)
                {
                    query = query.Include(includeTable);
                }
            }

            // Trả về bản ghi đầu tiên hoặc null (FirstOrDefaultAsync) một cách bất đồng bộ
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public IQueryable<User> GetAllUser(string searchTerm, string sortColumn, string sortOrder)
        {
            IQueryable<User> usersQuery = _context.Users;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                usersQuery = usersQuery.Where(u => u.UserName.ToLower().Contains(searchTerm.ToLower()));
                usersQuery = usersQuery.Where(u => u.Email.ToLower().Contains(searchTerm.ToLower()));
                usersQuery = usersQuery.Where(u => u.MainMajor.ToLower().Contains(searchTerm.ToLower()));
                usersQuery = usersQuery.Where(u => u.PhoneNumber.ToLower().Contains(searchTerm.ToLower()));
            }
            usersQuery = sortOrder?.ToLower() == "desc"
                 ? usersQuery.OrderByDescending(GetSortExpression(sortColumn))
                 : usersQuery.OrderBy(GetSortExpression(sortColumn));

            return usersQuery.AsNoTracking();

        }

        public Expression<Func<User, object>> GetSortExpression(string sortColumn) =>
            // check if sort column is null => sort by feId, otherwise sort by option
            sortColumn?.ToLower() switch
            {
                "email" => user => user.Email,
                "name" => user => user.UserName,
                "gender" => user => user.Gender.ToString,
                "mainmajor" => user => user.MainMajor,
                "Address" => user => user.Address,
                _ => user => user.UserId
            };

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }
        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(m => m.Email == email);
        }

        public async Task<User> GetUserByUserId(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);
        }


    }
}







   
