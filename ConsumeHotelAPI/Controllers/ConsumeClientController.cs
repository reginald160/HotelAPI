using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ConsumeHotelAPI.Helper;
using HotelAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeHotelAPI.Controllers
{
    public class ConsumeClientController : Controller
    {
        HelperAPI _api = new HelperAPI();
        public async Task<IActionResult> Index()
        {
            List<Hotel> _hotels = new List<Hotel>();
            HttpClient Client = _api.Initial(); // To get the initialization from thr domain
            HttpResponseMessage res = await Client.GetAsync("api/hotel2");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;

                _hotels = JsonConvert.DeserializeObject<List<Hotel>>(result);

            }
            return View(_hotels);
        }
    }
}
