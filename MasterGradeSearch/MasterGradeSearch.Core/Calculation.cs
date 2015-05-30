using System;
using System.Collections.Generic;
using System.Linq;
using MasterGradeSearch.Core.Commons;

namespace MasterGradeSearch.Core
{
    public class Calculation
    {
        public Calculation(List<CriterionRatio> ratios)
        {
            Criteries = ratios.Select(r => r.CriterionSource).Distinct().ToList();
            double rootDegree = Criteries.Count;
            rootDegree = 1/(rootDegree - 1);
            foreach (var criteria in Criteries)
            {
                var ratiosForCurrentCriteria = ratios.Where(r => r.CriterionSource == criteria);
                var multiplicationCoef = ratiosForCurrentCriteria.Aggregate(1.0, (current, ratio) => current*ratio.Ratio);
                
                criteria.CriterionCoef=Math.Pow(multiplicationCoef, rootDegree);
            }
            var sumOfCriteries = Criteries.Sum(c => c.CriterionCoef);
            foreach (var criterion in Criteries)
            {
                criterion.CriterionCoef = criterion.CriterionCoef / sumOfCriteries;
            }
        }

        public double GetCoefOfCourse(CourseFilterProreties filter,Course course, List<Course> allCourses)
        {
            double totalCoefficient=0;
            //Критерий "Наличие специальности
            if (filter.Disciplines.Any(d => d == course.Discipline))
            {
                if (filter.Disciplines.Count == 1)
                {
                    totalCoefficient+=Criteries.First(c => c.Name == "DisciplineExists").CriterionCoef;
                }
                else
                {
                    var instituteCourses = allCourses.Where(c => c.Institute == course.Institute).ToList();
                    var findedDisciplines = filter.Disciplines.Count(discipline => instituteCourses.Any(i => i.Discipline == discipline));
                    double disciplinesCount = filter.Disciplines.Count;
                    totalCoefficient += (Criteries.First(c => c.Name == "DisciplineExists").CriterionCoef*
                                         (findedDisciplines/disciplinesCount));
                }
            }
            //Конец критерия "Наличие специальности

            //Критерий "Вступительные испытания 
            var findedExams = filter.Exams.Count(exam => course.Exams.Any(i => i == exam));
            double examsCount = filter.Exams.Count;
            totalCoefficient += Criteries.First(c => c.Name == "ExamsExists").CriterionCoef * (findedExams / examsCount);
            //Конец критерия "Вступительные испытания 

            //Критерий "•	Наличие подготовительных курсов 
            if (filter.PreparatoryCourses && course.PreparatoryCourses)
            {
                totalCoefficient += Criteries.First(c => c.Name == "PreparatoryCoursesExists").CriterionCoef;
            }
            //Конец критерия "•	Наличие подготовительных курсов 

            //Критерий "•	Наличие общежития
            if (filter.Hostel && course.Hostel)
            {
                totalCoefficient += Criteries.First(c => c.Name == "HostelExists").CriterionCoef;
            }
            //Конец критерия "•	Наличие общежития

            //Критерий "•	Бюджет/внебюджет 

            //Конец критерия "•	Бюджет/внебюджет 

            //Критерий "•	Расположение
            if (filter.Districts.Count > 0 && filter.Districts.Any(d => d == course.Institute.District))
            {
                totalCoefficient += Criteries.First(c => c.Name == "CityLocation").CriterionCoef;
            }
            //Конец критерия "•	Расположение

            //Критерий "•	Очное/ заочное 
            //Конец критерия "•	Очное/ заочное 

            return totalCoefficient;
        }

        public List<Criterion> Criteries { get; set; }
    }
}