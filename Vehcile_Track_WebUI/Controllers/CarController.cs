using Dtos.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Vehcile_Track_WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7197/api/Cars");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CarDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        
        public async Task<IActionResult> CarDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7197/api/Cars/GetOneCarWithParts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarWithPartsDto>(jsonData);
                return View(values);
            }
            return View();
        }
      
       
        [HttpGet]
        public IActionResult CreateCar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromForm] CreateCarDto createCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7197/api/Cars", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index","Car");
            }
            return View();

        }

        public async Task<IActionResult> DeleteCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7197/api/Cars/{id}" );
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Car");
            }
            return View();

        }

        [HttpGet]

        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7197/api/Cars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7197/api/Cars/{updateCarDto.CarId}", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                
                return RedirectToAction("Index","Car");
            }
            return View();
        }
    }
}
