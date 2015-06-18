using System;
using DevExpress.Xpo;

namespace SupportSystem.Core.Commons
{
    public class General : XPObject
    {
        public Double TotalProblemsDetected { get; set; }

        public General(Session session) : base(session)
        {
        }
    }
}