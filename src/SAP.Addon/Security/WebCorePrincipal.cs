using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Principal;
namespace Security
{
    public class WebCorePrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role)
        {
            if (roles == null)
                return false;
            if (roles.Any(r => role.Contains(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public WebCorePrincipal(string Username)
        {
            this.Identity = new GenericIdentity(Username);
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public bool IsSysAdmin { get; set; }
        public string[] roles { get; set; }
    }

    public class WebCorePrincipalSerializeModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public bool IsSysAdmin { get; set; }
        public string[] roles { get; set; }

    }
}