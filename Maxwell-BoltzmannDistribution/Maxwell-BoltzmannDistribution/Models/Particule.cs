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

        /// <summary>
        /// main Builder of Particule object
        /// </summary>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <param name="id"></param>
        internal Particule(double pX, double pY, int id)
        {
            this.PositionX = pX;
            this.PositionY = pY;
            this.Id = id;
            // Call Function to computer direction and Speed in X axis, and Speed in Y axis
            CreateRandomSpeedAndDir(Simulation_Constant.INITIAL_SPEED);
        }
        /// <summary>
        /// Assigned Speed based on initial speed common to all particule
        /// </summary>
        /// <param name="initialSpeed"></param>
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
        /// <summary>
        /// Computing collision between two particules
        /// </summary>
        /// <param name="other"></param>
        internal void CollisionWithOtherParticule(Particule other)
        {
            // The particule A is denoted by this
            // The particle B is denoted by other

            // Difference on X axis & Y axis
            double DiffX = Math.Abs(this.PositionX - other.PositionX);
            double DiffY = Math.Abs(this.PositionY - other.PositionY);
            // Distance Between the two...
            double DistanceBetween = Math.Sqrt((DiffX * DiffX) + (DiffY * DiffY));

            // Speed Difference 
            double DiffSpeedX = this.SpeedX - other.SpeedX;
            double DiffSpeedY = this.SpeedY - other.SpeedY;

            // Compute Angle between Particules
            double cosAngle = DiffX / DistanceBetween;
            double sinAngle = DiffY / DistanceBetween;

            // Computing new Speed on X and Y for Particules after collision

            double VAx = DiffSpeedX * sinAngle * sinAngle - DiffSpeedY * sinAngle * cosAngle + other.SpeedX;
            double VAy = DiffSpeedY * cosAngle * cosAngle - DiffSpeedX * sinAngle * cosAngle + other.SpeedY;
            double VBx = DiffSpeedX * cosAngle * cosAngle + DiffSpeedY * sinAngle * cosAngle + other.SpeedX;
            double VBy = DiffSpeedY * sinAngle * sinAngle + DiffSpeedX * sinAngle * cosAngle + other.SpeedY;

            // Speed Lost factor
            double SpeedLostFac = Math.Sqrt(1 - Simulation_Constant.SPEED_LOSS_FACTOR);
            this.SetSpeedX(VAx * SpeedLostFac);
            this.SetSpeedY(VAy * SpeedLostFac);
            other.SetSpeedX(VBx * SpeedLostFac);
            other.SetSpeedY(VBy * SpeedLostFac);



        }
        /// <summary>
        /// Computing Collision with Verti. Wall
        /// </summary>
        /// <param name="particule"></param>
        internal void CollisionWithVerticalWall(Particule particule)
        {
            double ResizeFactor = Math.Sqrt(1- Simulation_Constant.SPEED_LOSS_FACTOR);
            particule.SpeedX = (particule.SpeedX * -1 * ResizeFactor);
            particule.SpeedY = (particule.SpeedY * ResizeFactor);
        }
        /// <summary>
        /// Computing Collision with Hori. Wall
        /// </summary>
        /// <param name="particule"></param>
        internal void CollisionWithHorizontalWall(Particule particule)
        {
            double ResizeFactor = Math.Sqrt(1- Simulation_Constant.SPEED_LOSS_FACTOR);
            particule.SpeedX = (particule.SpeedX * ResizeFactor);
            particule.SpeedY = (particule.SpeedY * -1 * ResizeFactor);
        }
        /// <summary>
        /// Getting Speed of a Particule
        /// </summary>
        /// <param name="particule"></param>
        /// <returns></returns>
        internal double getSpeed(Particule particule)
        {
            return Math.Sqrt((particule.SpeedX * particule.SpeedX) + (particule.SpeedY * particule.SpeedY));
        }
        /// <summary>
        /// Will the particule touche each other yes or not
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        internal Boolean ParticulesInContact(Particule other){
            return GetDistanceTo(other) < (2* Simulation_Constant.PARTICULE_RADIUS);
        }
       /// <summary>
       /// Get distance between two particule
       /// </summary>
       /// <param name="other"></param>
       /// <returns></returns>
        internal double GetDistanceTo(Particule other)
        {
            // Difference on X axis & Y axis
            double DiffX = Math.Abs(this.PositionX - other.PositionX);
            double DiffY = Math.Abs(this.PositionY - other.PositionY);
            // Distance Between the two...
            double DistanceBetween = Math.Sqrt((DiffX * DiffX) + (DiffY * DiffY));
            return DistanceBetween;
        }
        /// <summary>
        /// Make a particule move
        /// </summary>
        /// <param name="TimeH"></param>
        internal void movePaticule(double TimeH){
            this.PositionX = this.PositionX + (this.SpeedX * TimeH);
            this.PositionY = this.PositionY + ((this.SpeedY * TimeH) - ((Simulation_Constant.CURRENT_GRAVITY * TimeH * TimeH)/2 ));
            this.SpeedY = (this.SpeedY - (Simulation_Constant.CURRENT_GRAVITY * TimeH));



        }
        /// <summary>
        /// Get position of on X axis
        /// </summary>
        /// <returns></returns>
        internal double GetPositionX()
        {
            return this.PositionX;
        }
        /// <summary>
        /// Get Position on Y axis
        /// </summary>
        /// <returns></returns>
        internal double GetPositionY()
        {
            return this.PositionY;
        }
        /// <summary>
        /// Get Speed on X axis...
        /// </summary>
        /// <returns></returns>
        internal double GetSpeedX()
        {
            return this.SpeedX;
        }
        /// <summary>
        /// Get Speed on Y axis...
        /// </summary>
        /// <returns></returns>
        internal double GetSpeedY()
        {
            return this.SpeedY;
        }
        /// <summary>
        /// Get ID of the Particule
        /// </summary>
        /// <returns></returns>
        internal int GetID()
        {
            return this.Id;
        }
        /// <summary>
        /// Get Set Speed of X
        /// </summary>
        /// <param name="sX"></param>
        internal void SetSpeedX(double sX)
        {
            this.SpeedX = sX;
        }
        /// <summary>
        /// Set Speet on Y axis..
        /// </summary>
        /// <param name="sY"></param>
        internal void SetSpeedY(double sY)
        {
            this.SpeedY = sY;
        }
        /// <summary>
        /// Print info about the Particule
        /// </summary>
        /// <returns></returns>
        internal String PrintParticuleInfo()
        {
            String info = "P: " + this.Id + ",  @X: " + this.PositionX +"m, "+  "  @Y: " + this.PositionY +
                "m,  Speed@X: " + this.SpeedX + "m/s, Speed@Y " + this.SpeedY;
            return info;
        }
        
    }
}
