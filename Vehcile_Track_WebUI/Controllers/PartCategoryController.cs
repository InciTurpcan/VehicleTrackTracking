using Dtos.PartCategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Vehcile_Track_WebUI.Controllers
{
    public class PartCategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PartCategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7197/api/PartCategories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPartCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public IActionResult CreatePartCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartCategory([FromForm] CreatePartCategoryDto createPartCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createPartCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7197/api/PartCategories", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "PartCategory");
            }
            return View();

        }

        public async Task<IActionResult> DeletePartCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7197/api/PartCategories/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "PartCategory");
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdatePartCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7197/api/PartCategories/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdatePartCategoryDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePartCategory(UpdatePartCategoryDto updatePartCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updatePartCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7197/api/PartCategories/{updatePartCategoryDto.PartCategoryId}", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "PartCategory");
            }
            return View();
        }
    }
}
