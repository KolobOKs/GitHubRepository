using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using MasterGradeSearch.Core.Commons;

namespace MasterGradeSearch.Web.Models
{
    /// <summary>
    ///     Модель для представления данных для страницы поиска
    /// </summary>
    public class SearchViewModel
    {
        public List<City> Cities { get; set; }
        public List<District> Districts { get; set; }
        public List<Discipline> Disciplines { get; set; }
        public List<Exam> Exams { get; set; }

        public List<SearchCourseViewModel> FindedCourses { get; set; }


        public List<SelectListItem> CitiesSelectList { get; set; }
        public List<SelectListItem> DistinctsSelectList { get; set; }
        public List<SelectListItem> DisciplinesSelectList { get; set; }
        public List<SelectListItem> ExamsSelectList { get; set; } 


        public bool Hostel { get; set; }
        public bool PreparationCourses { get; set; }
        public bool Budget { get; set; }
        public bool ExtraBudget { get; set; }
        public bool FullTime { get; set; }
        public bool DistanceLearning { get; set; }
        public decimal Cost { get; set; }
    }

    public class SearchCourseViewModel 
    {
        public Course Course { get; set; }
        public double SearchCoef { get; set; }
    }
}