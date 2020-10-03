using System.Collections.Generic;

namespace MartianRobots
{
    /**
     * Class for keeping track of robot movements
     */
    public class Map
    {
        /**
         * @var int _width Width of the map
         */
        private int _width;

        /**
         * @var int _height Height of the map
         */
        private int _height;

        /**
        * @var Dictionary<Point, bool> _scentedPositions Scented positions
        */
        private Dictionary<Point, bool> _scentedPositions;

        /**
         * Constructor
         * 
         * @param int width Width of the map
         * @param int height Height of the map
         */
        public Map(int width, int height)
        {
            this._width = width;
            this._height = height;

            this._scentedPositions = new Dictionary<Point, bool>();
        }

        /**
        * Checks if the position out of bounds
        * 
        * @param Point position Position
        * @returns bool Whether the position is out
        */
        public bool CheckIfOut(Point position)
        {
            return (position.x < 0 || position.x > this._width || position.y < 0 || position.y > this._height);
        }

        /**
        * Checks if the position is scented
        * 
        * @param Point position Position
        * @returns bool Whether the position is scented
        */
        public bool CheckIfScented(Point position)
        {
            return this._scentedPositions.ContainsKey(position);
        }

        /**
        * Adds new scented position
        * 
        * @param Point position Position
        */
        public void AddScentedPosition(Point position)
        {
            this._scentedPositions[position] = true;
        }
    }
}
