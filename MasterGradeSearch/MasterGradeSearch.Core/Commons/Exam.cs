using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MasterGradeSearch.Core.Commons
{
    public class Exam
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Вступительное испытание")]
        public String Name { get; set; }

    }
}