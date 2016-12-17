using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP.Addon.Domain.Models.Administration;
using Dapper;

namespace SAP.Addon.Domain.Services.Administration
{
    public class ZUSRService
    {
        public ZUSR IntegrationAuthentication(string userName, string password, string function)
        {
            return SqlHelper.QuerySP<ZUSR>("usp_SY_IntegrationAuthentication", new { Username= userName, Password= password, Functional= function }).FirstOrDefault();
        }
    }
}
