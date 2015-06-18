using System;
using System.Collections.Generic;
using System.Linq;
using SupportSystem.Core.Commons;

namespace SupportSystem.Core
{
    public static class PresetFacade
    {
        public static List<Preset> Presets { get; set; }

        static PresetFacade()
        {
            Presets=new List<Preset>();
            var presetTest = new Preset();
            int[] preset1Positive = new int[]{5010};
            int[] preset1Negative = new int[] {};
            var positiveQuestions=DataBaseContext.Questions.Where(s => preset1Positive.Contains(s.Oid));
            var negativeQuestions = DataBaseContext.Questions.Where(s => preset1Negative.Contains(s.Oid));
            foreach (var positiveQuestion in positiveQuestions)
            {
                presetTest.PresetQuestions.Add(new Tuple<Question, bool>(positiveQuestion,true));
            }
            foreach (var negativeQuestion in negativeQuestions)
            {
                presetTest.PresetQuestions.Add(new Tuple<Question, bool>(negativeQuestion,false));
            }
            Presets.Add(presetTest);
        }
 
    }
}