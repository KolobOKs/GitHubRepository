using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MasterGradeSearch.Web.Models;

namespace MasterGradeSearch.Web.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Search
        public async Task<ActionResult> Index()
        {
            var courses= await db.Courses.Include(c=>c.Institute).Include(c=>c.Discipline).Include(c=>c.Exams).ToListAsync();
            var model = new SearchViewModel();
            model.FindedCourses = courses;
            return View(model);
        }
    }
}