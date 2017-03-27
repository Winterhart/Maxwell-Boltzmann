using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxwell_BoltzmannDistribution.Models
{
    internal class Particules
    {
        private double PositionX;
        private double PositionY;
        private double SpeedX;
        private double SpeedY;
        private int Id;

        internal Particules(double pX, double pY, double sX, double sY, int id)
        {
            this.PositionX = pX;
            this.PositionY = pY;
            this.SpeedX = sX;
            this.SpeedY = sY;
            this.Id = id;
        }

        // Add all function...
    }
}
