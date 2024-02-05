using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChat.Common.IBaseRequest
{
    public class ApiRequest
    {
      
        [Range(1000000000, 9999999999, ErrorMessage = "The parameter Timestamp is not a valid 10 digit number")]
        [DefaultValue(9999999999)]
        public long Timestamp { get; set; }

        [StringLength(32, MinimumLength = 32, ErrorMessage = "The parameter Random must be a 32-bit string")]
        public string? Random { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Thie parameter Signature  cannot be empty")]
        public string? Signature { get; set; }
    }
}
