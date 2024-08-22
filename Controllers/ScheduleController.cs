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
            IEnumerable<Schedule> schedules = null;

            if (!string.IsNullOrEmpty(addressFilter))
            {
                schedules = _db.Schedules
                    .Include(s => s.Address)
                    .Where(s => s.Address.StreetAddress.ToLower().Contains(addressFilter.ToLower()))
                    .OrderBy(s => s.DayNum)
                    .ThenBy(s => s.StartTime)
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
        // Метод для імпорту
        [HttpPost]
        public async Task<IActionResult> ImportTxt(IFormFile fileUpload)
        {
            ViewData["Message"] = null;

            if (fileUpload != null && fileUpload.Length > 0)
            {
                using (var reader = new StreamReader(fileUpload.OpenReadStream()))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Парсинг рядків з файлу
                        var parts = line.Split(';');
                        if (parts.Length == 4)
                        {
                            var schedule = new Schedule
                            {
                                // Дані з масиву parts записуємо в базу
                                DayNum = int.Parse(parts[0]),
                                Day = GetDayName(int.Parse(parts[0])),
                                StartTime = TimeSpan.Parse(parts[1]),
                                FinishTime = TimeSpan.Parse(parts[2]),
                                AddressId = int.Parse(parts[3]),
                            };
                            _db.Schedules.Add(schedule);
                            ViewData["Message"] = "Файл успішно завантажено.";
                            return View("Index");
                        }
                        else
                        {
                            ViewData["Message"] = "Файл має неправильний формат.";
                            return View("Index");
                        }
                    }
                    await _db.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index");
        }
        private string GetDayName(int dayNum)
        {
            switch (dayNum)
            {
                case 1:
                    return "Понеділок";
                case 2:
                    return "Вівторок";
                case 3:
                    return "Середа";
                case 4:
                    return "Четвер";
                case 5:
                    return "П'ятниця";
                case 6:
                    return "Субота";
                case 7:
                    return "Неділя";
                default:
                    return "Невідомий день";
            }
        }
    }
}
