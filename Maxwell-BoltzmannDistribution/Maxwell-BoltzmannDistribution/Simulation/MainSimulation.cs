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
            // To Simulate all Particules and not miss any Collision will will have to increase time very very slowly...
            double TimeStep = (Convert.ToDouble(Simulation_Constant.TIME_IN_SECONDS) / 10000 );
            double CurrentTime = 0.00001;
            while (CurrentTime <= Simulation_Constant.TIME_IN_SECONDS)
            {




                CurrentTime = CurrentTime + TimeStep;

            }





                // Throw that before Quiting...
            Console.WriteLine("The time of simu : " + Simulation_Constant.TIME_IN_SECONDS + " The currentTime  " + CurrentTime + " Time Step " + TimeStep);
            Simulation_Constant.FLAG_END_SIMULATION = true;

        }

        internal double CreateRandomNumber(double min, double max)
        {
            Random r = new Random();
            return r.NextDouble() * (max - min) + min;
        }

    }
}
