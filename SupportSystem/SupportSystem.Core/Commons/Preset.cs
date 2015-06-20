using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SupportSystem.Core.Commons
{
    public class Preset
    {
        public String Name { get; set; }
        public List<Tuple<Question, bool>> PresetQuestions { get; set; }

        public Preset()
        {
            PresetQuestions=new List<Tuple<Question, bool>>();
        }

        public void MakePreset()
        {
            foreach (var presetQuestion in PresetQuestions)
            {
                ProblemDetector.AnswerCalculation(presetQuestion.Item1,presetQuestion.Item2);
                Debug.Print("PRESET: Q: {0}. A: {1}",presetQuestion.Item1.QuestionText, presetQuestion.Item2);
            }
        }
    }
}