using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MyQueueMessage
    {
        public DateTime? PushedDate { get; set; }
        public string MessageId { get; set; }
        public string MessageBody { get; set; }
    }
}
