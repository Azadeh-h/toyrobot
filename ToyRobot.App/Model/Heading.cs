using System;

namespace ToyRobot.App.Model
{
    public interface IHeading
    {
        bool IsCurrentHeading(int degree);
        Tuple<int, int> Move(Tuple<int, int> currentPosition);
        Char HeadingChar { get; }
    }

    /// <summary>
    /// North facing robot has moved the whole circle clockwise or is not started moving
    /// </summary>
    public class NorthHeading : IHeading
    {
        /// <summary>
        /// Facing north robot will have a degree of 360 or 0
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public bool IsCurrentHeading(int degree)
        {
            return degree % 360 == 0;
        }

        /// <summary>
        /// Y+1
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns></returns>
        public Tuple<int, int> Move(Tuple<int, int> currentPosition)
        {
            return new Tuple<int, int>(currentPosition.Item1, currentPosition.Item2 + 1);
        }

        public char HeadingChar
        {
            get { return 'N'; }
        }
    }

    /// <summary>
    /// East facing robot
    /// </summary>
    public class EastHeading : IHeading
    {
        /// <summary>
        /// Facing east robot will have a degree of +-90
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public bool IsCurrentHeading(int degree)
        {
            return (degree % 360 == 90 || degree % 360 == -270);
        }

        /// <summary>
        /// X+1
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns></returns>
        public Tuple<int, int> Move(Tuple<int, int> currentPosition)
        {
            return new Tuple<int, int>(currentPosition.Item1 + 1, currentPosition.Item2);
        }

        public char HeadingChar
        {
            get { return 'E'; }
        }
    }

    /// <summary>
    /// South facing robot
    /// </summary>
    public class SouthHeading : IHeading
    {
        /// <summary>
        /// Facing south robot will have a degree of +-180
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public bool IsCurrentHeading(int degree)
        {
            return (degree % 360 == 180 || degree % 360 == -180);
        }

        /// <summary>
        /// Y-1
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns></returns>
        public Tuple<int, int> Move(Tuple<int, int> currentPosition)
        {
            return new Tuple<int, int>(currentPosition.Item1, currentPosition.Item2 - 1);
        }

        public char HeadingChar
        {
            get { return 'S'; }
        }

    }

    /// <summary>
    /// West facing robot
    /// </summary>
    public class WestHeading : IHeading
    {
        /// <summary>
        ///  Facing west robot will have a degree of +-270
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        public bool IsCurrentHeading(int degree)
        {
            return (degree % 360 == 270 || degree % 360 == -90);
        }

        /// <summary>
        /// X-1
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns></returns>
        public Tuple<int, int> Move(Tuple<int, int> currentPosition)
        {
            return new Tuple<int, int>(currentPosition.Item1 - 1, currentPosition.Item2);
        }

        public char HeadingChar
        {
            get { return 'W'; }
        }
    }
}
