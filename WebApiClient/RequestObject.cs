using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    public class RequestObject<T>
    {
        public string Message { get; set; }
        public T Value { get; set; }
    }
}
