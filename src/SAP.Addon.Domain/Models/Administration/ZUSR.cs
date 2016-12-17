using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Addon.Domain.Models.Administration
{
    public class ZUSR
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Description { get; set; }

        public string Password { get; set; }

        public string DefaultBranch { get; set; }

        public DateTime? LastLogin { get; set; }

        public DateTime? LastLogout { get; set; }

        public string AccessIPAddress { get; set; }

        public string IsOnline { get; set; }

    }

}
