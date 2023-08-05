using Real_Estate.Controller;
using Real_Estate.DAO;
using Real_Estate.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Real_Estate
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private ScheduleModel agentSchedule;
        public MainWindow mainWindow;
       
        public string AgentUsername { get; set; }
        public MainMenu()
        {
            mainWindow = new MainWindow();
            InitializeComponent();
            // TestLoadData();
            LoadData();
        }
        public MainMenu(string agentUsername)
        {
            InitializeComponent();
            this.AgentUsername = agentUsername;
            LoadData();
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            agentSchedule = appointmentdataGrid.SelectedItem as ScheduleModel;
            if (agentSchedule == null)
            {
                return;
            }
        }

        public void LoadData()
        {
            UserService userService = new UserService();
                Agents agent = new Agents();
            
            Console.WriteLine($"username is:{AgentUsername}");
             
                agent = userService.getAgentByUserName(AgentUsername);
                if (agent != null)
                {
                    Console.WriteLine($"Agent ID: {agent.id}");
                    Console.WriteLine($"Agent Name: {agent.name}");
                    Console.WriteLine($"Agent Phone: {agent.phone}");

                    var appointments = userService.getAgentSchedule(agent.id);
                    appointmentdataGrid.ItemsSource = appointments;
                }

            try
            {
                var trackStatus = userService.getPropertyStatus();
                if (trackStatus != null && trackStatus.Count > 0)
                {
                    PropertyModel property = trackStatus[0];
                    Console.WriteLine($"Property ID: {property.id}");
                    trackDataGrid.ItemsSource = trackStatus;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving property status: {ex.Message}");
            }




        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Property property = new Property();

            property.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Clients clients = new Clients();
            clients.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Agent agent = new Agent();
            agent.Show();
            this.Close();
        }

        private void trackDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

     
    }
}
