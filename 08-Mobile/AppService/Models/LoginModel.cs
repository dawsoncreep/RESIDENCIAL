using System;
using System.Collections.Generic;
using System.Text;

namespace AppService.Models
{
    public class LoginModel
    {
        public String username { get; set; }
        public String password { get; set; }
        public String grant_type { get; set; }
        public String client_id { get; set; }
    }
}
