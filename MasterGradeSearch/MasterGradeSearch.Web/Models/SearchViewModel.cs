using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using MasterGradeSearch.Core.Commons;

namespace MasterGradeSearch.Web.Models
{
    public class SearchViewModel
    {
        public List<City> Cities { get; set; }
        public List<District> Districts { get; set; } 
        public List<Course> FindedCourses { get; set; }
        public List<SelectListItem> CitiesSelectList { get; set; }
    }

    public class SearchCourseViewModel :Course
    {
        [NotMapped]
        public double SearchCoef { get; set; }
    }
}