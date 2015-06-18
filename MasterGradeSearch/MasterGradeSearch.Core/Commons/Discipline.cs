using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MasterGradeSearch.Core.Commons
{
    /// <summary>
    ///     Тип "Дисциплина направления подготовки" (например "Экономика"). Соотносится с таблицей Disciplines в базе данных
    /// </summary>
    [DisplayName("Направление подготовки")]
    public class Discipline
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Название")]
        public String Name { get; set; }

        [DisplayName("Вступительные испытания")]
        public virtual ICollection<Exam> Exams { get; set; } 
    }
}