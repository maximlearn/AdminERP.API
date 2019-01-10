using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
   public class ResponseModel
    {
        public Int32 StatusCode { get; set; }
        public String StatusText { get; set; }
        public String Message { get; set; }
        public Boolean IsSuccess { get; set; }  
        public Boolean IsExist { get; set; }
    }
}
