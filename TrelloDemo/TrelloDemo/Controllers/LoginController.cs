using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrelloDemo.Models;
using TrelloDemoAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace TrelloDemo.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserModel user)
        {
            var value = Authenticate(user);
           
            if (value != false)
            {
                var httpClient = new HttpClient();
                var jsonUser = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PostAsync("https://localhost:7153/api/Login/",content);
                var token = await responseMessage.Content.ReadAsStringAsync();

                HttpContext.Session.SetString("token", token);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName)
                };
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        private bool Authenticate(UserModel user)
        {

            if (user.UserName == "admin" && user.Password == "1234")
            {
                return true;
            }

            return false;
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
