using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using MasterGradeSearch.Core.Commons;

namespace MasterGradeSearch.Web.Models
{
    /// <summary>
    ///     Модель для представления на веб страницу вузов
    /// </summary>
    public class InstitutesViewModel
    {
        public ICollection<Institute> AllInstitutes { get; set; }
        public Institute SelectedInstitute { get; set; }
        public ICollection<Course> SelectedIntituteCourses { get; set; }
    }
}