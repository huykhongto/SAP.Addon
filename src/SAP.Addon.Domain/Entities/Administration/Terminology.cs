using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Addon.Domain.Entities.Administration
{
    public class Terminology
    {
        public static string FUNCTIONS = "FUNCTIONS";
        public static string AGREEMENT_METHOD = "AGREEMENT_METHOD";
        public static string AGREEMENT_STATUS = "AGREEMENT_STATUS";
        public static string DOCUMENT_TYPE = "DOCUMENT_TYPE";
        public static string PAYMENT_TERM = "PAYMENT_TERM";
        public static string AGREEMENT_TYPE = "AGREEMENT_TYPE";

        public int Id { get; set; }

        public string Name { get; set; }

        public int? OrderId { get; set; }

        public string Code { get; set; }

        public int? CreatedUserId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedUserId { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? IsDeleted { get; set; }

    }

}
