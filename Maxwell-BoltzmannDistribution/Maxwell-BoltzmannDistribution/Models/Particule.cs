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
            bool SideX = Simulation_Constant.RANDOM.Next(100) % 2 == 0;
            bool SideY = Simulation_Constant.RANDOM.Next(100) % 2 == 0;

            if (!SideX) { this.SpeedX = this.SpeedX * -1; }
            if (!SideY) { this.SpeedY = this.SpeedY * -1; }  

           



        }

        internal double getSpeed(Particule particule)
        {
            return Math.Sqrt((particule.SpeedX * particule.SpeedX) + (particule.SpeedY * particule.SpeedY));
        }
        internal Boolean ParticulesInContact(Particule other){
            return GetDistanceTo(other) < (2* Simulation_Constant.PARTICULE_RADIUS);
        }
        internal double GetDistanceTo(Particule other)
        {
            double distance = Math.Sqrt(((this.PositionX - other.PositionX) * (this.PositionX - other.PositionX)) + ((this.PositionY - other.PositionY) * (this.PositionY - other.PositionY)));
            return distance;
        }
        internal void movePaticule(double TimeH){
            this.PositionX = this.PositionX + (this.SpeedX * TimeH);
            this.PositionY = this.PositionY + ((this.SpeedY * TimeH) - ((Simulation_Constant.CURRENT_GRAVITY * TimeH * TimeH)/2 ));


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
