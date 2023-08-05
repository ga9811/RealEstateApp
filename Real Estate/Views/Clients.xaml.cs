
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Real_Estate
{
    /// <summary>
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : Window
    {
        public Clients()
        {
            InitializeComponent();


        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-D9VVUP6;Initial Catalog=RealEstateSystem;Integrated Security=True");

        public void dataselect()
        {
            try
            {
                Con.Open();
                string query = "SELECT * FROM Clients";
                SqlCommand cmd = new SqlCommand(query, Con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = DataGrid.SelectedItem as DataRowView;
                textbox_ClientID.Text = selectedRow["id"].ToString();
                textbox_ClientName.Text = selectedRow["name"].ToString();
                textbox_ClientPhone.Text = selectedRow["phone"].ToString();
                textbox_ClientEmail.Text = selectedRow["email"].ToString();
                textbox_ClientAddress.Text = selectedRow["address"].ToString();
                textbox_Requirement.Text = selectedRow["requirement"].ToString();
            }
        }

  



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clients newclient = new Clients();
            newclient.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Property pp = new Property();
            pp.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                Con.Open();
                string query = "INSERT INTO Clients (name, phone, email, address, requirement) VALUES (@name, @phone, @email, @address, @requirement)";

                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@name", textbox_ClientName.Text);
                cmd.Parameters.AddWithValue("@phone", textbox_ClientPhone.Text);
                cmd.Parameters.AddWithValue("@email", textbox_ClientEmail.Text);
                cmd.Parameters.AddWithValue("@address", textbox_ClientAddress.Text);
                cmd.Parameters.AddWithValue("@requirement", textbox_Requirement);
                

                cmd.ExecuteNonQuery();
                MessageBox.Show("The new item stored");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }


        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Con.Open();
                string query = "select * from Clients";
                SqlCommand cmd = new SqlCommand(query, Con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataGrid.ItemsSource = dt.DefaultView;

                cmd.ExecuteNonQuery();
            
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Con.Open();
                string query = "delete from clients where id=" + textbox_ClientID.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@id", textbox_ClientID.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("The item removed");
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

      

        

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                Con.Open();
                string query = "UPDATE Clients SET name=@name, phone=@phone, email=@email, address=@address WHERE id=@id";

                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@name", textbox_ClientName.Text);
                cmd.Parameters.AddWithValue("@phone", textbox_ClientPhone.Text);
                cmd.Parameters.AddWithValue("@email", textbox_ClientEmail.Text);
                cmd.Parameters.AddWithValue("@address", textbox_ClientAddress.Text);
                cmd.Parameters.AddWithValue("@id", int.Parse(textbox_ClientID.Text));

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("The item updated");
                }
                else
                {
                    MessageBox.Show("No rows updated. Verify the Client ID exists.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }


    }


} 