using ExamProctoringManagement.API.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace ExamProctoringManagement.API.Controllers
{

    [ServiceFilter(typeof(ExecuteValidation))]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
    }
}
