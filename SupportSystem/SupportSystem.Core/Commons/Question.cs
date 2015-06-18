using System;
using DevExpress.Xpo;

namespace SupportSystem.Core.Commons
{
    public class Question: XPObject
    {
        public Question(Session session) : base(session)
        {
        }

        public String QuestionText { get; set; }

        [Association("Question-ProblemQuestionRelationship")]
        public XPCollection<ProblemQuestionRelationship> Relationships
        {
            get
            {
                return GetCollection<ProblemQuestionRelationship>("Relationships");
            }
        }

        public Question(string questionText)
            : base(DataBaseContext.Session)
        {
            QuestionText = questionText;
        }
    }
}