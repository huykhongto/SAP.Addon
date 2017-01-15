using Dapper;
using SAP.Addon.Domain.Entities.Business;
using SAP.Addon.Domain.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Addon.Domain.Services.Business
{
    public class BlanketAgreementService
    {
        public IEnumerable<BlanketAgreementListViewModel> GetAgreements()
        {
            var prs = new BlanketAgreementSearchParams();

            return SqlHelper.QuerySP<BlanketAgreementListViewModel>("usp_MD_GetAgreementList", prs);
        }

        public IEnumerable<CustomerSearchViewModel> FindCustomers(string pbCode, string pbName, string pbAddress, string pbGroup, string pbType)
        {
            return SqlHelper.QuerySP<CustomerSearchViewModel>("usp_SD_SearchBP", new
            {
                CardCode = pbCode,
                CardName = pbName,
                CardAddress = pbAddress,
                BPGroup = pbGroup,
                CardType = pbType
            });
        }

        public BusinessPartner LoadPartner(string cardCode)
        {
            string str = " WHERE 1=1 ";
            if (!string.IsNullOrEmpty(cardCode))
            {
                str = string.Concat(str, " And RTRIM(CARDCODE)='", cardCode.Trim(), "'");
            }

            string sql = string.Concat(" SELECT TOP 1 CARDCODE, CARDNAME, CARDTYPE, CURRENCY, "+
                                                      "CONVERT(VARCHAR,SHIPTYPE) AS SHIPTYPE,  "+
                                                      "CONVERT(VARCHAR,SLPCODE) AS SLPCODE, SHIPTODEF, "+
                                                      "BILLTODEF, CNTCTPRSN, CHANNLBP, NOTES, PHONE1, " +
                                                      "E_MAIL, BALANCE, CREDITLINE, T1.PYMNTGROUP  " +
                                                      "FROM OCRD T0 " + 
                                                      "LEFT JOIN OCTG T1 On T0.GroupNum = T1.GroupNum ", str);

            return SqlHelper.QuerySQL<BusinessPartner>(sql).FirstOrDefault();
        }

        public IEnumerable<ContactData> LoadContactPersons(string cardCode)
        {
            string sql = string.Concat("Select Convert(varchar,CntctCode) as Code, Name From OCPR Where RTRIM(CardCode) = '", cardCode.Trim(), "'");
            return SqlHelper.QuerySQL<ContactData>(sql);
        }

        public IEnumerable<ContactData> LoadAddress(string cardCode, string type)
        {
            string sql = string.Format("Select Address Code, Address Name From CRD1 Where AdresType = '{1}' And RTRIM(CardCode) = '{0}'", cardCode.Trim(),type);
            return SqlHelper.QuerySQL<ContactData>(sql);
        }

        public IEnumerable<ContactData> GetOwnerList()
        {
            string sql = "Select Convert(varchar,EmpID) As Code, UPPER(U_HRCode) + ' - ' + UPPER(FirstName) + ', ' + UPPER(LastName) As Name From OHEM Order by FirstName";
            return SqlHelper.QuerySQL<ContactData>(sql);
        }

        public bool Save(ZOOAT model)
        {
            SqlHelper.ExecuteSP("usp_MD_SaveBlanketAgreement", model);
            return model.Err == 0;
        }

        public ZOOATViewModel Find(int id)
        {
            var models = SqlHelper.QueryMultipleSP<ZOOATViewModel, ZOAT1TMPViewModel,AttachmentViewModel>("usp_MD_GetBlanketAgreement", new { ABSID = id });

            var BA = models.Item1.FirstOrDefault();
            if (BA != null)
            {
                BA.Details = models.Item2;
                BA.Attachments = models.Item3;
            }
                
            if(BA.Details == null)
                BA.Details = new List<ZOAT1TMPViewModel>();
            if (BA.Attachments == null)
                BA.Attachments = new List<AttachmentViewModel>();



            return BA;
        }
    }
}
