using Microsoft.VisualStudio.TestTools.UnitTesting;
using MartianRobots;

namespace MartianRobotsTests
{
    [TestClass]
    public class MartianRobotsTests
    {
        [TestMethod]
        public void ForwardMotion()
        {
            bool lostFlag;
            Map map = new Map(2, 2);
            Robot robot = new Robot(0, 0, 'N');

            lostFlag = robot.ExecuteCommands("F", map, out int x, out int y, out char dir);

            Assert.AreEqual(0, x, "Wrong x coordinate");
            Assert.AreEqual(1, y, "Wrong y coordinate");
            Assert.AreEqual('N', dir, "Wrong direction coordinate");
            Assert.AreEqual(false, lostFlag, "Robot was lost");
        }

        [TestMethod]
        public void LeftTurn()
        {
            bool lostFlag;
            Map map = new Map(2, 2);
            Robot robot = new Robot(0, 0, 'N');

            lostFlag = robot.ExecuteCommands("L", map, out int x, out int y, out char dir);

            Assert.AreEqual(0, x, "Wrong x coordinate");
            Assert.AreEqual(0, y, "Wrong y coordinate");
            Assert.AreEqual('W', dir, "Wrong direction coordinate");
            Assert.AreEqual(false, lostFlag, "Robot was lost");
        }

        [TestMethod]
        public void RightTurn()
        {
            bool lostFlag;
            Map map = new Map(2, 2);
            Robot robot = new Robot(0, 0, 'N');

            lostFlag = robot.ExecuteCommands("R", map, out int x, out int y, out char dir);

            Assert.AreEqual(0, x, "Wrong x coordinate");
            Assert.AreEqual(0, y, "Wrong y coordinate");
            Assert.AreEqual('E', dir, "Wrong direction coordinate");
            Assert.AreEqual(false, lostFlag, "Robot was lost");
        }

        [TestMethod]
        public void ComplexRoute_Inbounds()
        {
            bool lostFlag;
            Map map = new Map(2, 2);
            Robot robot = new Robot(0, 0, 'N');

            lostFlag = robot.ExecuteCommands("FRFLFRR", map, out int x, out int y, out char dir);

            Assert.AreEqual(1, x, "Wrong x coordinate");
            Assert.AreEqual(2, y, "Wrong y coordinate");
            Assert.AreEqual('S', dir, "Wrong direction coordinate");
            Assert.AreEqual(false, lostFlag, "Robot was lost");
        }

        [TestMethod]
        public void ComplexRoute_Outside()
        {
            bool lostFlag;
            Map map = new Map(2, 2);
            Robot robot = new Robot(0, 0, 'N');

            lostFlag = robot.ExecuteCommands("FRFLFF", map, out int x, out int y, out char dir);

            Assert.AreEqual(1, x, "Wrong x coordinate");
            Assert.AreEqual(2, y, "Wrong y coordinate");
            Assert.AreEqual('N', dir, "Wrong direction coordinate");
            Assert.AreEqual(true, lostFlag, "Robot was not lost");
        }

        [TestMethod]
        public void ComplexRoute_ScentIgnore()
        {
            bool lostFlag;
            Map map = new Map(2, 2);
            Robot robot1 = new Robot(0, 0, 'N');
            Robot robot2 = new Robot(0, 0, 'N');

            robot1.ExecuteCommands("FRFLFF", map, out int x, out int y, out char dir);
            lostFlag = robot2.ExecuteCommands("FRFLFFFFFRF", map, out x, out y, out dir);

            Assert.AreEqual(2, x, "Wrong x coordinate");
            Assert.AreEqual(2, y, "Wrong y coordinate");
            Assert.AreEqual('E', dir, "Wrong direction coordinate");
            Assert.AreEqual(false, lostFlag, "Robot was lost");
        }

        [TestMethod]
        public void ComplexRoute_ScentIgnore_Corner()
        {
            bool lostFlag;
            Map map = new Map(2, 2);
            Robot robot1 = new Robot(0, 0, 'N');
            Robot robot2 = new Robot(0, 0, 'N');

            robot1.ExecuteCommands("FRFLFRFF", map, out int x, out int y, out char dir);
            lostFlag = robot2.ExecuteCommands("FRFLFRFLFFFFFFLF", map, out x, out y, out dir);

            Assert.AreEqual(1, x, "Wrong x coordinate");
            Assert.AreEqual(2, y, "Wrong y coordinate");
            Assert.AreEqual('W', dir, "Wrong direction coordinate");
            Assert.AreEqual(false, lostFlag, "Robot was lost");
        }
    }
}
