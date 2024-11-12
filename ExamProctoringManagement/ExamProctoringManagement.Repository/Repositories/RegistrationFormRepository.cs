using AutoMapper;
using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.DAO;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Repository.Exceptions;
using ExamProctoringManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Repositories
{
    public class RegistrationFormRepository : IRegistrationFormRepository
    {
        private readonly RegistrationFormDAO _RegistrationFormDAO;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RegistrationFormRepository(RegistrationFormDAO RegistrationFormDAO, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _RegistrationFormDAO = RegistrationFormDAO;
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RegistrationForm> GetByIdAsync(string id)
        {
            return await _RegistrationFormDAO.GetByIdAsync(id);
        }

        public async Task<IEnumerable<RegistrationForm>> GetAllAsync()
        {
            return await _RegistrationFormDAO.GetAllAsync();
        }

        public async Task CreateAsync(RegistrationForm RegistrationForm)
        {
            await _RegistrationFormDAO.CreateAsync(RegistrationForm);
        }

        public async Task<RegistrationForm> UpdateAsync(RegisFormUpdateDto RegistrationForm)
        {
            var existedRegisForm = await _uow.RegistrationFormDAO.GetByIdAsync(RegistrationForm.FormId);
            if (existedRegisForm == null)
            {
                throw new RegisFormNotFoundException(RegistrationForm.FormId);
            }
            _mapper.Map(RegistrationForm, existedRegisForm);
            await _uow.RegistrationFormDAO.UpdateAsync(existedRegisForm);

            return existedRegisForm;
        }

        public async Task DeleteAsync(string id)
        {
            await _RegistrationFormDAO.DeleteAsync(id);
        }
    }
}
