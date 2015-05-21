using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterGradeSearch.Core.Commons
{
    [DisplayName("Район")]
    public class District
    {
        public int Id { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [Required]
        [StringLength(60)]
        [DisplayName("Название")]
        public String Name { get; set; }
    }
}