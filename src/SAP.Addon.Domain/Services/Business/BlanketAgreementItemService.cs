using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SAP.Addon.Domain.Entities.Business;
using SAP.Addon.Domain.Models.Business;

namespace SAP.Addon.Domain.Services.Business
{
    public class BlanketAgreementItemService
    {
        public IEnumerable<BlanketAgreementItemSearchViewModel> FindItems(string ItemCode, string ItemName, string Manufacture, int ItemGroup, string Inactive)
        {
            return SqlHelper.QuerySP<BlanketAgreementItemSearchViewModel>("usp_MD_SearchItems", new
            {
                ItemCode = ItemCode,
                ItemName = ItemName,
                Manufacture = Manufacture,
                ItemGroup = ItemGroup,
                Inactive = Inactive
            });
        }

        public IEnumerable GetMeasureList()
        {
            return SqlHelper.QuerySP<OriginalListViewModel>("usp_MD_GetUoMList", new {@Type = 1  });
        }

        public string GetOriginalByItem(string ItemCode)
        {
            string str1 = string.Concat("Select TOP 1 ISNULL(T0.DefaultOriginal, '') From ZOAT3 T0 Where T0.ItemCode = N'", ItemCode, "'");
            var obj = SqlHelper.ExecuteScalarSQL(str1);
            if (obj != null)
                return obj.ToString();
            else
                return "";
        }

        public string GetOriginalByManufacture(string manf)
        {
            string str1 = string.Concat("Select TOP 1 T0.Code From ZOAT2 T0 LEFT JOIN OMRC T1 On T0.DefManf = T1.FirmCode Where T1.FirmName = N'", manf, "'");
            var obj = SqlHelper.ExecuteScalarSQL(str1);
            if (obj != null)
                return obj.ToString();
            else
                return "";
        }

        public MeasureListViewModel GetDefaultUoM(string itemCode)
        {
            string str = string.Concat("Select TOP 1 * From ZCUMC Where ItemCode = '", itemCode.Trim(), "' And [Default] = 'Y'");
            return SqlHelper.QuerySQL<MeasureListViewModel>(str).FirstOrDefault();
        }

        public IEnumerable<OriginalListViewModel> GetOriginalList()
        {
            return SqlHelper.QuerySP<OriginalListViewModel>("usp_MD_GetOriginalList");
        }

        public int Save(ZOAT1TMP detail)
        {
            SqlHelper.ExecuteSP("usp_MD_SaveBlanketAgreementDetails", detail);
            return detail.Err;
        }
    }
}
