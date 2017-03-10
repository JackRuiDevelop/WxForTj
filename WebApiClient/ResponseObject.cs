using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    public class ResponseObject<T>
    {
        public bool Flag { get; set; }
        public string Message { get; set; }
        public T Value { get; set; }
    }
}
