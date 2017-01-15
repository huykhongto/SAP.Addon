using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Addon.Domain.Models.Business
{
    public class AttachmentViewModel
    {
        public int AbsEntry { get; set; }
        public int Line { get; set; }
        public string srcPath { get; set; }
        public string trgtPath { get; set; }
        public string FileName { get; set; }
        public string FileExt { get; set; }
        public DateTime? Date { get; set; }
        public int UsrID { get; set; }
        public string Copied { get; set; }
        public string Override { get; set; }
    }
}
