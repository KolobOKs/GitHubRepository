using System;
using System.Collections.Generic;
using System.Linq;
using SupportSystem.Core.Commons;

namespace SupportSystem.Core
{
    public static class PresetFacade
    {
        static PresetFacade()
        {
            Presets = new List<Preset>();
            var presetTest = new Preset();
            int[] preset1Positive = {5010};
            int[] preset1Negative = {};
            IEnumerable<Question> positiveQuestions =
                DataBaseContext.Questions.Where(s => preset1Positive.Contains(s.Oid));
            IEnumerable<Question> negativeQuestions =
                DataBaseContext.Questions.Where(s => preset1Negative.Contains(s.Oid));
            foreach (Question positiveQuestion in positiveQuestions)
            {
                presetTest.PresetQuestions.Add(new Tuple<Question, bool>(positiveQuestion, true));
            }
            foreach (Question negativeQuestion in negativeQuestions)
            {
                presetTest.PresetQuestions.Add(new Tuple<Question, bool>(negativeQuestion, false));
            }
            Presets.Add(presetTest);
        }

        public static List<Preset> Presets { get; set; }
    }
}