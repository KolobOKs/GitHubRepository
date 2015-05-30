using System.Collections.Generic;

namespace MasterGradeSearch.Core.Commons
{
    public class CourseFilterProreties
    {
        public List<Discipline> Disciplines { get; set; }
        public List<Exam> Exams { get; set; }
        public bool PreparatoryCourses { get; set; }
        public bool Hostel { get; set; }
        public bool Budget { get; set; }
        public bool Extrabudget { get; set; }
        public decimal Cost { get; set; }
        public List<District> Districts { get; set; }
        public List<LearningType> LearningTypes { get; set; }
    }
}