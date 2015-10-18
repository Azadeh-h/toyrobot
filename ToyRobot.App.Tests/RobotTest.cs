using NUnit.Framework;
using ToyRobot.App.Model;
using System;

namespace ToyRobot.App.Tests
{
    [TestFixture]
    public class RobotTest
    {

        [Test]
        public void turn_robot_to_left_from_00n_goes_to_00w()
        {
            var coord = new Tuple<int, int>(5, 5);
            ITable table = new Table(coord);

            var robotState = new RobotState(0, 0, 'N');
             IRobotService robotService = new RobotService(table, robotState);

            string command = "L";
            var pos = robotService.Proceed(command);
            var expectedState = new RobotState(0, 0, 'W');
            Assert.AreEqual(expectedState.RobotCoordinate, pos.RobotCoordinate);
            Assert.AreEqual(expectedState.Heading, pos.Heading);
        }

        [Test]
        public void move_robot_from_00n_goes_to_01n()
        {
            var coord = new Tuple<int, int>(5, 5);
            ITable table = new Table(coord);

            var robotState = new RobotState(0, 0, 'N');
             IRobotService robotService = new RobotService(table, robotState);

            string command = "M";
            var pos = robotService.Proceed(command);
            var expectedState = new RobotState(0, 1, 'N');
            Assert.AreEqual(expectedState.RobotCoordinate, pos.RobotCoordinate);
            Assert.AreEqual(expectedState.Heading, pos.Heading);
        }

        [Test]
        public void move_robot_from_12e_goes_to_33n()
        {
            var coord = new Tuple<int, int>(5, 5);
            ITable table = new Table(coord);

            var robotState = new RobotState(1, 2, 'E');
             IRobotService robotService = new RobotService(table, robotState);

            string command = "MMLM";
            var pos = robotService.Proceed(command);
            var expectedState = new RobotState(3, 3, 'N');
            Assert.AreEqual(expectedState.RobotCoordinate, pos.RobotCoordinate);
            Assert.AreEqual(expectedState.Heading, pos.Heading);
        }



        [Test]
        public void move_robot_from_12n_goes_to_13n()
        {
            var coord = new Tuple<int, int>(5, 5);
            ITable table = new Table(coord);

            var robotState = new RobotState(1, 2, 'N');
             IRobotService robotService = new RobotService(table, robotState);

            string command = "LMLMLMLMM";
            var pos = robotService.Proceed(command);
            var expectedState = new RobotState(1, 3, 'N');
            Assert.AreEqual(expectedState.RobotCoordinate, pos.RobotCoordinate);
            Assert.AreEqual(expectedState.Heading, pos.Heading);
        }

        [Test]
        public void move_robot_from_33e_goes_to_51e()
        {
            var coord = new Tuple<int, int>(5, 5);
            ITable table = new Table(coord);

            var robotState = new RobotState(3, 3, 'e');

             IRobotService robotService = new RobotService(table, robotState);

            string command = "MMRMMRMRRM";
            var pos = robotService.Proceed(command);
            var expectedState = new RobotState(5, 1, 'E');
            Assert.AreEqual(expectedState.RobotCoordinate, pos.RobotCoordinate);
            Assert.AreEqual(expectedState.Heading, pos.Heading);
        }


        [Test]
        public void move_robot_to_out_of_boundries_throws_exception()
        {
            var coord = new Tuple<int, int>(5, 5);
            ITable table = new Table(coord);

            var robotState = new RobotState(4, 5, 'E');

             IRobotService robotService = new RobotService(table, robotState);

            string command = "MML";
            var ex = Assert.Throws<InvalidOperationException>(() => robotService.Proceed(command));
            Assert.That(ex.Message, Is.EqualTo("Out of boundaries"));
        }


        [Test]
        public void move_robot_with_invalid_command_throws_exception()
        {
            var coord = new Tuple<int, int>(5, 5);
            ITable table = new Table(coord);

            var robotState = new RobotState(3, 3, 'E');

             IRobotService robotService = new RobotService(table, robotState);

            string command = "ABCD1234";
            var pos = robotService.Proceed(command);
            var expectedState = new RobotState(3, 3, 'E');
            Assert.AreEqual(expectedState.RobotCoordinate, pos.RobotCoordinate);
            Assert.AreEqual(expectedState.Heading, pos.Heading);
        }
    }
}
