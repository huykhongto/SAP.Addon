using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SAP.Addon.Domain.Models
{
    public class LoginViewModel
    {
        [Required]
        //[Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "{0} được yêu cầu nhập")]
        [Required]
        public string Password { get; set; }
        public bool Remember { get; set; }

        public string Functional { get; set; }
    }
}
