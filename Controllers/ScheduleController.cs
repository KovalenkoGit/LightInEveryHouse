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

        // Метод для відображення списку графіків
        public IActionResult Index(string addressFilter)
        {
            IEnumerable<Schedule> objList = _db.Schedules
                .Include(s => s.Address);

            if (!string.IsNullOrEmpty(addressFilter))
            {
                objList = objList.Where(s => s.Address != null &&
                                              s.Address.StreetAddress.Contains(addressFilter));
            }

            return View(objList.ToList());
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
