using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web.Commons;

namespace Web.Models
{
    public class LoginRequest
    {
        [ChinesePhoneNum]
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }


        [Required]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "验证码长度必须为4")]
        public string Captcha { get; set; }
    }
}
