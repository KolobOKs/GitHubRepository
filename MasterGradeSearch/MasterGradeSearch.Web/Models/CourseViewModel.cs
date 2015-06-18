using System;
using MasterGradeSearch.Core.Commons;

namespace MasterGradeSearch.Web.Models
{
    /// <summary>
    ///    не используется
    /// </summary>
    public class CourseViewModel : Course
    {
        public Int32?[] ExamsIds { get; set; }
    }
}