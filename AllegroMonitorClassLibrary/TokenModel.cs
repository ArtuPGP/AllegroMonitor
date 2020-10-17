using System;
using System.Collections.Generic;
using System.Text;

namespace AllegroMonitorClassLibrary
{
    public class TokenModel
    {
        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public int Expires_in { get; set; }
    }
}
