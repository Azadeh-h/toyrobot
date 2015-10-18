using System;

namespace ToyRobot.App.Model
{
    public interface ITable
    {
         Tuple<int,int> TableCoordinate { get; set; }
    }

    public class Table : ITable
    {
        public Table(Tuple<int, int> coordinate)
        {
            TableCoordinate = coordinate;
        }

        public Tuple<int, int> TableCoordinate { get; set; }
    }
}