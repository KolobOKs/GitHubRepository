using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterGradeSearch.Core.Commons
{
    /// <summary>
    ///     Вуз. Соотносится с таблицей Institites в базе данных
    /// </summary>
    public class Institute
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(20)]
        [DisplayName("Сокращенное название")]
        public String ShortName { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Полное название")]
        public String FullName { get; set; }

        [Required]
        public int CityId { get; set; }

        
        [DisplayName("Город")]
        [ForeignKey("CityId")]
        public City City { get; set; }


        public int DistrictId { get; set; }

        [MaxLength]
        public String Description { get; set; }

        [MaxLength]
        public String ImageBase64 { get; set; }
        
        [ForeignKey("DistrictId")]
        public District District { get; set; }

        
        [DisplayName("Направления подготовки")]
        public virtual ICollection<Course> Courses { get; set; }
    }
}