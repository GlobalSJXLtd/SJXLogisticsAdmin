using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class EmployeeController : Controller
    {

        [HttpGet]
        public IActionResult RegisterEmployee()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> RegisterEmployee(EmployeeView model)
        {
            string successMessage = "User Created Successfully";
            EmployeeView registerModel = new EmployeeView();
            string token = HttpContext.Session.GetString("token");
            if (ModelState.IsValid)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string url = "https://sjx-logistics-api.herokuapp.com/api/Employee/createEmployee";
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    using (var response = await httpClient.PostAsync(url, content))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            registerModel = JsonConvert.DeserializeObject<EmployeeView>(apiResponse);
                            TempData["successMessage"] = successMessage;
                            ModelState.Clear();
                          

                        }
                        else
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            Response<EmployeeView> resp = JsonConvert.DeserializeObject<Response<EmployeeView>>(apiResponse);
                            TempData["errorMessage"] = resp.Messages;
                            return View(model);

                        }
                    }

                }
            }

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(EmployeeLoginView model)
        {

            if (ModelState.IsValid)
            {
                string url = "https://sjx-logistics-api.herokuapp.com/api/Employee/employeelogin";
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {

                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Response<User> resp = JsonConvert.DeserializeObject<Response<User>>(apiResponse);
                        if (resp.Success)
                        {
                            HttpContext.Session.SetString("Name", resp.Data.FirstName.ToString());
                            HttpContext.Session.SetString("Last", resp.Data.LastName.ToString());
                            HttpContext.Session.SetString("UserId", resp.Data.Id);
                            HttpContext.Session.SetString("Email", resp.Data.Email.ToString());
                            HttpContext.Session.SetString("RoleId", resp.Data.RoleId.ToString());
                            HttpContext.Session.SetString("token", resp.tokken.ToString());

                            return RedirectToAction("dashboard", "dashboard");
                        }
                        else if (!resp.Success)
                        {
                            ModelState.AddModelError(string.Empty, "Invalid Email or Password");
                            return View(model);

                        }
                        ModelState.AddModelError(string.Empty, resp.Messages);
                    }
                }

            }
            return View(model);
        }


        [HttpGet]

        public async Task<IActionResult> GetEmployees()
        {

            Response<IEnumerable<EmployeeView>> users = null;
            string url = "https://sjx-logistics-api.herokuapp.com/api/Employee/getAllEmployees";


            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<Response<IEnumerable<EmployeeView>>>(apiResponse);


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
