using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxwell_BoltzmannDistribution.Models
{
    internal class Box
    {
        private double Width;
        private double Height;
        
        Boolean ElasticCollisionWithSide = true;
        /// <summary>
        /// Size of the box is given in meters...
        /// </summary>
        /// <param name="sizeX"></param>
        /// <param name="sizeY"></param>
        internal Box(double sizeX, double sizeY)
        {
            this.Width = sizeX;
            this.Height = sizeY; 
        }


    }
}
