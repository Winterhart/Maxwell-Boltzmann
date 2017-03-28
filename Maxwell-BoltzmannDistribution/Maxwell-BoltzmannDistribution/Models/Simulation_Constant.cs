using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxwell_BoltzmannDistribution.Models
{
    public static class Simulation_Constant
    {
        /// <summary>
        /// Data must be in meter, meter/s and other...
        /// </summary>
        public static double INITIAL_SPEED { get; set; }
        public static double PARTICULE_RADIUS { get; set; }
        public static int NUMBER_OF_PARTICULE { get; set; }
        public static double BOX_HEIGHT { get; set; }
        public static double BOX_WIDTH { get; set; }
        public static int TIME_IN_SECONDS { get; set; }
        public static bool FLAG_END_SIMULATION { get; set; }
        public static Random RANDOM = new Random();

    }
}
