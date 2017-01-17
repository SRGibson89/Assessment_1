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

//********************************
//*				                 *
//*	    Steven Gibson		     *
//*	    40270320		         *
//*	    Assessment 1		     *
//*	    Last modified	20/10/16 *
//*	    conference Window	     *
//*				                 *
//********************************


// This GUI lets the user eneter infomation to a new attendee object
// This also lets the user retive data from an attendee object
// The GUI also lets the user create an invoice and a certifate

namespace Assessment_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ConferenceWindow : Window
    {
        // gobal varibles
        Attendee new_attendee;
        
        private int attendee_number = 0;
        private string id_number;
        public ConferenceWindow()
        {
            InitializeComponent();
            
            
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            // calls a method to clear all data from form
            clean();
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
           
            //calls method for checking attendee_number
            attendee_number_check();
            try
            {
                //makes a new attendee object if any validation checks on the object fail object will not me created
                new_attendee = new Attendee(txtFname.Text, txtSname.Text, attendee_number, txtInstituion.Text,txtInAddress.Text, txtConference.Text,
                                            cmbReg.Text, cmbPaid.Text, cmbPresenter.Text, txtPaper.Text);   
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }
            
            
        }
        


        // this method clears all data from the text boxs
        // done in a method so i can reuse if needed
        private void clean()
        {
            this.txtFname.Clear();
            this.txtSname.Clear();
            this.txtAttendee.Clear();
            this.txtInstituion.Clear();
            this.txtConference.Clear();
            this.cmbPaid.SelectedIndex = -1;
            this.cmbPresenter.SelectedIndex = -1;
            this.cmbReg.SelectedIndex = -1;
            this.txtPaper.Clear();
            this.txtInAddress.Clear();
        }
        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            
            attendee_number = 0; // resets attendee_number
            
                // if the number matches it will fill in the details
            try
            {
                attendee_number_check(); // Gets the infomation from an attendee object and populates the boxes on the conference window
                if (attendee_number == new_attendee.Attendee_ref)
                {
                    txtFname.Text = new_attendee.Firstname;
                    txtSname.Text = new_attendee.Surname;
                    txtInstituion.Text = new_attendee.Institution_name;
                    txtInAddress.Text = new_attendee.Institution_address;
                    txtConference.Text = new_attendee.Confernce_name;
                    cmbReg.Text = new_attendee.Reg_type;
                    if (new_attendee.Paid == true)
                    {
                        cmbPaid.Text = "Yes";
                    }
                    else
                    {
                        cmbPaid.Text = "No";
                    }
                    if (new_attendee.Presenting == true)
                    {
                        cmbPresenter.Text = "Yes";
                    }
                    else
                    {
                        cmbPresenter.Text = "No";
                    }
                    txtPaper.Text = new_attendee.Paper_title;

                    }

                    else
                    {
                        MessageBox.Show("ID number not found \n" + new_attendee.Attendee_ref, "Id Number error", MessageBoxButton.OK, MessageBoxImage.Warning);

                    }
            }
            catch (Exception empty)
            {
                MessageBox.Show("ID number entered is not found");
            }

        }

        private void btnCerti_Click(object sender, RoutedEventArgs e)
        {

            
            Certificate newwin = new Certificate(this);
            try
            {


                if (new_attendee.Presenting == false)
                {
                    // hides this window and displays certifcate window
                    // sends details to certifacte window
                    this.Hide();
                    newwin.lblCertificate.Content = ("This is to certify that " + new_attendee.Firstname + " " + new_attendee.Surname +
                                                     "\nattended the " + new_attendee.Confernce_name + " Conference");

                    newwin.ShowDialog();//shows the windows
                }
                else
                {
                    // hides this window and displays certifcate window
                    // sends details to certifacte window
                    this.Hide();
                    newwin.lblCertificate.Content = ("This is to certify that " + new_attendee.Firstname + " " + new_attendee.Surname +
                                                     "\nattended the " + new_attendee.Confernce_name + " Conference" +
                                                     "\nand presented a paper entitled " + new_attendee.Paper_title);

                    newwin.ShowDialog();//shows the windows
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("No Attendee Detail entered use the get button first");
                
            }
        }

        private void btnInvoice_Click(object sender, RoutedEventArgs e)
        {
            //makes a new invoice object
            Invoice newwin = new Invoice(this);
            try
            {
                // hides this window and displays certifcate window
                // sends details to certifacte window
                newwin.lblDisplayName.Content = (new_attendee.Firstname + " " + new_attendee.Surname);
                newwin.lblDisplayConfenernce.Content = (new_attendee.Confernce_name);
                newwin.lblDisplayInstitution.Content = (new_attendee.Institution_name);
                newwin.lblDisplayCost.Content = ("£" + new_attendee.cost);
                this.Hide();
                newwin.ShowDialog(); //shows window
            }
            catch (Exception exc)
            {
                MessageBox.Show("No Attendee Detail entered use the get button first");
            }
        }

       
      private void attendee_number_check()
        {
          //method for making sure the data enetered into the text box is a number
            try
            {
                id_number = txtAttendee.Text;
                attendee_number = int.Parse(id_number);
            }
            catch (Exception excep)
            {
                MessageBox.Show("Not a vaild number", "Id Number error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

      private void txtInstituion_TextChanged(object sender, TextChangedEventArgs e)
      {

          // enables or diables the institution addres text box
          if (txtInstituion.Text != "")
          {
              txtInAddress.IsEnabled = true;
          }
          else
          {
              txtInAddress.IsEnabled = false;
              txtInAddress.Clear();
          }
      }
    }
}
