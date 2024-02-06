using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChat.Common.Dto.RequestDtos.Message
{
    public class AddBulkMessageReqDto
    {
        public long UserId { get; set; }
        public long GroupId { get; set; }
        public string? Content { get; set; }
        public DateTime SetTime { get; set; }
    }
}
