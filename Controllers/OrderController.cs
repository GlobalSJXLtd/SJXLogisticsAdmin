using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Sjx_Mvc.Models;
using Sjx_Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sjx_Mvc.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult CreateOrder()
        {
            return View();
        }





        [HttpGet]
        public async Task<IActionResult> GetPendingOrder()

        
        {
            List<OrderSelect> users = new List<OrderSelect>();
            string token = HttpContext.Session.GetString("token");
            string url = "https://sjx-logistics-api.herokuapp.com/api/Assign/Pendingorder";


            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<List<OrderSelect>>(apiResponse);


                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }

                    return View(new SelectList(users, "Id", "FirstName"));

                }
            }
        }


        public async Task<IActionResult> GetOrders()
        {
            Response<IEnumerable<OrderViewModel>> users = null;
            string token = HttpContext.Session.GetString("token");
            string url = "https://sjx-logistics-api.herokuapp.com/api/Orders/getOrder";


            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using (var response = await httpClient.GetAsync(url ))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<Response<IEnumerable<OrderViewModel>>>(apiResponse);


                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                    return View(users.Data);
                }
            }
        }

        [HttpGet]

        public async Task<IActionResult> GetRiders()
        {
            string token = HttpContext.Session.GetString("token");
            Response<IEnumerable<RiderListModel>> bikes = null;
            string url = "https://sjx-logistics-api.herokuapp.com/api/Assign/getriders";


            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        bikes = JsonConvert.DeserializeObject<Response<IEnumerable<RiderListModel>>>(apiResponse);


                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                    return View(bikes.Data);
                }
            }
        }


        [HttpGet]

        public  async Task<JsonResult> GetHereApi(string term)
        {
           
            Root here = null;
       string url = "https://autosuggest.search.hereapi.com/v1/discover?q=Lagos&lang=en&at=52.93175,12.77165&apiKey=cpLo9ydJuovc-Rice740q9bsEpQc-DbBYYD7C6k96lc&limt=30";


            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        here = JsonConvert.DeserializeObject<Root>(apiResponse);


                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                    //var result = here.(x => x.country.StartsWith(term)).Select(y => y.country).ToList();
                    return Json(here, System.Web.Mvc.JsonRequestBehavior.AllowGet);
                }
            }
        }
        


        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderViewModel model)
        {
            string successMessage = "Order Created Successfully ";
            OrderViewModel bikeModel = new OrderViewModel();
            string token = HttpContext.Session.GetString("token");
            if (ModelState.IsValid)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string url = "https://sjx-logistics-api.herokuapp.com/api/Orders/create";
                using (var httpClient = new HttpClient())
                {

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            string apiResponse = await response.Content.ReadAsStringAsync();
                            bikeModel = JsonConvert.DeserializeObject<OrderViewModel>(apiResponse);
                            TempData["successMessage"] = successMessage;
                            ModelState.Clear();
                            

                        }
                        else
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            Response<OrderViewModel> resp = JsonConvert.DeserializeObject<Response<OrderViewModel>>(apiResponse);
                            TempData["errorMessage"] = resp.Messages;
                            throw new Exception(response.ReasonPhrase);
                            ModelState.Clear();
                           
                        }

                    }

                    return RedirectToAction("GetOrders");
                }
            }

            return View(model);



        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AssignOrder()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AssignOrder(AssignModel model)
        {
            string successMessage = "Order assigned successfully";
            string token = HttpContext.Session.GetString("token");
            AssignModel assign = new AssignModel();
            if (ModelState.IsValid)
            {
                string url = "https://sjx-logistics-api.herokuapp.com/api/Assign/Assign";
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {

                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            assign = JsonConvert.DeserializeObject<AssignModel>(apiResponse);
                            TempData["successMessage"] = successMessage;
                        }
                        else
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            Response<AssignModel> resp = JsonConvert.DeserializeObject<Response<AssignModel>>(apiResponse);
                            TempData["errorMessage"] = resp.Messages;
                            throw new Exception(response.ReasonPhrase);
                        }


                    }
                }

            }
            return View();
        }


    }
}

    

