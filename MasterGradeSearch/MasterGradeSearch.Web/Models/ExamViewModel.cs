using System.Collections.Generic;
using MasterGradeSearch.Core.Commons;

namespace MasterGradeSearch.Web.Models
{
    public class ExamViewModel
    {
        public List<Exam> Exams { get; set; }

        public Exam Exam { get; set; }
    }
}