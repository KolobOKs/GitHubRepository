using System;
using SupportSystem.Core.Commons;

namespace SupportSystem.Core
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