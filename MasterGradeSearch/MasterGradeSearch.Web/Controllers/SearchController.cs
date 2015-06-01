using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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
            var cities = await db.Cities.ToListAsync();
            var model = new SearchViewModel { CitiesSelectList = new List<SelectListItem>(), FindedCourses = new List<Course>() };
            foreach (var city in cities)
            {
                var selectItem = new SelectListItem();
                selectItem.Text = city.Name;
                selectItem.Value = city.Id.ToString();
                model.CitiesSelectList.Add(selectItem);
            }
            
            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadDistinctsByCity(string cityId)
        {
            //Your Code For Getting Physicans Goes Here
            if (string.IsNullOrEmpty(cityId))
            {
                return Json(new List<SelectListItem>(), JsonRequestBehavior.AllowGet);
            }
            var intCityId = Int32.Parse(cityId);
            var districts = db.Districts.Where(d=>d.CityId==intCityId).ToList();


            var phyData = districts.Select(m => new SelectListItem()
            {
                Text = m.Name,
                Value = m.Id.ToString(),
            });
            return Json(phyData, JsonRequestBehavior.AllowGet);
        }
    }
}