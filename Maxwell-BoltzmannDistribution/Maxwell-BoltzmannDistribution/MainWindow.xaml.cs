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
            // Hard coded simulation for starting
            Simulation_Constant.BOX_HEIGHT = 1.5;
            Simulation_Constant.BOX_WIDTH = 1.5;
            Simulation_Constant.INITIAL_SPEED = 100;
            Simulation_Constant.NUMBER_OF_PARTICULE = 900;
            Simulation_Constant.PARTICULE_RADIUS = 0.00001;
            Simulation_Constant.TIME_IN_SECONDS = 10;
            Simulation_Constant.CURRENT_GRAVITY = 9.81;

            Simulation_Constant.FLAG_END_SIMULATION = false;
            try
            {
                MC.StartSimulation();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            while (!Simulation_Constant.FLAG_END_SIMULATION)
            {
                Mouse.OverrideCursor = Cursors.Wait;
            }
            Mouse.OverrideCursor = null;
       

        }

    }
}
