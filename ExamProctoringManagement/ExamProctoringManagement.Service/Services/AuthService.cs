using ExamProctoringManagement.Contract.Common;
using ExamProctoringManagement.Contract.Payloads.Request.RefreshTokenRequest;
using ExamProctoringManagement.Contract.Payloads.Response;
using ExamProctoringManagement.Repository.Interfaces;
using ExamProctoringManagement.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IUserService _userService;
        private readonly IClaimsPrincipalExtensions _claimsPrincipalExtensions;

        public AuthService(IRefreshTokenRepository refreshTokenRepository,
            IJwtProvider jwtProvider,
            IClaimsPrincipalExtensions claimsPrincipalExtensions, IUserService userService)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _jwtProvider = jwtProvider;
            _claimsPrincipalExtensions = claimsPrincipalExtensions;
            _userService = userService;
        }

        public async Task<BaseResponse> RefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            var claimsPrincipal = _claimsPrincipalExtensions.GetTokenPrincipal(refreshTokenRequest.JwtToken);
            refreshTokenRequest.UserId = claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(refreshTokenRequest.UserId))
            {
                return BaseResponse.Failure(Const.FAIL_CODE, Const.FAIL_CREATE_MSG);
            }
            // get User Name
            var user = await _userService.GetUserById(refreshTokenRequest.UserId);
            string userName = user.UserName;
            if (string.IsNullOrEmpty(userName))
            {
                return BaseResponse.Failure(Const.FAIL_CODE, Const.FAIL_CREATE_MSG);
            }
            // get refresh token
            var refreshToken = await _refreshTokenRepository.GetRefreshToken(refreshTokenRequest);

            // Gen token & refresh token
            var jwtToken = _jwtProvider.GenerateToken(refreshToken.User);
            var refreshTokenString = _jwtProvider.GenerateRefreshToken();

            // Update token
            refreshToken.Token = refreshTokenString;
            refreshToken.ExpiryDate = DateTime.UtcNow.AddHours(12);
            var result = await _refreshTokenRepository.UpdateRefreshToken(refreshToken);
            if (!result)
            {
                return BaseResponse.Failure(Const.FAIL_CODE, Const.FAIL_CREATE_MSG);
            }

            var loginResponse = new LoginResponse
            {
                UserId = refreshTokenRequest.UserId,
                JwtToken = jwtToken,
                UserName = userName,
                RoleName = user.Role.RoleName,
                RefreshToken = refreshTokenString
            };
            return BaseResponse.Success(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, loginResponse);
        }
    }
}
