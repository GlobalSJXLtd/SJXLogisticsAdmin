using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sjx_Mvc.ViewModels
{
    public class ChangePasswordview
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
