﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MasterGradeSearch.Core.Commons;
using MasterGradeSearch.Web.Models;

namespace MasterGradeSearch.Web.Controllers
{
    /// <summary>
    ///     Вузы. Аналогично городам. Смотри CitiesController.cs, только вместо городов вузы
    /// </summary>
    public class InstitutesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Institutes
        public async Task<ActionResult> Index()
        {
            var institutes = db.Institutes.Include(i => i.City).Include(i => i.District);

            var model = new InstitutesViewModel();
            model.SelectedInstitute=new Institute();
            model.AllInstitutes = await db.Institutes.Include(i => i.City).Include(i => i.District).ToListAsync();

            return View(model);
        }

        // GET: Institutes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var courses = await db.Courses.Include(i => i.Discipline).Where(i => i.InstituteId == id).Include(i=>i.Exams).ToArrayAsync();
            Institute institute = await db.Institutes.Include(i => i.City).Include(i => i.District).SingleOrDefaultAsync(i=>i.Id==id);
            if (institute == null)
            {
                return HttpNotFound();
            }
            institute.Courses = courses;
            return View(institute);
        }

        // GET: Institutes/Create
        public ActionResult Create()
        {
            
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name");
            return View();
        }

        // POST: Institutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ShortName,FullName,CityId,DistrictId,Description,ImageBase64")] Institute institute)
        {
            if (ModelState.IsValid)
            {
                db.Institutes.Add(institute);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", institute.CityId);
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name", institute.DistrictId);
            return View(institute);
        }

        // GET: Institutes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institute institute = await db.Institutes.FindAsync(id);
            if (institute == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", institute.CityId);
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name", institute.DistrictId);
            return View(institute);
        }

        // POST: Institutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ShortName,FullName,CityId,DistrictId")] Institute institute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(institute).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", institute.CityId);
            ViewBag.DistrictId = new SelectList(db.Districts, "Id", "Name", institute.DistrictId);
            return View(institute);
        }


        public async Task<ActionResult> CreateCourse(int instututeId)
        {
            ViewBag.DisciplineId = new SelectList(db.Disciplines, "Id", "Name");
            var result=  await db.Institutes.FirstAsync(i => i.Id == instututeId);
            var examsList = await db.Exams.ToListAsync();
            List<SelectListItem> selectExamsList=new List<SelectListItem>();
            foreach (var exam in examsList)
            {
                var item = new SelectListItem();
                item.Value = exam.ExamId.ToString();
                item.Text = exam.Name;
                selectExamsList.Add(item);
            }
            ViewBag.InstituteName = result.ShortName;
            ViewBag.InstituteId = instututeId;
            var course = new CourseViewModel();
            course.InstituteId = instututeId;
            ViewBag.ExamsList = selectExamsList;
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCourse([Bind(Include = "Id, Institute, DisciplineId,LearningType,PreparatoryCourses,Hostel,Budget,Extrabudgetary,Cost,ExamsIds")] CourseViewModel course)
        {
            course.InstituteId = Int32.Parse(HttpContext.Request.QueryString[0]);
            if (ModelState.IsValid)
            {
                foreach (var id in course.ExamsIds)
                {
                    var ex = db.Exams.FirstOrDefault(d => d.ExamId == id.Value);
                    if (course.Exams == null)
                    {
                        course.Exams=new Collection<Exam>();
                    }
                    course.Exams.Add(ex);
                }
            
                db.Courses.Add(course);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DisciplineId = new SelectList(db.Disciplines, "Id", "Name");
            var result = await db.Institutes.FirstAsync(i => i.Id == course.InstituteId);
            ViewBag.InstituteName = result.ShortName;
            return View(course);
        }
        
        // GET: Institutes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Institute institute = await db.Institutes.FindAsync(id);
            if (institute == null)
            {
                return HttpNotFound();
            }
            return View(institute);
        }

        // POST: Institutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Institute institute = await db.Institutes.FindAsync(id);
            db.Institutes.Remove(institute);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
