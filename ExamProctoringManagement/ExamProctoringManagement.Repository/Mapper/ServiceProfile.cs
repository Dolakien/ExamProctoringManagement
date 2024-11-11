using AutoMapper;
using AutoMapper.Execution;
using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Contract.Payloads;
using ExamProctoringManagement.Contract.Payloads.Request.UsersRequest;
using ExamProctoringManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExamProctoringManagement.Repository.Mapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UpdateUser, User>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName));






        }
    }
}
