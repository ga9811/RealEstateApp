using Real_Estate.Controller;
using Real_Estate.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
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
using Real_Estate.Models;
using System.Data;
using System.Web.UI.WebControls;

namespace Real_Estate
{
    /// <summary>
    /// Interaction logic for Property.xaml
    /// </summary>
    public partial class Property : Window
    {
        private ScheduleModel agentSchedule;
        public MainWindow mainWindow;
      
        UserService userService = new UserService();
     

        



        // Constructor
        
        public Property()
        {
            InitializeComponent();
            populate();
          
        }

    

      
        
        private void btn_search_by_id_Click(object sender, RoutedEventArgs e)
        {
           
            
                try
                {
                    int propertyId = int.Parse(txt_property_id.Text);
             
                PropertyModel foundProperty = userService.GetPropertyById(propertyId);
                    
                    if (foundProperty != null)
                    {
                    MessageBox.Show($"Found Property Details: ID = {foundProperty.id}, Type = {foundProperty.type}", "Debugging Info");
                    // Put the found property in a list and bind to the DataGrid
                    List<PropertyModel> properties = new List<PropertyModel> { foundProperty };
                        propertyDataGrid.ItemsSource = properties;

                    txt_property_id.Text = foundProperty.id.ToString();
                    cmb_property_type.SelectedItem = foundProperty.type;
                    txt_square_feet.Text = foundProperty.square_feet?.ToString();
                    txt_price.Text = foundProperty.price?.ToString("0.##");
                    txt_address.Text = foundProperty.address;
                    comb_bedrooms.SelectedItem = foundProperty.bedrooms?.ToString();
                   // comb_bedrooms.SelectedItem = "3";
                    comb_bathrooms.SelectedItem = foundProperty.bathrooms?.ToString();
                    txt_year_built.Text = foundProperty.year_of_build?.ToString();
                    cmb_offer.Text = foundProperty.offer_type;
                    cmb_inspection.SelectedItem = foundProperty.inspection_status;

                    cmb_repairs.SelectedItem = foundProperty.repair_status;



                    cbx_balcony.IsChecked = foundProperty.balcony;
                    cbx_pool.IsChecked = foundProperty.pool;
                    cbx_backyard.IsChecked = foundProperty.backyard;
                    cbx_garage.IsChecked = foundProperty.garage;

                }
                else
                    {
                        MessageBox.Show("Property not found.", "Search Result");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error");
                }
            
          
        }


        

        private void btn_add_property_Click(object sender, RoutedEventArgs e)
        {
            PropertyModel newProperty = new PropertyModel();
            if (newProperty.photo != null && !(newProperty.photo is byte[]))
            {
                throw new InvalidOperationException("Photo must be a byte array");
            }

            // Using the provided control names
            if (!string.IsNullOrEmpty(txt_property_id.Text))
                newProperty.id = int.Parse(txt_property_id.Text);
            newProperty.type = (cmb_property_type.SelectedItem as ComboBoxItem)?.Content?.ToString();
            if (!string.IsNullOrEmpty(txt_square_feet.Text))
                newProperty.square_feet = int.Parse(txt_square_feet.Text);
            if (!string.IsNullOrEmpty(txt_price.Text))
                newProperty.price = decimal.Parse(txt_price.Text);
            newProperty.address = txt_address.Text;
            if (comb_bedrooms.SelectedItem != null)
                newProperty.bedrooms = comb_bedrooms.SelectedIndex;
            if (comb_bathrooms.SelectedItem != null)
                newProperty.bathrooms = comb_bathrooms.SelectedIndex;
            if (!string.IsNullOrEmpty(txt_year_built.Text))
                newProperty.year_of_build = int.Parse(txt_year_built.Text);
            newProperty.offer_type = (cmb_offer.SelectedItem as ComboBoxItem)?.Content?.ToString();
            newProperty.inspection_status = (cmb_inspection.SelectedItem as ComboBoxItem)?.Content?.ToString();
            newProperty.repair_status = (cmb_repairs.SelectedItem as ComboBoxItem)?.Content?.ToString();
            newProperty.balcony = cbx_balcony.IsChecked ?? false;
            newProperty.pool = cbx_pool.IsChecked ?? false;
            newProperty.backyard = cbx_backyard.IsChecked ?? false;
            newProperty.garage = cbx_garage.IsChecked ?? false;


            userService.AddProperty(newProperty);
            populate();

            MessageBox.Show("Property Added Successfully!");

        }

        private void propertyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

         PropertyModel   selectedProperty = propertyDataGrid.SelectedItem as PropertyModel ;
            //MessageBox.Show($"Found Property Details: ID = {selectedProperty.id}, Type = {selectedProperty.type}", "Debugging Info");
            if (selectedProperty !=null)
            {
               
                txt_property_id.Text = selectedProperty.id.ToString();
                txt_square_feet.Text = selectedProperty.square_feet?.ToString();
                txt_price.Text = selectedProperty.price?.ToString("0.##");
                txt_address.Text = selectedProperty.address;
                txt_year_built.Text = selectedProperty.year_of_build?.ToString();
                cbx_balcony.IsChecked = selectedProperty.balcony;
                cbx_pool.IsChecked = selectedProperty.pool;
                cbx_backyard.IsChecked = selectedProperty.backyard;
                cbx_garage.IsChecked = selectedProperty.garage;
            }
            else if (propertyDataGrid.SelectedItem is DataRowView rowView) 
            {
                txt_property_id.Text = rowView["id"].ToString();
                txt_square_feet.Text = rowView["square_feet"]?.ToString();
                txt_price.Text = decimal.TryParse(rowView["price"].ToString(), out var price) ? price.ToString("0.##") : "";
                txt_address.Text = rowView["address"].ToString();
                txt_year_built.Text = rowView["year_of_build"]?.ToString();
                cbx_balcony.IsChecked = rowView["balcony"] as bool?;
                cbx_pool.IsChecked = rowView["pool"] as bool?;
                cbx_backyard.IsChecked = rowView["backyard"] as bool?;
                cbx_garage.IsChecked = rowView["garage"] as bool?;
            }
        }

        

        private void populate()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-D9VVUP6;Initial Catalog=RealEstateSystem;Integrated Security=True");
            connection.Open();
            string query = "select * from property";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            propertyDataGrid.ItemsSource = ds.Tables[0].DefaultView;
            connection.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clients clients = new Clients();
            clients.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Agent agent = new Agent();
            agent.Show();
            this.Close();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void MainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu(GlobalData.AgentUsername);
        //mainMenu.LoadData();   
            mainMenu.Show();
            
            this.Close();
        }

        private void btn_delete_property_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_property_id.Text))
            {
                MessageBox.Show("Please enter a property ID.");
                return;
            }

            
            if (!int.TryParse(txt_property_id.Text, out int propertyId))
            {
                MessageBox.Show("Invalid property ID.");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this property?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                UserService userService = new UserService();
                int affectedRows = userService.DeleteProperty(propertyId);

                if (affectedRows > 0)
                {
                    MessageBox.Show("Property deleted successfully.");

                    populate();
                    txt_property_id.Clear();

                    
                }
                else
                {
                    MessageBox.Show("Error while deleting property. Ensure the property ID exists.");
                }
            }
        }

        private void btn_update_property_Click_1(object sender, RoutedEventArgs e)
        {
            PropertyModel updatedProperty = new PropertyModel();

            // Get values from the controls
            if (!string.IsNullOrEmpty(txt_property_id.Text))
                updatedProperty.id = int.Parse(txt_property_id.Text);
            updatedProperty.type = (cmb_property_type.SelectedItem as ComboBoxItem)?.Content?.ToString();
            if (!string.IsNullOrEmpty(txt_square_feet.Text))
                updatedProperty.square_feet = int.Parse(txt_square_feet.Text);
            if (!string.IsNullOrEmpty(txt_price.Text))
                updatedProperty.price = decimal.Parse(txt_price.Text);
            updatedProperty.address = txt_address.Text;
            if (comb_bedrooms.SelectedItem != null)
                updatedProperty.bedrooms = comb_bedrooms.SelectedIndex;
            if (comb_bathrooms.SelectedItem != null)
                updatedProperty.bathrooms = comb_bathrooms.SelectedIndex;
            if (!string.IsNullOrEmpty(txt_year_built.Text))
                updatedProperty.year_of_build = int.Parse(txt_year_built.Text);
            updatedProperty.offer_type = (cmb_offer.SelectedItem as ComboBoxItem)?.Content?.ToString();
            updatedProperty.inspection_status = (cmb_inspection.SelectedItem as ComboBoxItem)?.Content?.ToString();
            updatedProperty.repair_status = (cmb_repairs.SelectedItem as ComboBoxItem)?.Content?.ToString();
            updatedProperty.balcony = cbx_balcony.IsChecked ?? false;
            updatedProperty.pool = cbx_pool.IsChecked ?? false;
            updatedProperty.backyard = cbx_backyard.IsChecked ?? false;
            updatedProperty.garage = cbx_garage.IsChecked ?? false;

            // Update property in database
            UserService userService = new UserService();
            int affectedRows = userService.UpdateProperty(updatedProperty);

            if (affectedRows > 0)
            {
                MessageBox.Show("Property updated successfully.");
            }
            else
            {
                MessageBox.Show("Error while updating property.");
            }
            populate();
        }
    }
}




