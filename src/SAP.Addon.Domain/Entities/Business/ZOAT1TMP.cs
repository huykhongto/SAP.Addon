using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Addon.Domain.Entities.Business
{
    public class ZOAT1TMP
    {
        public int AgrNo { get; set; }

        public int AgrLineNum { get; set; }
        [Required]
        [UIHint("ItemFinder")]
        public string ItemCode { get; set; }

        [Required]
        [UIHint("ItemFinder")]
        public string ItemName { get; set; }

        public short? ItemGroup { get; set; }

        public decimal? PlanQty { get; set; }
        [UIHint("Currency")]
        public decimal? UnitPrice { get; set; }

        public string Currency { get; set; }

        public decimal? CumQty { get; set; }

        public decimal? CumAmntFC { get; set; }

        public decimal? CumAmntLC { get; set; }

        public string FreeTxt { get; set; }

        public string InvntryUom { get; set; }

        public int? LogInstanc { get; set; }

        public int? VisOrder { get; set; }

        public decimal? RetPortion { get; set; }

        public DateTime? WrrtyEnd { get; set; }

        public string LineStatus { get; set; }

        public decimal? PlanAmtLC { get; set; }

        public decimal? PlanAmtFC { get; set; }

        public decimal? Discount { get; set; }

        public string U_OtherName { get; set; }

        public DateTime? U_Start { get; set; }

        public DateTime? U_End { get; set; }

        public string U_FreeText { get; set; }

        public decimal? U_BPrice { get; set; }

        public decimal? U_VatPrcnt { get; set; }

        public decimal? U_PriceAftVat { get; set; }

        public decimal? U_DiscPrcnt { get; set; }

        public string U_TenderType { get; set; }
        public string U_TenderUnit { get; set; }//add more

        public string U_BPCode { get; set; }

        public string U_BPName { get; set; }

        public string U_Notify { get; set; }

        public int? U_BaseAgr { get; set; }

        public int? U_BaseAgrLine { get; set; }
    }
}
