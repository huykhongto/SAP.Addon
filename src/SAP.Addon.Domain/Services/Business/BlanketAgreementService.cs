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
            return SqlHelper.QuerySP<BlanketAgreementListViewModel>("usp_MD_GetAgreementList", new {
                //ABSID = 0,
                //TOABSID = 0,
                //STARTDATE = 0,
                //TOSTARTDATE = 0,
                //ENDDATE = 0,
                //TOENDDATE = 0,
                //SIGNGDATE = 0,
                //TOSIGNDATE = 0,
                //BPCODE = 0,
                //BPNAME = 0,
                //DESCRIPTION = 0,
                //STATUS = 0,
                //ITEMNAME = 0,
                //SHOWINACTIVE = 0,
                //USERSIGN = 0
            });
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
            return SqlHelper.ExecuteSP("usp_MD_SaveBlanketAgreement", model) > 0;
        }

    }
}
