using System.Collections.Generic;

namespace MasterGradeSearch.Core.Commons
{
    /// <summary>
    ///     Фильтр, информацию в котором заполняет пользователь на странице поиска.
    ///     Экземпляр этого типа передается в Модуль расчетов для (Calculation.cs) для вычисления коэффициентов направлений подготовки в вузах.
    /// </summary>
    public class CourseFilterProreties
    {
        public CourseFilterProreties()
        {
            LearningTypes=new List<LearningType>();
        }

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