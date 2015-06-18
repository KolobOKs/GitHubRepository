using System;
using SupportSystem.Core.Commons;

namespace SupportSystem.Core
{
    public class ProblemRatio
    {
        public Problem Problem { get; set; }
        public Double Ratio { get; set; }

        public ProblemRatio(Problem problem)
        {
            Problem = problem;
            Ratio = 0;
        }
    }
}