using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCore.Domain.Entities.Configuration
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public int? OrderId { get; set; }

        public string Code { get; set; }

        public static string FUNCTIONS = "FUNCTIONS";
        public static string AGREEMENT_METHOD = "AGREEMENT_METHOD";
        public static string AGREEMENT_STATUS = "AGREEMENT_STATUS";
        public static string DOCUMENT_TYPE = "DOCUMENT_TYPE";
        public static string PAYMENT_TERM = "PAYMENT_TERM";
        public static string AGREEMENT_TYPE = "AGREEMENT_TYPE";
    }
}
