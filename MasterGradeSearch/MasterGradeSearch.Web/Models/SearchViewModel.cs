using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MasterGradeSearch.Core.Commons;

namespace MasterGradeSearch.Web.Models
{
    public class SearchViewModel
    {
        public List<Course> FindedCourses { get; set; }
    }

    public class SearchCourseViewModel :Course
    {
        [NotMapped]
        public double SearchCoef { get; set; }
    }
}