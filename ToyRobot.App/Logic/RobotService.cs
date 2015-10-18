using ToyRobot.App.Model;
using System;

namespace ToyRobot.App
{
    public interface IRobotService
    {
        RobotState Proceed(string command);
    }


    public class RobotService : IRobotService
    {
        private readonly ITable _table;
        private IRobot _robot;

        /// <summary>
        /// Initialize the robot
        /// </summary>
        /// <param name="table"></param>
        /// <param name="robotCurrentState"></param>
        public RobotService(ITable table, RobotState robotCurrentState)
        {
            _table = table;
            _robot = new Robot(robotCurrentState);
        }


        /// <summary>
        /// Checks if the movement is valid
        /// </summary>
        /// <param name="robotCurrentState"></param>
        /// <returns></returns>
        private bool CanMove(RobotState robotCurrentState)
        {
            int x = robotCurrentState.RobotCoordinate.Item1;
            int y = robotCurrentState.RobotCoordinate.Item2;

            int tableX = _table.TableCoordinate.Item1;
            int tableY = _table.TableCoordinate.Item2;

            switch (robotCurrentState.Heading)
            {
                //Facing north shouldn't Y of the table
                case 'N':
                    if (y + 1 > tableY)
                        return false;
                    break;
                //Facing east shouldn't X of the table
                case 'E':
                    if  (x + 1 > tableX)
                        return false;
                    break;
                //Facing south shouldn't go bellow 0
                case 'S':
                    if (y - 1 < 0)
                        return false;
                    break;
                //Facing west shouldn't go bellow 0
                case 'W':
                    if (x - 1 < 0)
                        return false;
                    break;
            }
            return true;
        }

        /// <summary>
        /// Proceed with the command and return the current position including the heading
        /// robot shouldn't move for invalid commands
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns></returns>
        public RobotState Proceed(string commandString)
        {
            if (_robot == null)
            {
                throw new Exception("Robot is not initiated");
            }
            foreach (var command in commandString)
            {
                switch (char.ToUpper(command))
                {
                    case 'L':
                        _robot.RobotState.Degree -= 90;
                        _robot.RobotState.Heading = _robot.GetHeading(_robot.RobotState.Degree).HeadingChar;
                        break;
                    case 'R':
                        _robot.RobotState.Degree += 90;
                        _robot.RobotState.Heading = _robot.GetHeading(_robot.RobotState.Degree).HeadingChar;
                        break;
                    case 'M':
                        if (CanMove(_robot.RobotState))
                        {
                            _robot.MoveOneCell();
                        }
                        else
                        {
                            throw new InvalidOperationException("Out of boundaries");
                        }
                        break;
                    default:
                        return _robot.RobotState;
                }
            }
            return _robot.RobotState;
        }

    }
}