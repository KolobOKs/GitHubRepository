using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterGradeSearch.Core.Commons
{
    /// <summary>
    ///     Отношение критериев. Соотносится с таблицей CriterionRatios в базе данных
    /// </summary>
    public class CriterionRatio
    {
        public Int32 Id { get; set; }

        [Required]
        public Int32 CriterionSourceId { get; set; }
        
        [Required]
        public Int32 CriterionDestinationId { get; set; }

        [ForeignKey("CriterionSourceId")]
        public Criterion CriterionSource { get; set; }

        [ForeignKey("CriterionDestinationId")]
        public Criterion CriterionDestination { get; set; }

        [Required]
        public Double Ratio { get; set; }
    }
}