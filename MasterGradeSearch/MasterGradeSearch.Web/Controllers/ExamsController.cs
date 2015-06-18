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
    /// <summary>
    ///     Вступительные испытания. Аналогично городам. Смотри CitiesController.cs, только вместо городов Вступительные испытания.
    /// </summary>
    public class ExamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Exams
        public async Task<ActionResult> Index()
        {
            var exams = await db.Exams.ToListAsync();
            var model = new ExamViewModel();
            model.Exams = exams;
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Exam")] ExamViewModel examView)
        {
            if (ModelState.IsValid)
            {
                db.Exams.Add(examView.Exam);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(examView);
        }
    }
}