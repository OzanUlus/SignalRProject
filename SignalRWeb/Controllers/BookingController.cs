using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWeb.Dtos.BookingDtos;
using System.Text;

namespace SignalRWeb.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7233/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto  createBookingDto)
        {
            createBookingDto.Description = "Rezervasyon Alındı";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7233/api/Booking", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7233/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7233/api/Booking/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(value);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto )
        {
            updateBookingDto.Description = "Rezarvasyon Güncellendi";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMassage = await client.PutAsync("https://localhost:7233/api/Booking", stringContent);
            if (responseMassage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();


        }
        public async Task<IActionResult> BookingApprove(int id) 
        {
            var client = _httpClientFactory.CreateClient();
             await client.GetAsync($"https://localhost:7233/api/Booking/BookingApprove/{id}");
            return RedirectToAction("Index");
           
        }
        public async Task<IActionResult> BookingCancel(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7233/api/Booking/BookingCancel/{id}");
            return RedirectToAction("Index");

        }

    }
    
}
