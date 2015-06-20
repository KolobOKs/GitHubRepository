using System;
using System.Collections.Generic;
using SupportSystem.Core.Commons;

namespace SupportSystem.Core
{
    public static class IncidentTransfer
    {
        public static Guid NewUnrecognizedIncident(List<Tuple<Question, bool?>> answeredQuestions,
            List<Problem> findedProblmes)
        {
            // Метод создает и отправляет заявку в компоненту нераспознанных инцидентов
            return Guid.NewGuid();
        }
    }
}