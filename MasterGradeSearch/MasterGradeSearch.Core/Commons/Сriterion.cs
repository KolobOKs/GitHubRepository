using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterGradeSearch.Core.Commons
{
    /// <summary>
    ///     Критерий. Соотносится с таблицей Criterions в базе данных.
    /// </summary>
    [DisplayName("Критерий")]
    public class Criterion
    {
        public Int32 Id { get; set; }

        [Required]
        [DisplayName("Название криетрия")]
        public String Name { get; set; }

        [NotMapped]
        public Double CriterionCoef { get; set; }
    }
}