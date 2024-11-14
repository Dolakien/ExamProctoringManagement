using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Interfaces
{
    public interface IRegistrationFormService
    {
        Task<RegistrationForm> GetRegistrationFormByIdAsync(string id);
        Task<IEnumerable<RegistrationForm>> GetAllRegistrationFormsAsync();
        Task<GetRegisFormWithSlotsDto> CreateRegistrationFormAsync(CreateRegistrationFormDto createRegistrationFormDto, string userId);
        Task<RegistrationForm> UpdateRegistrationFormAsync(RegisFormUpdateDto RegistrationForm);
        Task DeleteRegistrationFormAsync(string id);
        Task<GetRegisFormWithSlotsDto> GetRegisFormWithSlotsAsync(string formId);
        Task<List<RegistrationFormUserDTO>> GetAllByUserIdAsync(string userId);
        Task<string> SwapProctoringAsync(SwapProctoring swapProctoring);

    }
}
