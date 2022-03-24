using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sjx_Mvc.ViewModels
{
   
 
public class OrderViewModel
    {
        public string Id { get; set; }                                     
        public string RecieversName { get; set; }
        public string Address{ get; set; }
        public string Role { get; set; }
        
        public string Destination { get; set; }
        public string CustomersEmail { get; set; }
        public string Delivery { get; set; }
        public string Distance { get; set; }
        public string RecieversPhone { get; set; }
        public string DeliveryCode { get; set; }
        public string Categories { get; set; }
        public int Weight { get; set; }
        public string OrderCode { get; set; }
        public string Email { get; set; }
        public string PickUp { get; set; }

        //For References purposes 
        public DateTime CreatedAt { get; set; }

        //The day this item was picked Up
        public DateTime PickUpDate { get; set; }
        //The Time it was picked
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; }
        public double Charges { get; set; }
      
    }
}
