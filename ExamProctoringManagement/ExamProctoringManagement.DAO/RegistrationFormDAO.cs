using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamProctoringManagement.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamProctoringManagement.DAO
{
    public class RegistrationFormDAO
    {
        private readonly ExamProctoringManagementDBContext _context;

        public RegistrationFormDAO(ExamProctoringManagementDBContext context)
        {
            _context = context;
        }

        public async Task<RegistrationForm> GetByIdAsync(string id)
        {
            return await _context.RegistrationForms.FindAsync(id);
        }

        public async Task<IEnumerable<RegistrationForm>> GetAllAsync()
        {
            return await _context.RegistrationForms.ToListAsync();
        }

        public async Task CreateAsync(RegistrationForm registrationForm)
        {
            await _context.RegistrationForms.AddAsync(registrationForm);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(RegistrationForm registrationForm)
        {
            _context.RegistrationForms.Update(registrationForm);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var registrationForm = await _context.RegistrationForms.FindAsync(id);
            if (registrationForm != null)
            {
                _context.RegistrationForms.Remove(registrationForm);
                await _context.SaveChangesAsync();
            }
        }
    }
}