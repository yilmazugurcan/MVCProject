using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace COMMON
{
    public class WebCookie
    {
        public static string UserName { get; set; }
        public static void  SetCookie(string username)
        {
           FormsAuthentication.SetAuthCookie(username, true);
            UserName = username;
        }

    }
}
