using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Contract.Common
{
    public class Const
    {
        #region Error Codes

        public static int ERROR_EXCEPTION = (int)HttpStatusCode.InternalServerError;

        #endregion

        #region Success Codes

        public static int SUCCESS_CREATE_CODE = (int)HttpStatusCode.Created;
        public static string SUCCESS_CREATE_MSG = "Save data success";
        public static int SUCCESS_READ_CODE = (int)HttpStatusCode.OK;
        public static string SUCCESS_READ_MSG = "Get data success";
        public static int SUCCESS_UPDATE_CODE = (int)HttpStatusCode.NoContent;
        public static string SUCCESS_UPDATE_MSG = "Update data success";
        public static int SUCCESS_DELETE_CODE = (int)HttpStatusCode.NoContent;
        public static string SUCCESS_DELETE_MSG = "Delete data success";
        public static int SUCCESS_PAYMENT_CODE = (int)HttpStatusCode.NoContent;
        public static string SUCCESS_PAYMENT_MSG = "Payment successfully";

        #endregion

        #region Fail code

        public static int FAIL_CODE = (int)HttpStatusCode.BadRequest;
        public static string FAIL_CREATE_MSG = "Save data fail";
        public static string FAIL_READ_MSG = "Get data fail";
        public static string FAIL_UPDATE_MSG = "Update data fail";
        public static string FAIL_DELETE_MSG = "Delete data fail";
        public static string FAIL_DUPLCATE_MSG = "Duplicate data";
        public static string FAIL_PAYMENT_MSG = "Payment failure";

        #endregion


        #region Warning Code

        public static int WARNING_NO_DATA_CODE = (int)HttpStatusCode.NotFound;
        public static string WARNING_NO_DATA__MSG = "No data";

        #endregion
    }
}
