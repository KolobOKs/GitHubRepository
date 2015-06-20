using System;

namespace SupportSystem.Core.Commons
{
    public class ProblemFoundEventArgs :EventArgs
    {
        public Problem Problem { get; set; }

        public ProblemFoundEventArgs(Problem problem)
        {
            Problem = problem;
        }
    }
}