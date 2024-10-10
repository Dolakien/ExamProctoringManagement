using ExamProctoringManagement.Service.Authentication;
using Microsoft.Extensions.Options;

namespace ExamProctoringManagement.API.OptionalSetup
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        private const string SectionName = "Jwt";
        private readonly IConfiguration _configuration;

        public JwtOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JwtOptions options)
        {
            // bind Jwt json to JwtOptions obj
            _configuration.GetSection(SectionName).Bind(options);
        }
    }
}
