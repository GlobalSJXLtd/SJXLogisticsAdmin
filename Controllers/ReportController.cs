using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sjx_Mvc.Models;
using Sjx_Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sjx_Mvc.Controllers
{
    public class ReportController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string term)
        {
            return View();
        }


        [HttpGet]

        public async Task<IActionResult> GetAssignedOrder()
        {

            Response<IEnumerable<OrderViewModel>> users = null;
            string url = "https://sjx-logistics-api.herokuapp.com/api/Report/assigned";


            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync(url))
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
        public async Task<IActionResult> UnCompletedDelivery()
        {

            Response<IEnumerable<OrderViewModel>> users = null;
            string url = "https://sjx-logistics-api.herokuapp.com/api/Report/uncompletedDelivery";


            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync(url))
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

        public async Task<IActionResult> GetUnassignedOrder()
        {

            Response<IEnumerable<OrderViewModel>> users = null;
            string url = "https://sjx-logistics-api.herokuapp.com/api/Report/unassigned";


            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync(url))
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
      public async Task<IActionResult> GetCompletedOrder()
        {

            Response<IEnumerable<OrderViewModel>> users = null;
            string url = "https://sjx-logistics-api.herokuapp.com/api/Report/completed";


            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync(url))
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
        public async Task<IActionResult> GetUnCompletedOrder()
        {

            Response<IEnumerable<OrderViewModel>> users = null;
            string url = "https://sjx-logistics-api.herokuapp.com/api/Report/uncompleted";


            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync(url))
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
        public async Task<IActionResult> GetCancelOrder()
        {

            Response<IEnumerable<OrderViewModel>> users = null;
            string url = "https://sjx-logistics-api.herokuapp.com/api/Report/canceledOrder";


            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync(url))
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



    }
}
