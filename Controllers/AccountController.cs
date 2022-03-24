using Google.Api;
using Google.Api.Gax.Grpc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sjx_Mvc.Models;
using Sjx_Mvc.ViewModels;
using SjxLogistics.Components;
using SjxLogistics.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sjx_Mvc.Controllers
{
    public class AccountController : Controller
    {

        public  ActionResult Logout()
        {

         
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }


        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                string url = "https://sjx-logistics-api.herokuapp.com/api/Authentication/Login";
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
        public IActionResult Register()
        {
            return View();
        }


        [HttpGet]
        public IActionResult CreateRider()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateRider(RegisterViewModel model)
        {
            string successMessage = "User Created Successfully";
            RegisterViewModel registerModel = new RegisterViewModel();
            string token = HttpContext.Session.GetString("token");
            if (ModelState.IsValid)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string url = "https://sjx-logistics-api.herokuapp.com/api/Admin/rider/create";
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    using (var response = await httpClient.PostAsync(url, content))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            registerModel = JsonConvert.DeserializeObject<RegisterViewModel>(apiResponse);
                            TempData["successMessage"] = successMessage;
                            ModelState.Clear();
                            model.Email = "";
                            model.FirstName = "";
                            model.LastName = "";
                            model.Address = "";
                            model.PhoneNumber = "";


                        }
                        else
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            Response<RegisterViewModel> resp = JsonConvert.DeserializeObject<Response<RegisterViewModel>>(apiResponse);
                            throw new Exception(response.ReasonPhrase);
                            TempData["errorMessage"] = resp.Messages;
                            return View(model);

                        }
                    }

                }
            }


            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            string successMessage = "User Created Successfully";
            RegisterViewModel registerModel = new RegisterViewModel();
            string token = HttpContext.Session.GetString("token");
            if (ModelState.IsValid)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string url = "https://sjx-logistics-api.herokuapp.com/api/Admin/admin/create";
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization =new AuthenticationHeaderValue("Bearer", token);
                    using (var response = await httpClient.PostAsync(url, content))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            registerModel = JsonConvert.DeserializeObject<RegisterViewModel>(apiResponse);
                            TempData["successMessage"] = successMessage;
                            ModelState.Clear();
                            model.Email = "";
                            model.FirstName = "";
                            model.LastName = "";
                            model.Address= "";
                            model.PhoneNumber = "";
                           

                        }
                        else
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            Response<RegisterViewModel> resp = JsonConvert.DeserializeObject<Response<RegisterViewModel>>(apiResponse);
                            throw new Exception(response.ReasonPhrase);
                            TempData["errorMessage"] = resp.Messages;
                            return View(model);
                           
                        }
                    }

                }
            }
           

            return View(model);
        }

        [HttpGet]
        public IActionResult RegisterEmpolyee()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }


       
        [HttpGet]
        public async Task<IActionResult> DeleteUser(int Id)
        {

            Response<ViewUserModel> getUser = null;

            string url = "https://sjx-logistics-api.herokuapp.com/api/Report/";


            url += $"User/{Id}";
            using (var httpClient = new HttpClient())
            {
                //httpClient.he
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        getUser = JsonConvert.DeserializeObject<Response<ViewUserModel>>(apiResponse);


                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                    return View(getUser.Data);
                }
            }
        }
  

[HttpPost]
        public async Task<IActionResult> DeleteUser( int Id, ViewUserModel model)
        {
            ViewUserModel registerModel = new ViewUserModel();
            string token = HttpContext.Session.GetString("token");
            if (ModelState.IsValid)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string url = "https://sjx-logistics-api.herokuapp.com/api/Report/deleteUser/" + Id;
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            string apiResponse = await response.Content.ReadAsStringAsync();
                            registerModel = JsonConvert.DeserializeObject<ViewUserModel>(apiResponse);
                        }
                        else
                        {
                            throw new Exception(response.ReasonPhrase);
                        }

                    }
                }
            
                TempData["message"] = "User Deleted Successfully!";
                ModelState.Clear();

                return RedirectToAction("GetUsers");
            }


            return View(registerModel);



        }
        [HttpPost]
        public async Task<IActionResult> Update(int Id, ViewUserModel model)
        {
            ViewUserModel registerModel = new ViewUserModel();
            string token = HttpContext.Session.GetString("token");
            if (ModelState.IsValid)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string url = "https://sjx-logistics-api.herokuapp.com/api/Report/updateUser/" + Id;
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            string apiResponse = await response.Content.ReadAsStringAsync();
                            registerModel = JsonConvert.DeserializeObject<ViewUserModel>(apiResponse);
                        }
                        else
                        {
                            throw new Exception(response.ReasonPhrase);
                        }

                    }
                }

                TempData["message"] = "User Updated Created!";
                ModelState.Clear();

                return RedirectToAction("GetUsers");
            }


            return View(registerModel);



        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordview model)
        {
            ChangePasswordview changepassword = new ChangePasswordview();
            string token = HttpContext.Session.GetString("token");
            if (ModelState.IsValid)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                string url = "https://sjx-logistics-api.herokuapp.com/api/Report/changePassword";
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {

                            string apiResponse = await response.Content.ReadAsStringAsync();
                            changepassword = JsonConvert.DeserializeObject<ChangePasswordview>(apiResponse);
                        }
                        else
                        {
                            throw new Exception(response.ReasonPhrase);
                        }

                    }
                }

                TempData["message"] = "User Updated Created!";
                ModelState.Clear();

                return RedirectToAction("GetUsers");
            }


            return View(changepassword);



        }


        [HttpGet]

        public async Task<IActionResult> GetUsers()
        {

            Response<IEnumerable<ViewUserModel>> users = null;
            string token = HttpContext.Session.GetString("token");
            string url = "https://sjx-logistics-api.herokuapp.com/api/Report/getAllUsers";

            
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<Response<IEnumerable<ViewUserModel>>>(apiResponse);


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
        public async Task<IActionResult> Search(string search)
        {
            string token = HttpContext.Session.GetString("token");
            Response<IEnumerable<ViewUserModel>> users = null;
            string url = "https://sjx-logistics-api.herokuapp.com/api/Report/Search/" + search;

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<Response<IEnumerable<ViewUserModel>>>(apiResponse);
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
        public async Task<IActionResult> UserDetail(int Id)
        {

            Response<ViewUserModel> getUser = null;
            string token = HttpContext.Session.GetString("token");

            string url = "https://sjx-logistics-api.herokuapp.com/api/Report/";

           
               url += $"User/{Id}";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        getUser = JsonConvert.DeserializeObject<Response<ViewUserModel>>(apiResponse);


                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                    return View(getUser.Data);
                }
            }
        }
    }
}
