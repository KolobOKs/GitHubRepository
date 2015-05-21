using System;
using System.Collections.Generic;

namespace Olymp2015.Commons
{
    public class Time
    {
        public WeekDays WeekDay { get; set; }
        public IEnumerable<DateTime> DateTimes { get; set; }

        public Route Route { get; set; }

        public Time(WeekDays weekDay)
        {
            WeekDay = weekDay;
            DateTimes = new List<DateTime>();
        }
    }
}