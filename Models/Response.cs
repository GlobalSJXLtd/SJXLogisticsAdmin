using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sjx_Mvc.Models
{
    public class Response<T>
    {
        public T Data { get; set; }
        //public T uploadList { get; set; }
        public bool Success { get; set; }
        public string Messages { get; set; }
        public string tokken { get; set; }


    }
}
