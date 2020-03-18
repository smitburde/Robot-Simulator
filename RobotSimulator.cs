namespace ToyRobotSimulator
{
    public class RobotSimulator
    {
        private Robot _robot;

        private ICommand _command;

        private readonly string _robotRunCommand;

        private CommandParser _commandParser;

        public RobotSimulator(string robotRunCommand, string rock = null, string spinner = null, string hole_and_location = null)
        {
            _robotRunCommand = robotRunCommand;
            _robot = new Robot(new Board(10, 10, rock: rock, spinner: spinner, hole_and_location: hole_and_location))
            {
                IsOnBoard = false
            };
            _commandParser = new CommandParser(robotRunCommand);
        }

        public void RunRobot()
        {
            foreach (var cmd in _commandParser.RobotCommnads)
            {
                _command = _commandParser.GetCommand(cmd);
                _command.Execute(_robot);
            }
        }
    }
}