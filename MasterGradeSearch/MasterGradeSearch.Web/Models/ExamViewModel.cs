using System.Collections.Generic;
using MasterGradeSearch.Core.Commons;

namespace MasterGradeSearch.Web.Models
{
    /// <summary>
    ///     Модель для представления на веб страницу вступительных испытаний
    /// </summary>
    public class ExamViewModel
    {
        public List<Exam> Exams { get; set; }

        public Exam Exam { get; set; }
    }
}