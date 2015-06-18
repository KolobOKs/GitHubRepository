using System;

namespace SupportSystem.Core.Commons
{
    public class QuestionFoundEventArgs :EventArgs
    {
        public Question Question { get; set; }

        public QuestionFoundEventArgs(Question question)
        {
            Question = question;
        }
    }
}