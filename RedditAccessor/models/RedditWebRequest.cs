using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditAccessor.models
{
    public class RedditWebRequest
    {
        public int RequestCounter = 0;
        public string? RequestAfter { get; set; }
        public string UserName = "";
        public string? Password { get; set; }
        public string ClientId = "";
        public string ClientSecret = "";
        public string UserAgent = "MyUniqueUserAgent/1.0";
        public string GrantType = "password";
        public string? AccessToken { get; set; }
    }
}
