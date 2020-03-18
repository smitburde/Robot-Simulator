namespace ToyRobotSimulator
{
    public class Robot
    {
        private int _x = 0;

        private int _y = 0;

        public int CoorinateY { get => _y; set => _y = value; }

        public int CoorinateX { get => _x; set => _x = value; }

        public Direction Direction { get => _direction; set => _direction = value; }

        public bool IsOnBoard { get => _onBoard; set => _onBoard = value; }

        public Board Board { get => _board; set => _board = value; }

        private bool _onBoard = false;

        private Board _board;

        private Direction _direction;

        public Robot(Board board)
        {
            Board = board ?? null;
        }

        public void MoveForword()
        {
            if (IsOnBoard)
            {
                int x = CoorinateX;
                int y = CoorinateY;

                switch (_direction)
                {
                    case Direction.NORTH:
                        y = CoorinateY + 1;
                        break;
                    case Direction.EAST:
                        x = CoorinateX + 1;
                        break;
                    case Direction.SOUTH:
                        y = CoorinateY - 1;
                        break;
                    case Direction.WEST:
                        x = CoorinateX - 1;
                        break;
                }

                if (Board.IsValidPosition(x, y))
                {
                    int backX = x;
                    int backY = y;
                    if (Board.IsObstructionEncountered(Obstruction.HOLE, x, y))
                    {
                        var location = Board._hole_and_location.Split(",");
                        x = int.Parse(location[2]);
                        y = int.Parse(location[3]);
                    }
                    if (!Board.IsObstructionEncountered(Obstruction.ROCK, x, y))
                    {
                        CoorinateX = x;
                        CoorinateY = y;

                        if (Board.IsObstructionEncountered(Obstruction.SPINNER, CoorinateX, CoorinateY))
                        {
                            if (IsOnBoard)
                            {
                                switch (_direction)
                                {
                                    case Direction.NORTH:
                                        Direction = Direction.SOUTH;
                                        break;
                                    case Direction.WEST:
                                        Direction = Direction.EAST;
                                        break;
                                    case Direction.SOUTH:
                                        Direction = Direction.NORTH;
                                        break;
                                    case Direction.EAST:
                                        Direction = Direction.WEST;
                                        break;
                                }
                            }
                        }
                    }
                    else {
                        CoorinateX = backX;
                        CoorinateY = backY;
                    }
                }
            }
        }

        public void TurnLeft()
        {
            if (IsOnBoard)
            {
                switch (_direction)
                {
                    case Direction.NORTH:
                        Direction = Direction.WEST;
                        break;
                    case Direction.WEST:
                        Direction = Direction.SOUTH;
                        break;
                    case Direction.SOUTH:
                        Direction = Direction.EAST;
                        break;
                    case Direction.EAST:
                        Direction = Direction.NORTH;
                        break;
                }
            }
        }

        public void TurnRight()
        {
            if (IsOnBoard)
            {
                switch (_direction)
                {
                    case Direction.NORTH:
                        Direction = Direction.EAST;
                        break;
                    case Direction.EAST:
                        Direction = Direction.SOUTH;
                        break;
                    case Direction.SOUTH:
                        Direction = Direction.WEST;
                        break;
                    case Direction.WEST:
                        Direction = Direction.NORTH;
                        break;
                }
            }
        }

        public string GetReportData()
        {
            return $"{_x} {_y} {_direction.ToString()}";
        }
    }

    public class Board
    {
        private readonly int _width;

        private readonly int _height;

        internal readonly string _hole_and_location;

        private readonly string _rock;

        private readonly string _spinner;

        public Board(int width, int height, string hole_and_location = null, string rock = null, string spinner = null)
        {
            _width = width;
            _height = height;
            _hole_and_location = hole_and_location;
            _rock = rock;
            _spinner = spinner;
        }

        public bool IsValidXCoordinate(int x)
        {
            return x >= 0 && x < _width;
        }


        public bool IsValidYCoordinate(int y)
        {
            return y >= 0 && y < _height;
        }

        public bool IsValidPosition(int x, int y)
        {
            return IsValidXCoordinate(x) && IsValidYCoordinate(y);
        }

        public bool IsObstructionEncountered(Obstruction obstruction, int x, int y)
        {
            string obj = string.Empty;
            switch (obstruction)
            {
                case Obstruction.HOLE:
                    obj = _hole_and_location;
                    break;
                case Obstruction.ROCK:
                    obj = _rock;
                    break;
                case Obstruction.SPINNER:
                    obj = _spinner;
                    break;
            }

            bool res = false;
            if (!string.IsNullOrEmpty(obj))
            {
                var coordinates = obj.Split(",");
                if (x == int.Parse(coordinates[0]) && y == int.Parse(coordinates[1]))
                {
                    res = true;
                }
            }
            return res;
        }
    }

    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    public enum Obstruction
    {
        ROCK,
        SPINNER,
        HOLE
    }

    public class HelperClass
    {
        public static Direction GetEnumFromString(string enumStr)
        {
            System.Enum.TryParse<Direction>(enumStr, true, out Direction direction);
            return direction;
        }
    }
}
