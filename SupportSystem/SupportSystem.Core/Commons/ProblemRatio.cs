using System;

namespace SupportSystem.Core.Commons
{
    public class ProblemRatio
    {
        public Problem Problem { get; set; }
        public Double Ratio { get; set; }
        public override string ToString()
        {
            return String.Format("{0} {1}", Ratio, Problem.ShortName);
        }

        public ProblemRatio(Problem problem)
        {
            Problem = problem;
            Ratio = 0;
        }
    }
}