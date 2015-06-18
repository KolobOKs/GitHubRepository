using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using MasterGradeSearch.Core.Commons;
using MasterGradeSearch.Web.Models;

namespace MasterGradeSearch.Web
{
    /// <summary>
    ///     Класс, обеспечивающий преобразование данных из строки запроса (напр. localhost/Search/Index?City=Москва&Institute=МЭСИ...
    ///     в объект, с которым может работать SearchController
    /// </summary>
    public class SearchBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var db = new ApplicationDbContext();
            var disciplinesIdsStr = bindingContext.ValueProvider.GetValue("DiscIDS");
            var districtsIdsStr = bindingContext.ValueProvider.GetValue("DstrIDS");
            var citiesIdsStr = bindingContext.ValueProvider.GetValue("CityIDS");
            var examsIdsStr = bindingContext.ValueProvider.GetValue("ExamIDS");

            var hostel = bindingContext.ValueProvider.GetValue("hostelCHECK");
            var preparation = bindingContext.ValueProvider.GetValue("preparationCHECK");
            var budget = bindingContext.ValueProvider.GetValue("budgetCHECK");
            var extraBudget = bindingContext.ValueProvider.GetValue("extraBudgetCHECK");
            var full = bindingContext.ValueProvider.GetValue("fullCHECK");
            var distance = bindingContext.ValueProvider.GetValue("distanceCHECK");
            var cost = bindingContext.ValueProvider.GetValue("costTEXT");

            var result= new SearchViewModel();
            if (citiesIdsStr != null)
            {
                var cities = citiesIdsStr.AttemptedValue.Split(',');
                var citiesObjects = db.Cities.Where(d => cities.Contains(d.Id.ToString())).ToList();
                result.Cities = citiesObjects;
            }
            else
            {
                result.Cities=new List<City>();
            }

            if (districtsIdsStr != null)
            {
                var disctricts = districtsIdsStr.AttemptedValue.Split(',');
                var districtsObjects = db.Districts.Where(d => disctricts.Contains(d.Id.ToString())).ToList();
                result.Districts = districtsObjects;
            }
            else
            {
                result.Districts=new List<District>();
            }

            if (disciplinesIdsStr != null)
            {
                var disciplines = disciplinesIdsStr.AttemptedValue.Split(',');
                var disciplinesObjects = db.Disciplines.Where(d => disciplines.Contains(d.Id.ToString())).ToList();
                result.Disciplines = disciplinesObjects;
            }
            else
            {
                result.Disciplines=new List<Discipline>();
            }

            if (examsIdsStr != null)
            {
                var exams = examsIdsStr.AttemptedValue.Split(',');
                var examsObject = db.Exams.Where(d => exams.Contains(d.ExamId.ToString())).ToList();
                result.Exams = examsObject;
            }
            else
            {
                result.Exams=new List<Exam>();
            }

            if (hostel != null)
            {
                result.Hostel = true;
            }
            if (budget != null)
            {
                result.Budget = true;
            }
            if (extraBudget != null)
            {
                result.ExtraBudget = true;
            }
            if (preparation != null)
            {
                result.PreparationCourses = true;
            }
            if (full != null)
            {
                result.FullTime = true;
            }
            if (distance != null)
            {
                result.DistanceLearning = true;
            }
            if (cost != null)
            {
                decimal costResult;
                if (Decimal.TryParse(cost.AttemptedValue, out costResult))
                {
                    result.Cost = costResult;
                }
                else
                {
                    result.Cost = 0;
                }
            }
            return result;
        }
    }
}