using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sjx_Mvc.ViewModels
{
    public class PaymentViewModel
    {
        public string Categories { get; set; }
        public double Charges { get; set; } 
      
        public string TrsRef { get; set; }
        public string Status { get; set; }
        public string reference { get; set; }

        public DateTime PaymentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}
