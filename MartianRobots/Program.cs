using System;
using System.Collections.Generic;

namespace MartianRobots
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> results = new List<string>();

            // read width and height of the map
            string input = Console.ReadLine();

            string[] coords = input.Split(' ');

            // create map
            Map map = new Map(Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]));

            input = Console.ReadLine();
            while (input != "")
            {
                // read initial position and direction of the robot
                string[] init = input.Split(' ');

                // create robot
                Robot robot = new Robot(Convert.ToInt32(init[0]), Convert.ToInt32(init[1]), init[2][0]);

                // read sequence of commands and execute it
                bool result = robot.ExecuteCommands(Console.ReadLine(), map, out int x, out int y, out char dir);

                // add to the list of results
                results.Add(x + " " + y + " " + dir + (result ? " LOST" : ""));

                input = Console.ReadLine();
            };

            // output
            foreach (string result in results)
            {
                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }
}
