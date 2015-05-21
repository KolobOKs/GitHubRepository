using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MasterGradeSearch.Core.Commons
{
    public enum LearningType
    {
        [Display(Name = "Очная форма")]
        FullTime,
        [Display(Name = "Заочная форма")]
        DistanceLearning
    }
}