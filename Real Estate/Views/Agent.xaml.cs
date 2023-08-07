using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Web.UI.WebControls;
using Real_Estate.Models;

namespace Real_Estate
{
    /// <summary>
    /// Interaction logic for Agent.xaml
    /// </summary>
    public partial class Agent : Window
    {
        public Agent()
        {
            InitializeComponent();
        }

        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            string agentType = ((ComboBoxItem)typebox.SelectedItem).Content.ToString();
            string agentUsername = usernamebox.Text;
            string agentPassword = passwordbox.Text;
            string agentName = namebox.Text;
            string agentPhone = phonebox.Text;
            string agentEmail = emailbox.Text;
            string agentAddress = addressbox.Text;

            string connectionString = @"Data Source=DESKTOP-D9VVUP6;Initial Catalog=RealEstateSystem;Integrated Security=True";
            string query = "INSERT INTO agents (user_type, username, password, name, phone, email, address) VALUES (@Type, @Username, @Password, @Name, @Phone, @Email, @Address)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Type", agentType);
                    command.Parameters.AddWithValue("@Username", agentUsername);
                    command.Parameters.AddWithValue("@Password", agentPassword);
                    command.Parameters.AddWithValue("@Name", agentName);
                    command.Parameters.AddWithValue("@Phone", agentPhone);
                    command.Parameters.AddWithValue("@Email", agentEmail);
                    command.Parameters.AddWithValue("@Address", agentAddress);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            MessageBox.Show("Data added successfully.");
        }


        private void clear_Click(object sender, RoutedEventArgs e)
        {
            idbox.Clear();
            namebox.Clear();
            phonebox.Clear();
            emailbox.Clear();
            addressbox.Clear();
            usernamebox.Clear();
            passwordbox.Clear();


        }
        private void searchbutton_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-D9VVUP6;Initial Catalog=RealEstateSystem;Integrated Security=True";
            string query = "select * from agents where id = @id OR name = @name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", idbox.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", namebox.Text.Trim());

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        idbox.Text = reader["id"].ToString();
                        typebox.SelectedItem = typebox.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == reader["user_type"].ToString());
                        namebox.Text = reader["name"].ToString();
                        phonebox.Text = reader["phone"].ToString();
                        emailbox.Text = reader["email"].ToString();
                        addressbox.Text = reader["address"].ToString();
                        usernamebox.Text = reader["username"].ToString();
                        passwordbox.Text = reader["password"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No agent found");
                    }
                }
            }
        }



        private void editbutton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-D9VVUP6;Initial Catalog=RealEstateSystem;Integrated Security=True");
            connection.Open();

            if (connection.State == System.Data.ConnectionState.Open)
            {
                string query = "update agents set user_type = @type, name = @name, phone = @phone, email = @email, address = @address, username = @username, password = @password WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@id", idbox.Text);
                cmd.Parameters.AddWithValue("@type", ((ComboBoxItem)typebox.SelectedItem).Content.ToString());
                cmd.Parameters.AddWithValue("@name", namebox.Text);
                cmd.Parameters.AddWithValue("@phone", phonebox.Text);
                cmd.Parameters.AddWithValue("@email", emailbox.Text);
                cmd.Parameters.AddWithValue("@address", addressbox.Text);
                cmd.Parameters.AddWithValue("@username", usernamebox.Text);
                cmd.Parameters.AddWithValue("@password", passwordbox.Text);

                int dataUpdated = cmd.ExecuteNonQuery();

                if (dataUpdated > 0)
                {
                    MessageBox.Show("Sucessefully updated");
                }
                else
                {
                    MessageBox.Show("Something's wrong, please try again");
                }

                connection.Close();
            }
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            string agentID = idbox.Text;

            string connectionString = @"Data Source=DESKTOP-D9VVUP6;Initial Catalog=RealEstateSystem;Integrated Security=True";
            string query = "DELETE FROM agents WHERE id = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", agentID);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            MessageBox.Show("Data deleted successfully.");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu(GlobalData.AgentUsername);

            mainMenu.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Property property = new Property();

            property.Show();
        
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Clients clients = new Clients();
            clients.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }
    }
}