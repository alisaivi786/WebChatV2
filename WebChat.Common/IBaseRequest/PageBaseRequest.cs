using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChat.Common.IBaseRequest
{
    public class PageBaseRequest : ApiRequest
    {
        [Display(Name = "PageSize")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Parameter '{0}' cannot be empty")]
        [Range(1, 10000, ErrorMessage = "'{0}' Must be a positive integer and not greater than 10000")]
        [DefaultValue(20)]
        public int PageSize { get; set; } = 20;

        [Display(Name = "PageNo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Parameter '{0}' cannot be empty")]
        [Range(1, int.MaxValue, ErrorMessage = "'{0}' must be a positive integer")]
        [DefaultValue(1)]
        public int PageNo { get; set; } = 1;
    }
}
