using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sjx_Mvc.Models;
using Sjx_Mvc.ViewModels;
using SjxLogistics.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sjx_Mvc.Controllers
{
    public class DashboardController : Controller
    {
         IActionResult Index()
        {
            return View();
        }

       
        [HttpGet]

        public async Task<IActionResult> Dashboard()
        {
                    
                      return View();
        
        }
    }
}
