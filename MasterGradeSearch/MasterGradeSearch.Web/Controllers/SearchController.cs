using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MasterGradeSearch.Core;
using MasterGradeSearch.Core.Commons;
using MasterGradeSearch.Web.Models;

namespace MasterGradeSearch.Web.Controllers
{
    /// <summary>
    ///     Контроллер поиска. Контроллер, который заполняет формы фильтров для пользователя. После того, как пользователь
    ///     заполнил фильтры, обрабатывает их, формирует объект типа CourseFilterProperties - и отправляет его в Calculation.cs
    ///     Этот контроллер можно назвать "Модулем обработки данных"
    /// </summary>
    public class SearchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext(); // Связь с модулем взаимодействия с базой данных

        // Основная страница поиска. Происходит заполнение фильтров информацией из базы данных
        public async Task<ActionResult> Index()
        {
            var cities = await db.Cities.ToListAsync();
            var districts = await db.Districts.ToListAsync();
            var disciplines = await db.Disciplines.ToListAsync();
            var exams = await db.Exams.ToListAsync();
            var model = new SearchViewModel
            {
                CitiesSelectList = new List<SelectListItem>(),
                FindedCourses = new List<SearchCourseViewModel>(),
                DisciplinesSelectList = new List<SelectListItem>(),
                DistinctsSelectList = new List<SelectListItem>(),
                ExamsSelectList = new List<SelectListItem>()
            };
            foreach (var city in cities)
            {
                var selectItem = new SelectListItem();
                selectItem.Text = city.Name;
                selectItem.Value = city.Id.ToString();
                model.CitiesSelectList.Add(selectItem);
            }

            foreach (var discipline in disciplines)
            {
                var selectItem = new SelectListItem();
                selectItem.Text = discipline.Name;
                selectItem.Value = discipline.Id.ToString();
                model.DisciplinesSelectList.Add(selectItem);
            }

            foreach (var district in districts)
            {
                var selectItem = new SelectListItem();
                selectItem.Text = district.Name;
                selectItem.Value = district.Id.ToString();
                model.DistinctsSelectList.Add(selectItem);
            }

            foreach (var exam in exams)
            {
                var selectItem = new SelectListItem();
                selectItem.Text = exam.Name;
                selectItem.Value = exam.ExamId.ToString();
                model.ExamsSelectList.Add(selectItem);
            }


            return View(model);
        }

        // POST запрос, который срабатывает после того, как пользователь нажал кнопку "ИСКАТЬ"
        // Здесь информация с формы преобразуется в объект типа CourseFilterProperties.cs
        // Ниже в методе можешь увидеть комментарий, где непосредственно происходит расчет.
        // Данные из форм со страницы, попадают в параметр SearchViewModel searchView, с помощью
        // Специального преобразователя SearchBinder (вот тут моя кровь и пролилась). Если тебе нужно - посмотри описание этого класса. Он находится в корне проекта Web
        [HttpPost]
        public async Task<ActionResult> Index([ModelBinder(typeof(SearchBinder))] SearchViewModel searchView)
        {
            var ratios = await db.CriterionRatios.Include(c=>c.CriterionSource).Include(c=>c.CriterionDestination).ToListAsync();
            var courses = await db.Courses.Include(c=>c.Exams).Include(c=>c.Institute).Include(c=>c.Discipline).Include(c=>c.Institute.District).ToListAsync();
            var calc = new Calculation(ratios);

            var filter = new CourseFilterProreties();
            filter.Budget = searchView.Budget;
            filter.Disciplines = searchView.Disciplines;
            filter.Districts = searchView.Districts;
            filter.Extrabudget = searchView.ExtraBudget;
            filter.PreparatoryCourses = searchView.PreparationCourses;
            filter.Exams = searchView.Exams;
            filter.Cost = searchView.Cost;
            filter.Hostel = searchView.Hostel;
            filter.LearningTypes=new List<LearningType>();
            if (searchView.FullTime)
            {
                filter.LearningTypes.Add(LearningType.FullTime);
            }
            if (searchView.DistanceLearning)
            {
                filter.LearningTypes.Add(LearningType.DistanceLearning);
            }

            var model = new SearchViewModel
            {
                CitiesSelectList = new List<SelectListItem>(),
                FindedCourses = new List<SearchCourseViewModel>(),
                DisciplinesSelectList = new List<SelectListItem>(),
                DistinctsSelectList = new List<SelectListItem>(),
                ExamsSelectList = new List<SelectListItem>()
            };

            foreach (var course in courses)
            {
                if(!filter.Disciplines.Any(d=>d.Id==course.Discipline.Id))
                    continue;
                var doubles=calc.GetCoefOfCourse(filter, course, courses); // ЗДЕСЬ ПРОИСХОДИТ РАСЧЕТ КОЭФФИЦИЕНТА ПО ДАННЫМ ФИЛЬТРА
                var searchCourseViewModel = new SearchCourseViewModel();
                searchCourseViewModel.Course = course;
                searchCourseViewModel.SearchCoef = doubles;
                model.FindedCourses.Add(searchCourseViewModel);
            }

            model.FindedCourses=model.FindedCourses.OrderBy(o => o.SearchCoef).Reverse().ToList();


            var cities = await db.Cities.ToListAsync();
            var districts = await db.Districts.ToListAsync();
            var disciplines = await db.Disciplines.ToListAsync();
            var exams = await db.Exams.ToListAsync();

            foreach (var city in cities)
            {
                var selectItem = new SelectListItem();
                selectItem.Text = city.Name;
                selectItem.Value = city.Id.ToString();
                model.CitiesSelectList.Add(selectItem);
            }

            foreach (var discipline in disciplines)
            {
                var selectItem = new SelectListItem();
                selectItem.Text = discipline.Name;
                selectItem.Value = discipline.Id.ToString();
                model.DisciplinesSelectList.Add(selectItem);
            }

            foreach (var district in districts)
            {
                var selectItem = new SelectListItem();
                selectItem.Text = district.Name;
                selectItem.Value = district.Id.ToString();
                model.DistinctsSelectList.Add(selectItem);
            }

            foreach (var exam in exams)
            {
                var selectItem = new SelectListItem();
                selectItem.Text = exam.Name;
                selectItem.Value = exam.ExamId.ToString();
                model.ExamsSelectList.Add(selectItem);
            }


            return View(model);
        }

    }
}