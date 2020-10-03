namespace MartianRobots
{
    /**
     * Class for moving robots around
     */
    public class Robot
    {
        /**
         * @var Point _postion Current position of the robot
         */
        private Point _position;

        /**
         * @var Point _velocity Current velocity vector of the robot
         */
        private Point _velocity;

        /**
         * Constructor
         * 
         * @param int x Initial x coordinate of the robot
         * @param int y Initial y coordinate of the robot
         * @param char dir Initial direction of the robot
         */
        public Robot(int x, int y, char dir)
        {
            this._position = new Point(x, y);

            switch (dir)
            {
                case 'N':
                    this._velocity = new Point(0, 1);

                    break;

                case 'E':
                    this._velocity = new Point(1, 0);

                    break;

                case 'S':
                    this._velocity = new Point(0, -1);

                    break;

                case 'W':
                    this._velocity = new Point(-1, 0);

                    break;
            }
        }

        /**
         * Moves robot around based on the sequence of commands
         * 
         * @param string commands Sequence of commands
         * @param Map map Map on which the robot moves
         * @param out int x Final x coordinate of the robot
         * @param out int y Final y coordinate of the robot
         * @param out char dir Final direction of the robot
         * @returns bool Whether the robot was lost
         */
        public bool ExecuteCommands(string commands, Map map, out int x, out int y, out char dir)
        {
            int oldY;
            Point newPosition;
            bool lostFlag = false;

            foreach (char command in commands)
            {
                switch (command)
                {
                    case 'L':
                        oldY = this._velocity.y;
                        this._velocity.y = this._velocity.x;
                        this._velocity.x = -oldY;

                        break;

                    case 'R':
                        oldY = this._velocity.y;
                        this._velocity.y = -this._velocity.x;
                        this._velocity.x = oldY;

                        break;

                    case 'F':
                        newPosition = this._position + this._velocity;

                        if (map.CheckIfOut(newPosition))
                        {
                            if (!map.CheckIfScented(this._position))
                            {
                                map.AddScentedPosition(this._position);
                                lostFlag = true;
                            }
                        } else
                        {
                            this._position = newPosition;
                        }

                        break;
                }

                if (lostFlag)
                {
                    break;
                }
            }

            x = this._position.x;
            y = this._position.y;
            
            if (this._velocity.x == 0)
            {
                if (this._velocity.y > 0)
                {
                    dir = 'N';
                } else
                {
                    dir = 'S';
                }
            } else if (this._velocity.x > 0)
            {
                dir = 'E';
            } else
            {
                dir = 'W';
            }

            return lostFlag;
        }
    }
}
