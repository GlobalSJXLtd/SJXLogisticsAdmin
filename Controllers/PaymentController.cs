using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PayStack.Net;
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
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string token;
        private PayStackApi Paystack { get; set; }

        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
            token = _configuration["Payment:PaystackSK"];
            Paystack = new PayStackApi(token);
        }


        [HttpGet]
        public async Task<IActionResult> MakePayment(int Id)
        {
             PaymentViewModel getUser = new PaymentViewModel();
            string token = HttpContext.Session.GetString("token");
            string url = "https://sjx-logistics-api.herokuapp.com/api/Orders/getOrder/" + Id;
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            string apiResponse = await response.Content.ReadAsStringAsync();
                            getUser = JsonConvert.DeserializeObject<PaymentViewModel>(apiResponse);


                        }
                        else
                        {
                            throw new Exception(response.ReasonPhrase);
                        }
                        return View(getUser);
                    }

            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> MakePayment(PaymentViewModel model)
        {
            TransactionInitializeRequest request = new()
            {
                AmountInKobo = (int)Convert.ToDouble(model.Charges) * 100,
                Email = model.Email,
                Reference = Generate(),
                Currency = "NGN",
                CallbackUrl = "https://localhost:44386/Payment/Verify"
            };
            TransactionInitializeResponse response = Paystack.Transactions.Initialize(request);
            if (response.Status)
            {
                var transaction = new PaymentViewModel()
                {
                    Charges = (int)Convert.ToDouble(model.Charges),
                    Email = model.Email,
                    TrsRef = request.Reference,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Categories = model.Categories

                };
                await SendData(transaction);
                return Redirect(response.Data.AuthorizationUrl);

            }
            ViewData["error"] = response.Message;
            return View();

        }


        [HttpGet]
        public async Task<IActionResult> Verify(PaymentViewModel model)
        {
            TransactionVerifyResponse response = Paystack.Transactions.Verify(model.reference);
            if (response.Data.Status == "success")
            {
                await VerifyLink(model);
                return RedirectToAction("CompletePayment");
            }
            
            ViewData["error"] = response.Data.GatewayResponse;
            return RedirectToAction("MakePayment");
        }
    



        [HttpGet]
        public async Task<IActionResult> FilterPayment(DateTime ? startdate, DateTime ? enddate)

        {
            string token = HttpContext.Session.GetString("token");
            Response<IEnumerable<PaymentViewModel>> users = null;
            string url = "https://sjx-logistics-api.herokuapp.com/api/Payment/SearchData?startdate=" + startdate + "&&enddate=" + enddate ;


            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<Response<IEnumerable<PaymentViewModel>>>(apiResponse);



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
        public async Task<IActionResult> AllPayment()

        {
            string token = HttpContext.Session.GetString("token");
            Response<IEnumerable<PaymentViewModel>> users = null;
            string url = "https://sjx-logistics-api.herokuapp.com/api/Payment/AllTransaction";


            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<Response<IEnumerable<PaymentViewModel>>>(apiResponse);



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
        public async Task<IActionResult> CompletePayment()
        
        {
            string token = HttpContext.Session.GetString("token");
            Response<IEnumerable<PaymentViewModel>> users = null;
            string url = "https://sjx-logistics-api.herokuapp.com/api/Payment/completeTransaction";


            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<Response<IEnumerable<PaymentViewModel>>>(apiResponse);



                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }

                    return View(users.Data);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> VerifyLink(PaymentViewModel model)
        {
            PaymentViewModel registerModel = new PaymentViewModel();
            string token = HttpContext.Session.GetString("token");

            if (ModelState.IsValid)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string url = "https://sjx-logistics-api.herokuapp.com/api/Payment/VerifyPayment";
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            string apiResponse = await response.Content.ReadAsStringAsync();
                            registerModel = JsonConvert.DeserializeObject<PaymentViewModel>(apiResponse);
                         
                        }
                        else
                        {
                            throw new Exception(response.ReasonPhrase);
                        }

                    }
                }

                TempData["message"] = "User Updated Created!";
                ModelState.Clear();
         
            }
            return View(registerModel);
        }
    public static string Generate()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            return rand.Next(100000000, 999999999).ToString();
        }

        [HttpPost]
        public async Task<IActionResult> SendData(PaymentViewModel model)
          {
            PaymentViewModel registerModel = new PaymentViewModel();
            string token = HttpContext.Session.GetString("token");

            if (ModelState.IsValid)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string url = "https://sjx-logistics-api.herokuapp.com/api/Payment/MakePayment/";
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            string apiResponse = await response.Content.ReadAsStringAsync();
                            registerModel = JsonConvert.DeserializeObject<PaymentViewModel>(apiResponse);
                        }
                        else
                        {
                            throw new Exception(response.ReasonPhrase);
                        }

                    }
                }

                TempData["message"] = "User Updated Created!";
                ModelState.Clear();

              
            }


            return View(registerModel);



        }

    }

}



