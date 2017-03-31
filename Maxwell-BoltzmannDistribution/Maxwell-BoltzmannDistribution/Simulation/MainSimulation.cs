using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maxwell_BoltzmannDistribution.Models;


namespace Maxwell_BoltzmannDistribution.Simulation
{
    internal class MainSimulation
    {
        internal Box MainBox;
        internal Particule[] AllParticules;
        internal void Start()
        {

            // Creating the BOX
            MainBox = new Box(Simulation_Constant.BOX_WIDTH, Simulation_Constant.BOX_HEIGHT);

            // Creating All Particule, with random value...
            AllParticules = new Particule[Simulation_Constant.NUMBER_OF_PARTICULE];
            Random r = new Random();
            for (int i = 0; i < Simulation_Constant.NUMBER_OF_PARTICULE; i++)
            {
                // Randomly Generate Position inside Box

                double PositionXInBox = r.NextDouble() * (Simulation_Constant.BOX_WIDTH);
                double PositionYInBox = r.NextDouble() * (Simulation_Constant.BOX_HEIGHT);
                
                // Create New particule with those position

                Particule parti = new Particule(PositionXInBox, PositionYInBox, i);
                AllParticules[i] = parti;


            }

            Console.WriteLine("ALL Particule are created");
            Console.WriteLine(AllParticules[0].PrintParticuleInfo());
            AllParticules[0].movePaticule(0.001);
            Console.WriteLine(AllParticules[0].PrintParticuleInfo());
            AllParticules[0].movePaticule(0.01);
            Console.WriteLine(AllParticules[0].PrintParticuleInfo());



                // Throw that before Quiting...
                Simulation_Constant.FLAG_END_SIMULATION = true;

        }

        internal double CreateRandomNumber(double min, double max)
        {
            Random r = new Random();
            return r.NextDouble() * (max - min) + min;
        }

    }
}
