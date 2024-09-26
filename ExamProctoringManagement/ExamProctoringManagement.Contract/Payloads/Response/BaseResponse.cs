using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.Payloads.Response
{
    public class BaseResponse
    {

        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }

        public object Data { get; set; }
        public IDictionary<string, string[]> Errors { get; set; }

        public static BaseResponse Success(int statusCode, string message, object Data = null)
        {
            return new BaseResponse
            {
                StatusCode = statusCode,
                IsSuccess = true,
                Message = message,
                Data = Data,
            };
        }

        public static BaseResponse Failure(int statusCode, string message, IDictionary<string, string[]> errors = default)
        {
            return new BaseResponse
            {
                StatusCode = statusCode,
                IsSuccess = false,
                Message = message,
                Errors = errors,
            };
        }
    }
}
