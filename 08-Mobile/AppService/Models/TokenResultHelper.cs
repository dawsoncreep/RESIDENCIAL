using System;
using System.Collections.Generic;
using System.Text;

namespace AppService.Models
{
    public class TokenResultHelper
    {
        public String access_token { get; set; }
        public String token_type { get; set; }
        public String expires_in { get; set; }
    }
}
