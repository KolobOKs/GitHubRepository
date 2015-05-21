using System;
using System.Collections.Generic;

namespace Olymp2015.Commons
{
    public class Waypoint
    {
        public String Name { get; set; }
        public List<Route> Routes { get; set; }

        public List<Time> Times { get; set; }
        public Waypoint(string name)
        {
            Name = name;
            Routes = new List<Route>();
            Times = new List<Time>();
        }
    }
}