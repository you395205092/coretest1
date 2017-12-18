using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Commons
{
    public class ChinesePhoneNumAttribute: RegularExpressionAttribute
    {
        /// <summary>
        /// 定义Attribute 就能读取到
        /// </summary>
        public ChinesePhoneNumAttribute()
            : base(@"^1(3[0-9]|4[57]|5[0-35-9]|7[01678]|8[0-9])\d{8}$")
        {
            this.ErrorMessage = "电话号码必须是固话或者手机，固话要是3-4位区号开头，手机必须以13、15、18、17开头";
        }
    }
}
