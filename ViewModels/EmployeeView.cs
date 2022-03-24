using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sjx_Mvc.ViewModels
{
    public class EmployeeView
    {
        [Required]

        public int RoleId { get; set; }
        public string Role { get; set; }
        public string GuarantorName { get; set; }
        public string GuarantorAddress { get; set; }
        public string GuarantorOccupation { get; set; }
        public string GuarantorEmployer { get; set; }
        public string GuarantorPhoneNumber { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeEmail { get; set; }
      

    }
}
