using Infinite.MVCCore.Taxibooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infinite.MVCCore.Taxibooking.Controllers
{
    public class BookingsController : Controller
    {
        //private string ApiUrl = "https://localhost:44313/api/";
        private readonly IConfiguration _configuration;

        public BookingsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            List<BookingViewModel> bookings = new();
            using (var client= new HttpClient())
            {
              
                client.BaseAddress= new System.Uri(_configuration["ApiUrl:api"]);
                 var result= await client.GetAsync("Bookings/GetAllBookings");
                if(result.IsSuccessStatusCode) 
                { 
                    bookings = await result.Content.ReadAsAsync<List<BookingViewModel>>();
                }
            }
            return View(bookings);
        }
        
    }
}
