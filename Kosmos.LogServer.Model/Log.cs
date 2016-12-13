using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosmos.LogServer.Model
{
    public class Log
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public string Address { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Identity { get; set; }
    }
}
