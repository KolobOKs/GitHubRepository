using System;
using System.Xml.Linq;
using DevExpress.Xpo;

namespace SupportSystem.Core.Commons
{
    public class Problem :XPObject
    {
        public String ShortName { get; set; }
        public String Solve { get; set; }
        public Int32 DetectedCount { get; set; }

        [Association("Problem-ProblemQuestionRelationship")]
        public XPCollection<ProblemQuestionRelationship> Relationships { get
        {
            return GetCollection<ProblemQuestionRelationship>("Relationships");
        }}

        public Problem(string shortName, string solve)
            :base (DataBaseContext.Session)
        {
            ShortName = shortName;
            Solve = solve;
        }

        public Problem(Session session) : base(session)
        {
        }
    }
}