using System;
using System.Collections.Generic;
using System.Linq;
using MasterGradeSearch.Core.Commons;

namespace MasterGradeSearch.Core
{
    /// <summary>
    ///     Модуль расчетов. Объекты данного типа на основе критериев, полученных в параметре конструтора
    ///     производят расчеты коэффициентов для нахождения наиболее рентабельного направления подготовки в вузах
    /// </summary>
    public class Calculation
    {
        /// <summary>
        ///     Конструктор. На основе отношений критериев, полученных из базы данных, 
        ///     вычисляет окончательные цифры, критериев. ( те самые, которые в сумме все должны давать единицу)
        /// </summary>
        /// <param name="ratios">Отношения криетриев, которые сюда приходят из базы знаний.</param>
        public Calculation(List<CriterionRatio> ratios)
        {
            Criteries = ratios.Select(r => r.CriterionSource).Distinct().ToList();
            double rootDegree = Criteries.Count;
            rootDegree = 1/(rootDegree);
            foreach (Criterion criteria in Criteries)
            {
                IEnumerable<CriterionRatio> ratiosForCurrentCriteria = ratios.Where(r => r.CriterionSource == criteria);
                double multiplicationCoef = ratiosForCurrentCriteria.Aggregate(1.0,
                    (current, ratio) => current*ratio.Ratio);

                criteria.CriterionCoef = Math.Pow(multiplicationCoef, rootDegree);
            }
            double sumOfCriteries = Criteries.Sum(c => c.CriterionCoef);
            foreach (Criterion criterion in Criteries)
            {
                criterion.CriterionCoef = criterion.CriterionCoef/sumOfCriteries;
            }
        }

        /// <summary>
        ///     Критерии, которые после заполнения в конструкторе используются в расчетах
        /// </summary>
        public List<Criterion> Criteries { get; set; }

        /// <summary>
        ///     Функция, которая непосредственно рассчитывает критерий, на основе значений фильтра, для заданного конкретного направления подготовки
        /// </summary>
        /// <param name="filter">Параметры фильтра, которые отметил пользователь</param>
        /// <param name="course">Конкретное направление подгтовки, для которого расчитывается криетрий</param>
        /// <param name="allCourses">Список всех направлений подготовки. *** Он нам нужен, чтобы определить, есть ли в вузе другие направления, которые дополнительно отметил пользователь***  - если непонятно - напиши мне.</param>
        /// <returns></returns>
        public double GetCoefOfCourse(CourseFilterProreties filter, Course course, List<Course> allCourses)
        {
            double totalCoefficient = 0;
            //Критерий "Наличие специальности
            if (filter.Disciplines.Any(d => d.Id == course.Discipline.Id))
            {
                if (filter.Disciplines.Count == 1)
                {
                    totalCoefficient += Criteries.First(c => c.Name == "DisciplineExists").CriterionCoef;
                }
                else
                {
                    List<Course> instituteCourses = allCourses.Where(c => c.Institute.Id == course.Institute.Id).ToList();
                    int findedDisciplines =
                        filter.Disciplines.Count(discipline => instituteCourses.Any(i => i.Discipline.Id == discipline.Id));
                    double disciplinesCount = filter.Disciplines.Count;
                    totalCoefficient += (Criteries.First(c => c.Name == "DisciplineExists").CriterionCoef*
                                         (findedDisciplines/disciplinesCount));
                }
            }
            //Конец критерия "Наличие специальности

            //Критерий "Вступительные испытания 
            if (filter.Exams.Count == 0)
            {
                totalCoefficient += Criteries.First(c => c.Name == "ExamsExists").CriterionCoef;
            }
            else
            {
                double findedExams = filter.Exams.Count(exam => course.Exams.Any(i => i.ExamId == exam.ExamId));
                double examsCount = course.Exams.Count;
                totalCoefficient += Criteries.First(c => c.Name == "ExamsExists").CriterionCoef*(findedExams/examsCount);
            }
            //Конец критерия "Вступительные испытания 

            //Критерий "•	Наличие подготовительных курсов 
            if (filter.PreparatoryCourses)
            {
                if (course.PreparatoryCourses)
                {
                    totalCoefficient += Criteries.First(c => c.Name == "PreparatoryCoursesExists").CriterionCoef;
                }
            }
            else
            {
                totalCoefficient += Criteries.First(c => c.Name == "PreparatoryCoursesExists").CriterionCoef;
            }
            //Конец критерия "•	Наличие подготовительных курсов 

            //Критерий "•	Наличие общежития
            if (filter.Hostel)
            {
                if (course.Hostel)
                {
                    totalCoefficient += Criteries.First(c => c.Name == "HostelExists").CriterionCoef;
                }
            }
            else
            {
                totalCoefficient += Criteries.First(c => c.Name == "HostelExists").CriterionCoef;
            }
            //Конец критерия "•	Наличие общежития

            //Критерий "•	Бюджет/внебюджет 
            if (!filter.Budget && !filter.Extrabudget)
            {
                totalCoefficient += Criteries.First(c => c.Name == "BudgetOrExtrabudget").CriterionCoef;
            }
            else if (filter.Budget && !filter.Extrabudget && course.Budget)
            {
                totalCoefficient += Criteries.First(c => c.Name == "BudgetOrExtrabudget").CriterionCoef;
            }
            else if (!filter.Budget && filter.Extrabudget && course.Extrabudgetary)
            {
                if (course.Cost <= filter.Cost)
                {
                    totalCoefficient += Criteries.First(c => c.Name == "BudgetOrExtrabudget").CriterionCoef;
                }
                else if (course.Cost <= filter.Cost - 15000)
                {
                    totalCoefficient += Criteries.First(c => c.Name == "BudgetOrExtrabudget").CriterionCoef*0.5;
                }
            }
            else if (filter.Budget && filter.Extrabudget)
            {
                if (course.Budget)
                {
                    totalCoefficient += Criteries.First(c => c.Name == "BudgetOrExtrabudget").CriterionCoef;
                }
                else if (course.Extrabudgetary && course.Cost <= filter.Cost)
                {
                    totalCoefficient += Criteries.First(c => c.Name == "BudgetOrExtrabudget").CriterionCoef*0.5;
                }
            }
            
            //Конец критерия "•	Бюджет/внебюджет 

            //Критерий "•	Расположение
            if (filter.Districts.Count != 0)
            {
                if (course.Institute.District != null)
                {
                    if (filter.Districts.Count > 0 && filter.Districts.Any(d => d.Id == course.Institute.District.Id))
                    {
                        totalCoefficient += Criteries.First(c => c.Name == "CityLocation").CriterionCoef;
                    }
                }
            }
            else
            {
                totalCoefficient += Criteries.First(c => c.Name == "CityLocation").CriterionCoef;
            }
            //Конец критерия "•	Расположение

            //Критерий "•	Очное/ заочное 
            if (filter.LearningTypes.Count == 0)
            {
                totalCoefficient += Criteries.First(c => c.Name == "LearningType").CriterionCoef;
            }
            else
            {

                if (filter.LearningTypes.Any(t => t == LearningType.FullTime) &&
                    filter.LearningTypes.All(t => t != LearningType.DistanceLearning) &&
                    course.LearningType == LearningType.FullTime)
                {
                    totalCoefficient += Criteries.First(c => c.Name == "LearningType").CriterionCoef;
                }
                else if (filter.LearningTypes.Any(t => t == LearningType.DistanceLearning) &&
                         filter.LearningTypes.All(t => t != LearningType.FullTime) &&
                         course.LearningType == LearningType.DistanceLearning)
                {
                    totalCoefficient += Criteries.First(c => c.Name == "LearningType").CriterionCoef;
                }
                else if (filter.LearningTypes.Any(t => t == LearningType.DistanceLearning) &&
                         filter.LearningTypes.All(t => t != LearningType.FullTime) &&
                         course.LearningType == LearningType.FullTime)
                {
                    totalCoefficient += Criteries.First(c => c.Name == "LearningType").CriterionCoef*0.3;
                }
                else if (filter.LearningTypes.Any(t => t == LearningType.FullTime) &&
                         filter.LearningTypes.Any(t => t == LearningType.DistanceLearning))
                {
                    totalCoefficient += Criteries.First(c => c.Name == "LearningType").CriterionCoef;
                }
            }
            //Конец критерия "•	Очное/ заочное 

            return totalCoefficient;
        }
    }
}