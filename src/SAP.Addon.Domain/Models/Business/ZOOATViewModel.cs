using SAP.Addon.Domain.Entities.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Addon.Domain.Models.Business
{
    public class ZOOATViewModel
    {
        public int AbsID { get; set; }
        [Required]
        [UIHint("PBFinder")]
        public string BpCode { get; set; }
        [Required]
        [UIHint("PBFinder")]
        public string BpName { get; set; }

        public int? CntctCode { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? StartDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? EndDate { get; set; }

        public DateTime? TermDate { get; set; }

        public string Descript { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public string Owner { get; set; }//short?

        public string Renewal { get; set; }

        public string UseDiscnt { get; set; }

        public short? RemindVal { get; set; }

        public string RemindUnit { get; set; }

        public string Remarks { get; set; }

        public int? AtchEntry { get; set; }

        public int? LogInstanc { get; set; } //active

        public short? UserSign { get; set; }

        public short? UserSign2 { get; set; }

        public DateTime? UpdtDate { get; set; }

        public DateTime? CreateDate { get; set; }

        public string Cancelled { get; set; }

        public string DataSource { get; set; }

        public string Transfered { get; set; }

        public string RemindFlg { get; set; }

        public string Fulfilled { get; set; }

        public string Attachment { get; set; }

        public decimal? SettleProb { get; set; }

        public int? UpdtTime { get; set; }

        public string Method { get; set; }

        public short? GroupNum { get; set; }

        public short? ListNum { get; set; }

        public DateTime? SignDate { get; set; }

        public int? AmendedTo { get; set; }

        public string U_AgreementNo { get; set; }

        public decimal? U_Commission { get; set; }

        public DateTime? U_Extension1 { get; set; }

        public DateTime? U_Extension2 { get; set; }

        public string U_Status { get; set; }

        public string U_Condition { get; set; }

        public int Err { get; set; }

        public IEnumerable<ZOAT1TMP> Details { get; set; }
    }
}
