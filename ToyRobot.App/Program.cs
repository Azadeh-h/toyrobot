using System;
using System.Collections.Generic;
using ToyRobot.App.Model;

namespace ToyRobot.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter Commands as bellow:");
            Console.WriteLine("1- Table dimensions (x y)");
            Console.WriteLine("2- Robot's place (x y f)");
            Console.WriteLine("Face:n for north, e for east,w for west and s for south");
            Console.WriteLine("3- Set of command to move robot(M for move,L for left, R for Right)");
            Console.WriteLine("4- Press c to find out the robot's current coordinates");
            Console.WriteLine("Press Q to exit");
            var lines = new List<string>();

            while (true)
            {
                string line = Console.ReadLine();

                if (String.Compare(line, "q", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    break;
                }
                if (String.Compare(line, "c", StringComparison.OrdinalIgnoreCase) == 0)
                {
                     GetRobotState(lines);
                }

                if (! string.IsNullOrEmpty(line))
                    lines.Add(line);

            }

        }

        private  static void  GetRobotState(IEnumerable<string> lines)
        {
            ITable table = null;
            IRobotService robotService = null;

            foreach (var l in lines)
            {
                string[] commandElements = l.Split(' ');

                //First line is table's boundaries
                if (commandElements.Length == 2)
                {
                    var coord = new Tuple<int, int>(Int32.Parse(commandElements[0]), Int32.Parse(commandElements[1]));
                    table = new Table(coord);
                   
                }

                if (table != null && commandElements.Length == 3)
                {
                    var robotCurrentSate = new RobotState(Int32.Parse(commandElements[0]),
                        Int32.Parse(commandElements[1]), char.Parse(commandElements[2]));
                    robotService = new RobotService(table, robotCurrentSate);
                }
                if (robotService != null && commandElements.Length == 1)
                {
                    var currentState = robotService.Proceed(l);
                    var output = string.Format("{0} {1} {2}", currentState.RobotCoordinate.Item1,
                        currentState.RobotCoordinate.Item2, currentState.Heading);
                    Console.WriteLine(output);
                }
            }
        }
    }
}
