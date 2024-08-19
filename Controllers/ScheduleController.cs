using LightInEveryHouse.Data;
using LightInEveryHouse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LightInEveryHouse.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ApiDbContext _db;
        public ScheduleController(ApiDbContext db)
        {
            _db = db;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}


        // Метод для відображення списку графіків
        public IActionResult Index(string addressFilter)
        {
            IEnumerable<Schedule> schedules = null;

            if (!string.IsNullOrEmpty(addressFilter))
            {
                schedules = _db.Schedules
                    .Include(s => s.Address)
                    .Where(s => s.Address.StreetAddress.ToLower().Contains(addressFilter.ToLower()))
                    .ToList();
            }

            ViewData["AddressFilter"] = addressFilter;
            return View(schedules);
        }

        // Метод для отримання пропозицій адрес
        [HttpGet]
        public JsonResult GetAddressSuggestions(string term)
        {
            var suggestions = _db.Addresses
                .Where(a => a.StreetAddress.ToLower().Contains(term.ToLower()))
                .Select(a => a.StreetAddress) // Повертаємо лише рядки адрес
                .ToList();

            return Json(suggestions);
        }

    }
}
