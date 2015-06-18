using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MasterGradeSearch.Core.Commons
{
    /// <summary>
    ///     Перечисление "Форма обучения". Соотносится с таблицей LearningTypes в базе данных
    /// </summary>
    public enum LearningType
    {
        [Display(Name = "Очная форма")]
        FullTime,
        [Display(Name = "Заочная форма")]
        DistanceLearning
    }
}