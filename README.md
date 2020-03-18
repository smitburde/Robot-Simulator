# Robot-Simulator
Description:
. The application is a simulation of a robot moving on a square tabletop, of dimensions 10 units x 10 units.

. There are obstruction on the table like Hole, Rock and Spinner.
. Hole -> This will make the robot to move to connected location.
. Rock -> This will not allow robot to move.
. Spinner -> This will make robot turn 90 degree.

. The robot is free to roam around the surface of the table, but must be prevented from falling to destruction and cannot go beyond the boundry. Any movement 
that would result in the robot falling from the table must be prevented, however further valid movement commands must still 
be allowed.

. Create an application that can read in commands of the following form -
PLACE X,Y, DIRECTION
(MOVE LEFT RIGHT)
REPORT
Rock-Coordinates
Spinner-Coordinate
Hole-Coordinate and connected coordinates

.See the example parameters

PLACE 0,0,NORTH MOVE MOVE LEFT MOVE MOVE REPORT", "0,10", "0,7", "0,0,3,3"

. PLACE will put the robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST. 
. The origin (0,0) can be considered to be the SOUTH WEST most corner.
. The first valid command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The application should discard all commands in the sequence until a valid PLACE command has been executed.
. MOVE will move the robot one unit forward in the direction it is currently facing.
. LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.
. REPORT will announce the X,Y and Direction of the robot. This can be in any form, but standard output is sufficient.
. Rock-Coordinates X,Y will tell the rock position.
. Spinner-Coordinate X,Y will tell the spinner position and wil make robot turn 90 degree.
. Hole-Coordinate and connected coordinates will tell the hole postion and connected location ordinates.

. A robot that is not on the table can choose the ignore the MOVE, LEFT, RIGHT and REPORT commands.

Constraints:
The robot must not fall off the table during movement and cannot cross the obstruction as stated. This also includes the initial placement of the toy robot. 
Any move that would cause the robot to fall must be ignored.

Example Input and Output:
a)
PLACE 0,0,NORTH 
MOVE MOVE LEFT MOVE MOVE 
REPORT",
"0,10", 
"0,7", 
"0,0,3,3"

Output: 1,5,WEST

b)
PLACE 0,0,NORTH
LEFT
REPORT

Output: 0,0,WEST

c)
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT

Output: 3,3,NORTH

This application requires .Net Core 2.2
