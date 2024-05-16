using Dtos.PartDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dtos.PartCategoryDtos;

namespace Vehcile_Track_WebUI.Controllers
{
    public class PartController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PartController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7197/api/Parts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<PartDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreatePart()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7197/api/PartCategories");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultPartCategoryDto>>(jsonData);
            List<SelectListItem> partCategories = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.PartCategoryName,
                                                       Value = x.PartCategoryId.ToString()
                                                   }).ToList();
            ViewBag.partCategories = partCategories;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePart([FromForm] CreatePartDto createPartDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createPartDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7197/api/Parts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "Part");
            }
            return View();

        }

        public async Task<IActionResult> DeletePart(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7197/api/Parts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Part");
            }
            return View();

        }

        [HttpGet]

        public async Task<IActionResult> UpdatePart(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7197/api/PartCategories");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultPartCategoryDto>>(jsonData);
            List<SelectListItem> partCategories = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.PartCategoryName,
                                                       Value = x.PartCategoryId.ToString()
                                                   }).ToList();
            ViewBag.partCategories = partCategories;

            
           
            var responseMessage2 = await client.GetAsync($"https://localhost:7197/api/Parts/{id}");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<UpdatePartDto>(jsonData2);
                return View(values2);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePart(UpdatePartDto updatePartDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updatePartDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7197/api/Parts/{updatePartDto.PartId}", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "Part");
            }
            return View();
        }
    }

}
