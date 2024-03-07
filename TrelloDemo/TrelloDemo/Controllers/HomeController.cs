using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using TrelloDemo.Models;

namespace TrelloDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();

            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var responseMessageListe = await httpClient.GetAsync("https://localhost:7153/api/Liste/ListListe");
            var jsonStringListe = await responseMessageListe.Content.ReadAsStringAsync();
            ViewBag.Liste = JsonConvert.DeserializeObject<List<ListeModel>>(jsonStringListe);

            var responseMessageKart = await httpClient.GetAsync("https://localhost:7153/api/Kart/ListKart");
            var jsonStringKart = await responseMessageKart.Content.ReadAsStringAsync();
            ViewBag.Kart = JsonConvert.DeserializeObject<List<KartModel>>(jsonStringKart);

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddListe(ListeModel p)
        {
            if (p.ListeAdi != null)
            {
                var httpClient = new HttpClient();

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                var jsonEmployee = JsonConvert.SerializeObject(p);
                StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PostAsync("https://localhost:7153/api/Liste/AddListe", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    _logger.LogError(p.ListeAdi+" adlı liste eklendi");
                    return Json(new
                    {
                        redirectUrl = Url.Action("Index", "Home"),
                        isRedirect = true
                    });
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateListe(ListeModel p)
        {
            if (p.ListeAdi != null)
            {
                var httpClient = new HttpClient();

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                var jsonEmployee = JsonConvert.SerializeObject(p);
                var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PutAsync("https://localhost:7153/api/Liste/UpdateListe", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    _logger.LogError(p.ListeAdi + " adlı liste düzenlendi");
                    return Json(new
                    {
                        redirectUrl = Url.Action("Index", "Home"),
                        isRedirect = true
                    });
                }
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteListe(int id)
        {
            var httpClient = new HttpClient();

            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var responseMessage = await httpClient.DeleteAsync("https://localhost:7153/api/Liste/DeleteListe/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _logger.LogError(id + " idli liste silindi");
                return Json(new
                {
                    redirectUrl = Url.Action("Index", "Home"),
                    isRedirect = true
                });
            }
            return RedirectToAction("Index");
        }

       
        [HttpPost]
        public async Task<IActionResult> AddKart(KartModel p)
        {
            if (p.KartIcerik != null)
            {
                var httpClient = new HttpClient();

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                var jsonEmployee = JsonConvert.SerializeObject(p);
                StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PostAsync("https://localhost:7153/api/Kart/AddKart", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    _logger.LogError(p.KartIcerik + " içerikli kart eklendi");
                    return Json(new
                    {
                        redirectUrl = Url.Action("Index", "Home"),
                        isRedirect = true
                    });
                }
            }
                
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateKart(KartModel p)
        {
            if (p.KartIcerik != null)
            {
                var httpClient = new HttpClient();

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

                var jsonEmployee = JsonConvert.SerializeObject(p);
                var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
                var responseMessage = await httpClient.PutAsync("https://localhost:7153/api/Kart/UpdateKart", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    _logger.LogError(p.KartIcerik + " içerikli kart düzenlendi");
                    return Json(new
                    {
                        redirectUrl = Url.Action("Index", "Home"),
                        isRedirect = true
                    });
                }
            }
                
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteKart(int id)
        {
            var httpClient = new HttpClient();

            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var responseMessage = await httpClient.DeleteAsync("https://localhost:7153/api/Kart/DeleteKart/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _logger.LogError(id + " idli kart silindi");
                return Json(new
                {
                    redirectUrl = Url.Action("Index", "Home"),
                    isRedirect = true
                });
            }
            return RedirectToAction("Index");
        }

    }
}