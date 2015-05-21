using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MasterGradeSearch.Core.Commons
{
    [DisplayName("Город")]
    public class City
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Название города")]
        public String Name { get; set; }
    }
}