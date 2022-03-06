using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Siemens.Common
{
    
        public class ResponseModel<T>
        {
            public ResponseModel()
            {
                StatusCode = HttpStatusCode.OK;
            }
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
            public T Data { get; set; }
            public HttpStatusCode StatusCode { get; set; }
        }
    
}
