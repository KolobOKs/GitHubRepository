using System;
using DevExpress.Xpo;

namespace SupportSystem.Core.Commons
{
    public class ProblemQuestionRelationship : XPObject
    {
        private Problem _problem;
        private Question _question;

        public ProblemQuestionRelationship(Problem problem, Question question, int possibleAnswersCount, int negativeAnswersCount)
            : base(DataBaseContext.Session)
        {
            _problem = problem;
            _question = question;
            PossibleAnswersCount = possibleAnswersCount;
            NegativeAnswersCount = negativeAnswersCount;
        }

        public ProblemQuestionRelationship(Problem problem, Question question)
            : this(problem, question, 0, 0)
        {}

        public ProblemQuestionRelationship(Session session) : base(session)
        {
        }

        [Association("Problem-ProblemQuestionRelationship")]
        public Problem Problem
        {
            get { return _problem; }
            set { SetPropertyValue("Problem", ref _problem, value); }
        }

        [Association("Question-ProblemQuestionRelationship")]
        public Question Question
        {
            get { return _question; }
            set { SetPropertyValue("Question", ref _question, value); }
        }

        public Double PossibleAnswersCount { get; set; }
        public Double NegativeAnswersCount { get; set; }

    }
}