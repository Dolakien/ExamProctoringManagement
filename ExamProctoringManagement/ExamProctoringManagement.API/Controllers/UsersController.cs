using AutoMapper;
using ExamProctoringManagement.API.Extensions;
using ExamProctoringManagement.Contract.Common;
using ExamProctoringManagement.Contract.DTOs;
using ExamProctoringManagement.Contract.Payloads.Request;
using ExamProctoringManagement.Contract.Payloads.Request.RefreshTokenRequest;
using ExamProctoringManagement.Contract.Payloads.Request.UsersRequest;
using ExamProctoringManagement.Contract.Payloads.Response;
using ExamProctoringManagement.Data.Models;
using ExamProctoringManagement.Service.Interfaces;
using ExamProctoringManagement.Service.Usecases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ExamProctoringManagement.API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;

        // private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
            // _httpClient = httpClient;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateMember([FromBody] CreateUserRequest createUserRequest)
        {
            var loginResponse = await _userService.CreateUser(createUserRequest);
            return loginResponse != null
                ? Ok(BaseResponse.Success(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, loginResponse))
                : BadRequest(BaseResponse.Failure(Const.FAIL_CODE, Const.FAIL_READ_MSG));
        }


        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersQuery getUsersQuery)
        {
            var result = await _userService.GetAllUsers(getUsersQuery);
            return result != null
                ? Ok(BaseResponse.Success(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG,
                    new PaginationResponse<UserDto>(result, result.CurrentPage, result.PageSize, result.TotalCount,
                        result.TotalPages)))
                : BadRequest(BaseResponse.Failure(Const.FAIL_CODE, Const.FAIL_READ_MSG));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Contract.Payloads.Request.UsersRequest.LoginRequest loginRequest)
        {
            var loginResponse = await _userService.Login(loginRequest);

            return loginResponse != null
                ? Ok(BaseResponse.Success(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, loginResponse))
                : BadRequest(BaseResponse.Failure(Const.FAIL_CODE, Const.FAIL_READ_MSG));
        }

        [HttpPost("changepassword")]
        [Authorize]
        public async Task<IActionResult> UpdatePassword([FromBody] PasswordRequest passwordRequest)
        {
            passwordRequest.Email = User.GetEmail();
            var isUpdate = await _userService.UpdatePassword(passwordRequest);
            return isUpdate
                ? Ok(BaseResponse.Success(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG,
                    nameof(UpdatePassword) + " successful"))
                : BadRequest(BaseResponse.Failure(Const.FAIL_CODE, Const.FAIL_UPDATE_MSG));
        }


        [HttpGet("information")]
        public async Task<IActionResult> GetMemberById()
        {
            var Id = User.GetID();
            var user = await _userService.GetUserById(Id);
            return user != null
                ? Ok(user)
                : NotFound();
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendResetPassword(SendEmailRequest request)
        {
            var user = await _userService.GetUserByEmail(request.Email);
            if (user == null)
            {
                return NotFound("Email not found");
            }

            string resetLink = GenerateResetLink();
            bool emailSent = await _userService.SendResetPasswordEmail(request.Email, resetLink);

            return Ok("Reset password email sent");
        }

        private string GenerateResetLink()
        {
            return "https://example.com/reset-password";
        }

        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest resetPassword)
        {
            var isUpdate = await _userService.ResetPassword(resetPassword);
            return isUpdate
                ? Ok(BaseResponse.Success(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG,
                    nameof(UpdatePassword) + " successful"))
                : BadRequest(BaseResponse.Failure(Const.FAIL_CODE, Const.FAIL_UPDATE_MSG));
        }


        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUser user)
        {
            var response = await _userService.UpdateUserAsync(user);
            if (response != null)
                return Ok(BaseResponse.Success(
                     Const.SUCCESS_UPDATE_CODE,
                     Const.SUCCESS_UPDATE_MSG,
                     "User is Updated successfully"
                 ));
            return BadRequest(BaseResponse.Failure(Const.FAIL_CODE, Const.FAIL_UPDATE_MSG));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);

                return Ok(BaseResponse.Success(
                    Const.SUCCESS_UPDATE_CODE,
                    Const.SUCCESS_UPDATE_MSG,
                    "User is deleted successfully"
                ));
            }
            catch (Exception ex)
            { 
                return BadRequest(BaseResponse.Failure(
                    Const.FAIL_CODE,
                    Const.FAIL_UPDATE_MSG
                ));
            }
        }



    }
}
