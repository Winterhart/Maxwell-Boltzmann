using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maxwell_BoltzmannDistribution.Simulation;
using System.Threading;

namespace Maxwell_BoltzmannDistribution.Controller
{
    internal class MainController
    {
        internal MainController()
        {

        }
        internal void StartSimulation()
        {
            MainSimulation Simulation = new MainSimulation();
            Thread GoSimulation = new Thread(Simulation.Start);
            GoSimulation.Priority = ThreadPriority.Highest;
            GoSimulation.Start();
         
        }
    }
}
