using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sjx_Mvc.ViewModels
{
    public class BikeViewModel
    {
       
        [Required]

        [Display(Name = "Rider Name")]
        public string RidersName { get; set; }

        [Required]
        [Display(Name = "Bike Number")]
        public DateTime CreatedAt { get; set; } 
        public DateTime DueDate { get; set; } 
        public string BikeNo { get; set; }
        public string Registration { get; set; }
        [Required]
        public string dateofpurchase { get; set; }
        [Required]
        public string colour { get; set; }



    }
}
