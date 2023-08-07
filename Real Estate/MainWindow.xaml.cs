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
using System.Data.SqlClient;
using System.Data;
using Real_Estate.Models;

namespace Real_Estate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-D9VVUP6;Initial Catalog=RealEstateSystem;Integrated Security=True");


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userType = string.Empty;

            if (combobox.SelectedItem != null)
            {
                userType = ((ComboBoxItem)combobox.SelectedItem).Content.ToString();
            }
            else
            {
                MessageBox.Show("Please select a user type.");
                return;
            }

            string userName = user.Text;
            string passWord = password1.Password;

            try
            {
                string querry = "Select * From agents where username = @username and password = @password";
                SqlCommand command = new SqlCommand(querry, connection);
                command.Parameters.AddWithValue("@username", user.Text);
                command.Parameters.AddWithValue("@password", password1.Password);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    userName = user.Text;
                    passWord = password1.Password;

                    MessageBox.Show("Successfully logged in.");

                    MainMenu mainMenu = new MainMenu(user.Text);
                    GlobalData.AgentUsername = user.Text;
                    Console.WriteLine($"username is:{mainMenu.AgentUsername}");
                    mainMenu.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Error-Invalid Login Details");
                    user.Clear();
                    password1.Clear();
                    user.Focus();
                }


            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("General error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            user.Clear();
            password1.Clear();

            user.Focus();
        }
       

    }
}
