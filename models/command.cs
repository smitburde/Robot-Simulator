using System;

namespace ToyRobotSimulator
{
    public interface ICommand
    {
        void Execute(Robot robot);
    }

    public class MoveForwordCommand : ICommand
    {
        public void Execute(Robot robot)
        {
            robot.MoveForword();
        }
    }

    public class TurnLeftCommand : ICommand
    {
        public void Execute(Robot robot)
        {
            robot.TurnLeft();
        }
    }

    public class TurnRightCommand : ICommand
    {
        public void Execute(Robot robot)
        {
            robot.TurnRight();
        }
    }

    public class PlaceCommand : ICommand
    {
        private int _x = 0;

        private int _y = 0;

        private readonly Direction _direction;

        public PlaceCommand(int x, int y, Direction direction)
        {
            _x = x;
            _y = y;
            _direction = direction;
        }

        public void Execute(Robot robot)
        {
            if (robot.Board.IsValidPosition(_x, _y))
            {
                int backX = _x;
                int backY = _y;
                if (robot.Board.IsObstructionEncountered(Obstruction.HOLE, _x, _y))
                {
                    var location = robot.Board._hole_and_location.Split(",");
                    _x = int.Parse(location[2]);
                    _y = int.Parse(location[3]);
                }
                if (!robot.Board.IsObstructionEncountered(Obstruction.ROCK, _x, _y))
                {
                    robot.CoorinateX = _x;
                    robot.CoorinateY = _y;
                    robot.Direction = _direction;

                    if (robot.Board.IsObstructionEncountered(Obstruction.SPINNER, _x, _y))
                    {
                        switch (_direction)
                        {
                            case Direction.NORTH:
                                robot.Direction = Direction.SOUTH;
                                break;
                            case Direction.WEST:
                                robot.Direction = Direction.EAST;
                                break;
                            case Direction.SOUTH:
                                robot.Direction = Direction.NORTH;
                                break;
                            case Direction.EAST:
                                robot.Direction = Direction.WEST;
                                break;
                        }
                    }
                    robot.IsOnBoard = true;
                }
                else
                {
                    robot.CoorinateX = backX;
                    robot.CoorinateY = backY;
                }
            }
        }
    }

    public class ReportCommnd : ICommand
    {
        public void Execute(Robot robot)
        {
            Console.WriteLine(robot.GetReportData());
        }
    }
}