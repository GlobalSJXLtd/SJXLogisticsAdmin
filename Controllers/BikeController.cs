using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sjx_Mvc.Models;
using Sjx_Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sjx_Mvc.Controllers
{
    public class BikeController : Controller
    {


        [HttpGet]
      public IActionResult CreateBike()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreateBike(BikeViewModel model)
        {
            string successMessage = "Bike Assigned to Rider Successfully ";
            BikeViewModel bikeModel = new BikeViewModel();
            if (ModelState.IsValid)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string url = "https://sjx-logistics-api.herokuapp.com/api/Bikes/bike";
                using (var httpClient = new HttpClient())
                {

                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            string apiResponse = await response.Content.ReadAsStringAsync();
                            bikeModel = JsonConvert.DeserializeObject<BikeViewModel>(apiResponse);
                            TempData["successMessage"] = successMessage;
                            ModelState.Clear();
                            model.RidersName= "";
                            model.BikeNo = "";

                        }
                        else
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            Response<BikeViewModel> resp = JsonConvert.DeserializeObject<Response<BikeViewModel>>(apiResponse);
                            TempData["errorMessage"] = resp.Messages;
                            ModelState.Clear();
                            model.RidersName = "";
                            model.BikeNo = "";
                        }

                    }
                  
                }
            }

            return View(model);



        }


        [HttpGet]

        public async Task<IActionResult> GetBikes()
        {

            Response<IEnumerable<BikeViewModel>> bikes = null;
            string url = "https://sjx-logistics-api.herokuapp.com/api/Bikes/getBikes";


            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        bikes = JsonConvert.DeserializeObject<Response<IEnumerable<BikeViewModel>>>(apiResponse);


                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                    return View(bikes.Data);
                }
            }
        }


    }
}
