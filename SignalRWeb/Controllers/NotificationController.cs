using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWeb.Dtos.NotificationDtos;
using System.Text;

namespace SignalRWeb.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.GetAsync("https://localhost:7233/api/Notification/ListNotification");
            if (responseMassage.IsSuccessStatusCode)
            {
              var jsonData = await responseMassage.Content.ReadAsStringAsync();
                var datas = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);
                return View(datas);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateNotification() 
        {
          return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
        {
            createNotificationDto.Status = false;
            createNotificationDto.Date = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createNotificationDto);
            StringContent content = new StringContent(jsonData , Encoding.UTF8 , "application/json");
            var responseMassage = await client.PostAsync("https://localhost:7233/api/Notification", content);
            if (responseMassage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMassage = await client.DeleteAsync($"https://localhost:7233/api/Notification/{id}");
            if (responseMassage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id)
        {
    
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7233/api/Notification/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsonData);
                return View(value);
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateNotificationDto updateNotificationDto )
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateNotificationDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7233/api/Notification", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        
        public async Task<IActionResult> NotificationStatusChangeTrue(int id)
        {

            var client = _httpClientFactory.CreateClient();
             await client.GetAsync($"https://localhost:7233/api/Notification/NotificationStatusChangeToTrue/{id}");
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> NotificationStatusChangeFalse(int id)
        {

            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7233/api/Notification/NotificationStatusChangeToFalse/{id}");
            return RedirectToAction("Index");

        }
    }
}
