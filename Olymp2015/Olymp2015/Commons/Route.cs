using System;
using System.Collections.Generic;

namespace Olymp2015.Commons
{
    public class Route
    {
        public Guid Guid { get; set; }
        public String DirectionName { get; set; }
        public String Name { get; set; }
        public CarType Type { get; set; }
        public List<Waypoint> Waypoints { get; set; }

        public bool IsFilled { get; set; }

        public Route(string name, CarType type, string directionName)
        {
            Name = name;
            DirectionName = directionName;
            Type = type;
            Guid= Guid.NewGuid();
            Waypoints = new List<Waypoint>();
            IsFilled = false;
        }
    }
}