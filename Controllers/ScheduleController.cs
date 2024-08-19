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

        public IActionResult Index()
        {
            IEnumerable<Schedule> objList = _db.Schedules;
            return View(objList);
        }

    }
}
