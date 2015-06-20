using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using SupportSystem.Core.Commons;

namespace SupportSystem.Core
{
    public static class ProblemDetector
    {
        private static Int32 _attemptsCount;
        private static List<Tuple<Question, bool?>> _askedQuestions;
        private static List<Question> _askedQuestionsNoStat;
        public static ObservableCollection<ProblemRatio> ProblemRatios { get; set; }
        public static List<Question> Questions { get; set; }
        public static Question CurrentQuestion { get; set; }

        public static event EventHandler<ProblemFoundEventArgs> ProblemFound;
        public static event EventHandler<QuestionFoundEventArgs> QuestionFound;
        public static event EventHandler RatiosChanged;
        public static event EventHandler NextStateTransfer;

        public static void Initialize(ICollection<Problem> problems, ICollection<Question> questions)
        {
            _attemptsCount = 4;
            ProblemRatios = new ObservableCollection<ProblemRatio>();
            _askedQuestions = new List<Tuple<Question, bool?>>();
            _askedQuestionsNoStat = new List<Question>();
            foreach (Problem problem in problems)
            {
                ProblemRatios.Add(new ProblemRatio(problem));
            }
            Questions = new List<Question>();
            Questions.AddRange(questions);
            Debug.Print("Problem Detector initialized! Problems: {0}. Questions: {1}.", ProblemRatios.Count,
                Questions.Count);
        }

        public static void AnswerCalculation(bool? answer)
        {
            AnswerCalculation(CurrentQuestion, answer);
        }

        public static void AnswerCalculation(Question question, bool? answer)
        {
            _askedQuestionsNoStat.Add(question);
            if (!answer.HasValue)
            {
                return;
            }
            _askedQuestions.Add(new Tuple<Question, bool?>(question, answer));
            Debug.Print("Answer calculation started: Q: {0}. A: {1}", question.Oid, answer);
            foreach (ProblemQuestionRelationship relationship in question.Relationships)
            {
                double coef = answer.Value
                    ? relationship.PossibleAnswersCount/
                      (relationship.PossibleAnswersCount + relationship.NegativeAnswersCount)
                    : relationship.NegativeAnswersCount/
                      (relationship.PossibleAnswersCount + relationship.NegativeAnswersCount);
                ProblemRatio problem = ProblemRatios.FirstOrDefault(p => p.Problem == relationship.Problem);
                if (problem == null)
                {
                    continue;
                }
                double currentProblemDetectCount = problem.Problem.DetectedCount == 0.0
                    ? 1.0
                    : problem.Problem.DetectedCount;
                double globalProblemDetectCount = DataBaseContext.General == 0.0
                    ? 1.0
                    : DataBaseContext.General;
                double problemFrequency = currentProblemDetectCount/globalProblemDetectCount;
                problem.Ratio += coef*problemFrequency;
                Debug.Print("Answer calculated! Problem {0} {1}+{2}", problem.Problem.Oid, problem.Ratio, coef);
            }
            ProblemRatios = new ObservableCollection<ProblemRatio>(ProblemRatios.OrderByDescending(o => o.Ratio));
            if (_askedQuestions.Count == 1)
            {
                NextQuestionOrSuggestion(true);
            }
            else
            {
                NextQuestionOrSuggestion();
            }
        }

        public static void GetNextQuestion()
        {
            Debug.Print("NextQuestion search started.");
            ProblemRatio mostPopularPromblem = ProblemRatios[0];
            for (int i = 1; i < ProblemRatios.Count; i++)
            {
                ProblemRatio nextPopularProblem = ProblemRatios[i];
                var sameQuestionsList = new List<Question>();
                foreach (ProblemQuestionRelationship relationship in mostPopularPromblem.Problem.Relationships)
                {
                    sameQuestionsList.AddRange(from nextRelationship in nextPopularProblem.Problem.Relationships
                        where
                            (nextRelationship.Question == relationship.Question) &&
                            !(_askedQuestionsNoStat.Contains(relationship.Question))
                        select relationship.Question);
                }
                if (sameQuestionsList.Count > 0)
                {
                    var questionRating = new List<Tuple<Question, double>>();
                    foreach (Question question in sameQuestionsList)
                    {
                        ProblemQuestionRelationship relation1 =
                            mostPopularPromblem.Problem.Relationships.First(r => r.Question == question);
                        ProblemQuestionRelationship relation2 =
                            nextPopularProblem.Problem.Relationships.First(r => r.Question == question);
                        double coef = Math.Abs(relation1.PossibleAnswersCount/
                                               (relation1.PossibleAnswersCount + relation1.NegativeAnswersCount)) -
                                      (relation2.PossibleAnswersCount/
                                       (relation2.PossibleAnswersCount + relation2.NegativeAnswersCount));
                        questionRating.Add(new Tuple<Question, double>(question, coef));
                    }
                    questionRating.OrderByDescending(q => q.Item2);
                    Debug.Print("Question found: Q:{0}. ABS: {1}", questionRating[0].Item1.Oid, questionRating[0].Item2);
                    CurrentQuestion = questionRating[0].Item1;
                    QuestionFound(null, new QuestionFoundEventArgs(CurrentQuestion));
                    return;
                }
                Debug.Print("No same questions between 0 : {0}", i);
            }
            throw new NullReferenceException("Can't find next question");
        }

        public static void WrongProblem()
        {
            _attemptsCount--;
            if (_attemptsCount == 0)
            {
                NextStateTransfer(null, null);
                IncidentTransfer.NewUnrecognizedIncident(null, null);
                return;
            }
            ProblemRatios.RemoveAt(0);
            NextQuestionOrSuggestion();
        }

        public static void ConfirmedAssumption()
        {
            ProblemRatio problemRatio = ProblemRatios[0];
            foreach (var askedQuestion in _askedQuestions)
            {
                if (problemRatio.Problem.Relationships.Any(r => r.Question.Oid == askedQuestion.Item1.Oid))
                {
                    ProblemQuestionRelationship relation =
                        problemRatio.Problem.Relationships.First(r => r.Question.Oid == askedQuestion.Item1.Oid);
                    if (!askedQuestion.Item2.HasValue)
                    {
                        continue;
                    }
                    if (askedQuestion.Item2.Value) // Положительный ответ на вопрос
                    {
                        relation.PossibleAnswersCount++;
                    }
                    else
                    {
                        relation.NegativeAnswersCount++;
                    }
                    DataBaseContext.UpdateRelation(relation);
                }
                else
                {
                    var newRelation = new ProblemQuestionRelationship(problemRatio.Problem, askedQuestion.Item1);
                    if (!askedQuestion.Item2.HasValue)
                    {
                        continue;
                    }
                    if (askedQuestion.Item2.Value) // Положительный ответ на вопрос
                    {
                        newRelation.PossibleAnswersCount++;
                    }
                    else
                    {
                        newRelation.NegativeAnswersCount++;
                    }
                    DataBaseContext.CreateRelationship(newRelation);
                }
            }
            DataBaseContext.UpdateProblem(problemRatio.Problem, true);
        }

        private static void NextQuestionOrSuggestion(bool isFirstQuestion = false)
        {
            RatiosChanged(null, null);
            if (isFirstQuestion)
            {
                GetNextQuestion();
            }
            else if (!CheckRating())
            {
                GetNextQuestion();
            }
        }

        private static bool CheckRating()
        {
            double maximumCoef = ProblemRatios[0].Ratio;
            double secondCoef = ProblemRatios[1].Ratio;
            double minumumCoef = ProblemRatios[ProblemRatios.Count - 1].Ratio;
            double percentage = (maximumCoef - minumumCoef)*0.2;
            if (maximumCoef - percentage > secondCoef)
            {
                ProblemFound(null, new ProblemFoundEventArgs(ProblemRatios[0].Problem));
                return true;
            }
            return false;
        }
    }
}