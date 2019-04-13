using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ygl.Models.Forms
{
    public class SigninForm
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string password { get; set; }
    }
}
