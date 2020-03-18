using System;

namespace ToyRobotSimulator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RobotSimulator firstTestCase = new RobotSimulator("PLACE 0,0,NORTH MOVE MOVE LEFT MOVE MOVE REPORT", "0,10", "0,7", "0,0,3,3");
            firstTestCase.RunRobot();

            RobotSimulator secondTestCase = new RobotSimulator("PLACE 0,0,NORTH MOVE REPORT","0,3", "0,5","0,1,0,3");
            secondTestCase.RunRobot();

            RobotSimulator thirdTestCase = new RobotSimulator("PLACE 1,2,EAST MOVE MOVE LEFT MOVE REPORT");
            thirdTestCase.RunRobot();

            RobotSimulator invalidTestCase = new RobotSimulator("MOVE REPORT");
            invalidTestCase.RunRobot();

            Console.ReadLine();
        }
    }
}
