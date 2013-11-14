using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Magtenboelle_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   //list for all instances of Customerclass
        public List<Customer> customerList = new List<Customer>();
        //list for all instances of EventClass
        List<EventClass> eventRservationsListe = new List<EventClass>();
        byte age = 0;

        //this makes sure customerInitialize does not run more than one time when pressing different tabs
        private bool customerInitialied = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        //this initialize the different tabs only on when the tabs are pressed and not when the program initialize 
        public void tabControlWindow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (magtenboelleWindow.SelectedIndex == 0)
            {
                //customer code here
                CustomerInitialize();
            }
            else if (magtenboelleWindow.SelectedIndex == 1)
            {
                //calender code here
            }
            else if (magtenboelleWindow.SelectedIndex == 2)
            {
                //reservation code here
            }
            else if (magtenboelleWindow.SelectedIndex == 3)
            {
                //event code here
            }
        }

        public void CustomerInitialize()
        {
            if (!customerInitialied)
            {
                Customer lars = new Customer("anders", "Odensevej 17", 5000, "Odense", 23, 47583928, "lars@gmail.com");
                Customer jens = new Customer("jens", "Vejlevej 2", 5000, "Odense", 45, 83619374, "jens@gmail.com");
                customerList.Add(lars);
                customerList.Add(jens);
                listBCustomers.ItemsSource = customerList;
                customerInitialied = true;
            }
        }

        //selectbox for customers age
        private void CbboxNewUserAge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbboxNewUserAge.SelectedIndex == 0)
            {
                age = 18;
            }
            if (CbboxNewUserAge.SelectedIndex == 1)
            {
                age = 36;
            }
            if (CbboxNewUserAge.SelectedIndex == 2)
            {
                age = 50;
            }
        }

        //if no customers are selected in the listbox the remove button does not work 
        private void listBCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRemoveCustomer.IsEnabled = (listBCustomers.SelectedItem != null);
        }

        //a customer gets added to the list, the list is refreshed and the customer is saved in the json customer file
        private void btnSaveUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer newCustomer = new Customer(txtNewUserFullName.Text, txtNewUserAdress.Text, int.Parse(txtNewUserZipCode.Text), txtNewUserCity.Text, age, int.Parse(txtNewUserTelehone.Text), txtNewUserEmail.Text);
                customerList.Add(newCustomer);
                listBCustomers.Items.Refresh();
                //SaveCustomers(newCustomer);
                SaverAndLoader.ObjectToJsonString(customerList);
                ClearTextBoxes();
            }
            catch
            {
                MessageBox.Show("Alle input skal være korrekt format!");
            }
        }

        //this clears the textboxes for the new cutomers form
        private void ClearTextBoxes()
        {
            txtNewUserAdress.Clear();
            txtNewUserCity.Clear();
            txtNewUserEmail.Clear();
            txtNewUserFullName.Clear();
            txtNewUserTelehone.Clear();
            txtNewUserZipCode.Clear();
        }

        private void btnExitNewUser_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //this opens up a new window, from the listbox, that shows a customers data 
        private void btnShowCustomerInfo_Click(object sender, RoutedEventArgs e)
        {
            Customer kunde = listBCustomers.SelectedItem as Customer;
            Magtenboelle_v2.CustomerInfo dialog = new Magtenboelle_v2.CustomerInfo(kunde);
            dialog.SetPerson();
            dialog.ParentWindow = this;
            dialog.Show();
        }
        //when a customer is selected in the listbox this button removes the customer from the list and refreshes the listbox
        private void btnRemoveCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = listBCustomers.SelectedItem as Customer;
            customerList.Remove(customer);
            listBCustomers.Items.Refresh();
        }
        //this adds a new event to the event list, refresh the listbox and saves it
        private void btnOpretEvent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EventClass newEvent = new EventClass(txtEventNavn.Text, DateTime.Parse(txtEventStartDato.Text), DateTime.Parse(txtEventEndDato.Text), int.Parse(txtEventMaxDeltagere.Text), double.Parse(txtEventPrisPerPerson.Text));
                eventRservationsListe.Add(newEvent);
                //SaveEventReservationToTxtFile();
            }
            catch
            {

                MessageBox.Show("Alle input skal være korrekt format!");
            }
        }
        //on focus the calender pops up
        private void txtEventStartDato_GotFocus(object sender, RoutedEventArgs e)
        {

        }
        //on focus the calender pops up
        private void txtEventEndDato_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void btnCalenderShowEvents_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCalenderShowReservation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("TEST.txt")) //Skal bare have den rigtige sti til Event og Reservationer
                {
                    string line = sr.ReadToEnd(); //Declare line variable and sets ReadToEnd to it

                    listBoxCalender.Items.Add(line);//Add our string "line" to listbox
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Can't Read Path");//Catch Exception if StreamReader Fails

            }
        }
    }
}
