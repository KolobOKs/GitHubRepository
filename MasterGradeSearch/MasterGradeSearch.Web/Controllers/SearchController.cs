using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MasterGradeSearch.Core.Commons;
using MasterGradeSearch.Web.Models;

namespace MasterGradeSearch.Web.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Search
        public async Task<ActionResult> Index()
        {
            var model = new SearchViewModel {Cities = await db.Cities.ToListAsync(), FindedCourses = new List<Course>()};
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadPhysiansByDepartment(string deptId)
        {
            //Your Code For Getting Physicans Goes Here
            var districts = db.Districts.ToList();


            var phyData = districts.Select(m => new SelectListItem()
            {
                Text = m.Name,
                Value = m.Id.ToString(),
            });
            return Json(phyData, JsonRequestBehavior.AllowGet);
        }
    }
}