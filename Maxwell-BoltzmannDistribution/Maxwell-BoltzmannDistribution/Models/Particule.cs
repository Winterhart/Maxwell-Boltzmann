using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxwell_BoltzmannDistribution.Models
{
    internal class Particule
    {
        private double PositionX;
        private double PositionY;
        private double SpeedX;
        private double SpeedY;
        private int Id;
        private double Direction;

        internal Particule(double pX, double pY, int id)
        {
            this.PositionX = pX;
            this.PositionY = pY;
            this.Id = id;
            // Call Function to computer direction and Speed in X axis, and Speed in Y axis
            CreateRandomSpeedAndDir(Simulation_Constant.INITIAL_SPEED);
        }

        internal void CreateRandomSpeedAndDir(double initialSpeed)
        {
            
            double FactorSX = Simulation_Constant.RANDOM.NextDouble();
            this.SpeedX = Math.Sqrt(initialSpeed * initialSpeed * FactorSX);
            this.SpeedY = Math.Sqrt((1- FactorSX) * initialSpeed * initialSpeed);
            
            // Compute direction...
        }

        
        internal double GetPositionX()
        {
            return this.PositionX;
        }
        internal double GetPositionY()
        {
            return this.PositionY;
        }
        internal double GetSpeedX()
        {
            return this.SpeedX;
        }
        internal double GetSpeedY()
        {
            return this.SpeedY;
        }
        internal int GetID()
        {
            return this.Id;
        }

        // Add all function...
        // Compute direction by using Speed X, Speed Y
    }
}
