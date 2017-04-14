using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Maxwell_BoltzmannDistribution.Controller;
using Maxwell_BoltzmannDistribution.Models;

namespace Maxwell_BoltzmannDistribution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainController MC;
        public MainWindow()
        {
            MC = new MainController();
            InitializeComponent();
        }

        private void Start_Sim(object sender, RoutedEventArgs e)
        {
            String Status = "";
            try
            {

                Status = "WRONG BOX HEIGHT";
                Simulation_Constant.BOX_HEIGHT = Convert.ToDouble(BoxHeight.Text);
                Status = "WRONG BOX WIDTH";
                Simulation_Constant.BOX_WIDTH = Convert.ToDouble(BoxWidth.Text);
                Status = "WRONG Initial Speed";
                Simulation_Constant.INITIAL_SPEED = Convert.ToDouble(InitialSpeed.Text);
                Status = "WRONG Number of Particule";
                Simulation_Constant.NUMBER_OF_PARTICULE = Convert.ToInt32(NumberOfParticule.Text);
                Status = "WRONG time of Experience (Must be an integer)";
                Simulation_Constant.TIME_IN_SECONDS = Convert.ToInt32(Time.Text);
                Status = "Wrong Speed Loss Factor";
                Simulation_Constant.SPEED_LOSS_FACTOR = Convert.ToDouble(SpeedLoss.Text);
                Status = "WRONG Gravity";
                Simulation_Constant.CURRENT_GRAVITY = Convert.ToDouble(Gravity.Text);
                Status = "WRONG Particule Radius";
                Simulation_Constant.PARTICULE_RADIUS = Convert.ToDouble(ParticuleRadius.Text);
            }
            catch (Exception ee)
            {
                MessageBox.Show("One of the input is not correctly inserted Status of the ERROR: " + Status);
                return;
            }
                Simulation_Constant.FLAG_END_SIMULATION = false;

            try
            {
                MC.StartSimulation();
            }
            catch (Exception ee)
            {
                MessageBox.Show("ERROR: " + ee.Message);
            }
            while (!Simulation_Constant.FLAG_END_SIMULATION)
            {
                Mouse.OverrideCursor = Cursors.Wait;
            }
            Mouse.OverrideCursor = null;

            MessageBox.Show("...");
       

        }

    }
}
