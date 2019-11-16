using System;
using System.Collections.Generic;
using System.Text;

namespace Motorport.Domain.Communication
{
    public class LoginResponse : BaseResponse
    {
        public string Token { get; private set; }

        public LoginResponse(bool success, string message, string token): base(success,message)
        {
            Token = token;
        }

        public LoginResponse(string message, string token): this(true,message,token)
        {

        }

        public LoginResponse(bool success,string message) : this(success, message, "")
        {

        }
    }
}
