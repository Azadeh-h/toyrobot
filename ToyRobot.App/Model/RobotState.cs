using System;

namespace ToyRobot.App.Model
{
    public class RobotState
    {

        public RobotState(int x, int y, char heading)
        {
            RobotCoordinate = new Tuple<int, int>(x, y);
            Heading = heading;
            Degree = InitialDegree(heading);
        }

        public int Degree { get; set; }
        public char Heading { get; set; }
        public Tuple<int, int> RobotCoordinate { get; set; }


        /// <summary>
        /// Setting degree based on the robot heading
        /// </summary>
        /// <param name="heading"></param>
        /// <returns></returns>
        private int InitialDegree(char heading)
        {
            switch (Char.ToUpper(heading))
            {
                case 'N':
                    return 0;
                case 'E':
                    return 90;
                case 'S':
                    return 180;
                case 'W':
                    return 270;
                default:
                    return 360;
            }
        }

       
    }
}
