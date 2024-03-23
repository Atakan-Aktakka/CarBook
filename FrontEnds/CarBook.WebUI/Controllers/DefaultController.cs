using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7004/api/Locations");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
            List<SelectListItem> values2= (from x in values
                select new SelectListItem
                {
                    Text = x.Name,
                    Value = x.LocationID.ToString()
                }).ToList();
            ViewBag.v = values2;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string  book_pick_date, string book_off_date, string time_pick, string time_off, string locationID)
        {
            TempData["book_pick_date"] = book_pick_date;
            TempData["book_off_date"] = book_off_date;
            TempData["time_pick"] = time_pick;
            TempData["time_off"] = time_off;
            TempData["locationID"] = locationID;
            return RedirectToAction("Index", "RentACarList");
        }
    }
}