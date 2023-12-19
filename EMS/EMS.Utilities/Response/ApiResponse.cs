using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Utilities.Response
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public bool IsError { get; set; }

        public ApiResponse(int statusCode, string message, object data, bool isError)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
            IsError = isError;
        }
    }
}
