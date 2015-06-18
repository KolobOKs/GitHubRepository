using SupportSystem.Core;
using SupportSystem.Core.Commons;

namespace SupportSystem.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ProblemDetector.Initialize(DataBaseContext.Problems,DataBaseContext.Questions);

            while (true)
            {
                var question = ProblemDetector.GetNextQuestion();
                ProblemDetector.AnswerCalculation(question, true);
            }
        }
    }
}