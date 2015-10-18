using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.App.Model;

namespace ToyRobot.App.Logic
{
    public static class HeadingService
    {
        private static IHeading[] allHeadings = { new NorthHeading(), new SouthHeading(), new EastHeading(), new WestHeading() };

        public static IHeading GetHeading(int degree)
        {
            return allHeadings.Single(h => h.IsCurrentHeading(degree));
        }

    }
}
