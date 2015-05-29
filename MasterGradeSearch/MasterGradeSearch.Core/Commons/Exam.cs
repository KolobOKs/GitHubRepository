using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MasterGradeSearch.Core.Commons
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Вступительное испытание")]
        public String Name { get; set; }


        public virtual ICollection<Course> Courses { get; set; }

        public static explicit operator Exam(String i)
        {
            return new Exam(){ExamId = Int32.Parse(i)};
        }
    }
}