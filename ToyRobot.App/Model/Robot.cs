using ToyRobot.App.Logic;

namespace ToyRobot.App.Model
{
    public interface IRobot
    {
        RobotState RobotState { get; set; }
        IHeading GetHeading(int degree);
        void MoveOneCell();
    }

    public class Robot : IRobot
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public Robot(RobotState state)
        {
            RobotState = state;
        }

        public RobotState RobotState { get; set; }

        public IHeading GetHeading(int degree)
        {
            return HeadingService.GetHeading(RobotState.Degree);
        }

        /// <summary>
        /// Move one cell of the grid
        /// </summary>
        public void MoveOneCell()
        {
            var cHeading = GetHeading(RobotState.Degree);
            RobotState.RobotCoordinate = cHeading.Move(RobotState.RobotCoordinate);
            RobotState.Heading = cHeading.HeadingChar;
        }
    }
}