using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanhackTest.ServiceDTOs
{
    public class ResponseWrapperDTO
    {
        public string message { get; set; }
        public object data { get; set; }
    }
}
