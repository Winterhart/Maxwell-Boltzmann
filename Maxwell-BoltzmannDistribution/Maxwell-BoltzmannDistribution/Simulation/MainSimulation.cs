using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maxwell_BoltzmannDistribution.Models;
using System.Xml;
using System.IO;


namespace Maxwell_BoltzmannDistribution.Simulation
{
    internal class MainSimulation
    {
        internal Box MainBox;
        internal Particule[] AllParticules;
        internal int[] AllDataSorted = new int[20];
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
                // Collision with Particule
                for (int i = 0; i < AllParticules.Length; i++)
                {
                    for (int j = 0; j < AllParticules.Length; j++)
                    {
                        if (i != j)
                        {
                            if (AllParticules[i].ParticulesInContact(AllParticules[j]))
                            {
                                AllParticules[i].CollisionWithOtherParticule(AllParticules[j]);
                                break;
                            }
                        }
                    }
                }

                    // Collision with Walls
                    foreach (Particule p in AllParticules)
                    {
                        if (p.GetPositionX() >= Simulation_Constant.BOX_WIDTH || p.GetPositionX() <= 0) { p.CollisionWithVerticalWall(); }
                        if (p.GetPositionY() >= Simulation_Constant.BOX_HEIGHT || p.GetPositionY() <= 0) { p.CollisionWithHorizontalWall(); }
                        
                    }

                // Make Particule move
                    foreach (Particule p in AllParticules) { p.MoveParticule(TimeStep); }

                CurrentTime = CurrentTime + TimeStep;
                Console.WriteLine(CurrentTime);

            }

            // Sort Data
     
            foreach (Particule p in AllParticules)
            {
                double Percentage = ( p.GetSpeed() / Simulation_Constant.INITIAL_SPEED );
                int d = Convert.ToInt32(Percentage*100);
                for (int i = 0; i < AllDataSorted.Length; i++)
                {
                   if( (d >= (5 * i )) && (d < (5* (i+1))) ){
                       AllDataSorted[i]++;
                       break;
                   }
                }
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            try
            {
                
                if (File.Exists(path + @"\ParticleDistribution.xml"))
                {
                    File.Delete(path + @"\ParticleDistribution.xml");
                }
                if (File.Exists(path + @"\Particles.xml"))
                {
                    File.Delete(path + @"\Particles.xml");
                }
                using (XmlWriter writer = XmlWriter.Create(path + @"\ParticleDistribution.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("object");
                    int i = 0;
                    foreach (int d in AllDataSorted)
                    {
                        i++;
                        writer.WriteStartElement("SortedParticules");
                        writer.WriteElementString("Distribution", i.ToString());
                        writer.WriteElementString("PercentageSpeed", d.ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                }
                // Class Particule in Group insert them in XML data chart

                using (XmlWriter writer = XmlWriter.Create(path + @"\Particles.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("object");
                    foreach (Particule p in AllParticules)
                    {
                        writer.WriteStartElement("AllParticule");
                        writer.WriteElementString("ID", p.GetID().ToString());
                        writer.WriteElementString("Speed", p.GetSpeed().ToString());
                        writer.WriteElementString("PositionX", p.GetPositionX().ToString());
                        writer.WriteElementString("PositionY", p.GetPositionY().ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();



                }
            }
            catch (Exception ee) { Console.WriteLine(ee.Message); }






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
