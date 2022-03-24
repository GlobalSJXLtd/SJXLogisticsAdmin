using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sjx_Mvc.ViewModels
{
    public class RegisterViewModel
    {
     
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "First Name")] 
        public string FirstName { get; set; }
       
         public string BikeNumber{ get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
       
        public string Email { get; set; }
      
        public string Address { get; set; }
       
      
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string status { get; set; }
       



    }
}

        public class Role
      {
       public int roleId { get; set; }
       public string roleName { get; set; }
       public DateTime createdOn { get; set; }

             }   
