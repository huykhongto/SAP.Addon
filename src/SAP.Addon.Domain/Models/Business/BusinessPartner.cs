using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Addon.Domain.Models.Business
{
    public class BusinessPartner
    {
        public IEnumerable<ContactData> ContactPersons { get; set; }
        public IEnumerable<ContactData> BillTo { get; set; }
        public IEnumerable<ContactData> ShipTo { get; set; }


        public string CARDCODE;

        public string CARDNAME;

        public string CARDTYPE;

        public int GROUPCODE;

        public string ADDRESS;

        public string PHONE1;

        public string E_MAIL;

        public string CURRENCY;

        public string PYMNTGROUP;

        public decimal BALANCE;

        public decimal CREDITLINE;

        public string CONTACTPERSONDEFAULT;

        public string SHIPTODEFAULT;

        public string BILLTODEFAULT;

        public string SHIPPINGTYPE;

        public string SALESEMPLOYEE;

        public string BPCHANNELNAME;

        public string CUSGROUPSEARCH;
    }
}
