using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using SupportSystem.Core.Commons;

namespace SupportSystem.Core
{
    public static class DataBaseContext
    {
        private static readonly XPCollection<Problem> _problems;
        private static readonly XPCollection<Question> _questions;
        private static readonly XPCollection<ProblemQuestionRelationship> _relationships;
        private static readonly General _general; 
        private static readonly Session _session;
        static  DataBaseContext()
        {
            IDataLayer a = XpoDefault.GetDataLayer(
                @"Data Source=(localdb)\Projects;Initial Catalog=SupportSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False",
                AutoCreateOption.DatabaseAndSchema);
            XpoDefault.DataLayer = a;
            _session=new Session(a);
            XpoDefault.Session = _session;
            _problems=new XPCollection<Problem>(_session);
            _questions=new XPCollection<Question>(_session);
            _relationships=new XPCollection<ProblemQuestionRelationship>(_session);
            _general=new General(_session);
            Debug.Print("DataBaseContext constructor executed");
        }

        public static Session Session { get { return _session; } }
        public static XPCollection<Problem> Problems { get { return _problems; } }
        public static XPCollection<Question> Questions { get { return _questions; } }
        public static XPCollection<ProblemQuestionRelationship> Relationships { get { return _relationships; } }
        public static General General { get { return _general; } }

        public static void IncreaseTotalDetectedProblem()
        {
            _general.TotalProblemsDetected++;
            _session.Save(_general);
            Debug.Print("New total detected problem count = {0}", _general.TotalProblemsDetected);
        }

        public static void UpdateProblem(Problem problem, bool isInscreaseDetectCount = false)
        {
            if (isInscreaseDetectCount)
            {
                problem.DetectedCount++;
                General.TotalProblemsDetected++;
                _session.Save(General);
            }
            _session.Save(problem);
        }

        public static void CreateProblem(Problem problem)
        {
            _problems.Add(problem);
            _session.Save(_problems);
            Debug.Print("Problem {0} saved",problem.ShortName);
        }

        public static void CreateQuestion(Question question)
        {
            _questions.Add(question);
            _session.Save(_questions);
            Debug.Print("Question {0} saved", question.QuestionText);
        }

        public static void CreateRelationship(ProblemQuestionRelationship relationship)
        {
            _relationships.Add(relationship);
            relationship.Problem.Relationships.Add(relationship);
            relationship.Question.Relationships.Add(relationship);
            _session.Save(_relationships);
            Debug.Print("Relationship between {0} and {1} saved", relationship.Problem.ShortName, relationship.Question.QuestionText);
        }
    }
}