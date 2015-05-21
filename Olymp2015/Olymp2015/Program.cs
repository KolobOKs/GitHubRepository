using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Olymp2015.Commons;

namespace Olymp2015
{
    internal class Program
    {
        public static List<Route> Routes { get; set; }
        public static List<Waypoint> Waypoints { get; set; }

        private static void Main(string[] args)
        {
            Routes = new List<Route>();
            Waypoints=new List<Waypoint>();
            string path = @"C:\files\avto\";
            var carType = CarType.Bus;
            var directory = new DirectoryInfo(Path.GetDirectoryName(path));
            DirectoryInfo[] routeNames = directory.GetDirectories();
            foreach (DirectoryInfo routeName in routeNames.Take(10)) // список папок с маршрутами
            {
                string routeStringName = routeName.Name;
                DirectoryInfo[] dayMasks = routeName.GetDirectories();
                foreach (DirectoryInfo dayMask in dayMasks)
                {
                    WeekDays day = dayMask.Name == "0000011"
                        ? WeekDays.Weekend
                        : dayMask.Name == "1111100"
                            ? WeekDays.Daily
                            : dayMask.Name == "0000010"
                                ? WeekDays.Sarturday
                                : WeekDays.Sunday;
                    DirectoryInfo[] directions = dayMask.GetDirectories();

                    foreach (DirectoryInfo direction in directions)
                    {
                        string directionName = direction.Name;

                        Route currentRoute = Routes.FirstOrDefault(
                            r => r.Name == routeStringName && r.Type == carType && r.DirectionName == directionName);
                        if (currentRoute == null)
                        {
                            currentRoute = new Route(routeStringName, carType, directionName);
                            Routes.Add(currentRoute);
                        }


                        FileInfo[] wayPoints = direction.GetFiles(); // поправить тут
                        foreach (FileInfo wayPoint in wayPoints)
                        {
                            if (wayPoint.Name.Contains(".txt"))
                                continue;
                            Tuple<string, List<DateTime>> tuple = ParseWayPoint(wayPoint.FullName);
                            var selectedWaypoint = Waypoints.FirstOrDefault(w => w.Name == tuple.Item1);
                            if (selectedWaypoint == null)
                            {
                                selectedWaypoint=new Waypoint(tuple.Item1);
                            }
                            var time = new Time(day);
                            time.DateTimes = tuple.Item2;
                            time.Route = currentRoute;
                            selectedWaypoint.Times.Add(time);
                            if (selectedWaypoint.Routes.All(r => r.Name != currentRoute.Name))
                            {
                                selectedWaypoint.Routes.Add(currentRoute);
                            }
                            if (currentRoute.IsFilled == false)
                            {
                                if (currentRoute.Waypoints.All((w => w.Name != selectedWaypoint.Name)))
                                {
                                    currentRoute.Waypoints.Add(selectedWaypoint);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void SelectRoute(WeekDays day, string start, string end)
        {
            
        }

        private static void Recurse(List<Waypoint> totalWaypoints,List<Waypoint> waypointsInRoute, Waypoint start, Waypoint end)
        {
            var thisResurseList = new List<Waypoint>();
            thisResurseList.AddRange(waypointsInRoute);
            if (start == end)
            {
                Founded(thisResurseList);
            }
            foreach (var route in start.Routes)
            {
                var thisRouteWaypoints = new List<Waypoint>();
                thisRouteWaypoints.AddRange(thisResurseList);
                
            }
        }

        private static void Founded(List<Waypoint> points)
        {
            var a = 5;
        }

        private static Tuple<string, List<DateTime>> ParseWayPoint(string path)
        {
            var times = new List<DateTime>();
            string pattern = @"<a.*.a>";
            var regex = new Regex(pattern);
            string wayPointName = "";
            string xml = Encoding.GetEncoding("Windows-1251").GetString(File.ReadAllBytes(path));
            xml = xml.Replace("<link rel=\"stylesheet\" href=\"printable.css\">", "");
            xml = xml.Replace("<link rel=\"shortcut icon\" href=\"favicon.ico\" type=\"image/x-icon\">", "");
            xml = xml.Replace("<img src=\"scissors.png\" width=\"64\" height=\"64\">", "");
            xml = xml.Replace("&nbsp;", "").Replace("<br>", "").Replace("<way=>", "");
            xml = regex.Replace(xml, "");
            var doc = new XmlDocument();
            doc.LoadXml(xml.Replace("&nbsp;", "").Replace("<br>", "").Replace(@"</b> </b>","</b>"));

            foreach (XmlNode node in doc.DocumentElement)
            {
                if (node.LocalName == "body")
                {
                    wayPointName =
                        node.ChildNodes[3].ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[0].InnerText
                            .Replace("Остановка: ", "");
                    XmlNode table = node.ChildNodes[3].ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[1];
                    foreach (XmlNode item in table.ChildNodes) // tr
                    {
                        string hour = "";
                        foreach (XmlNode td in item.ChildNodes)
                        {
                            foreach (XmlNode span in td.ChildNodes)
                            {
                                if (span.Attributes["class"].Value == "hour")
                                {
                                    hour = span.InnerText;
                                }
                                if (span.Attributes["class"].Value == "minute")
                                {
                                    if (span.InnerText == String.Empty)
                                        continue;
                                    try
                                    {
                                        times.Add(new DateTime(1999, 1, 1, int.Parse(hour), int.Parse(span.InnerText), 0));
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return new Tuple<string, List<DateTime>>(wayPointName, times);
        }
    }
}