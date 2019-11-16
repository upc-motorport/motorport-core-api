using System;
using System.Collections.Generic;
using System.Text;

namespace Motorport.Domain.Communication
{
    public class LoginRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
