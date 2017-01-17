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
using System.Windows.Shapes;

//********************************
//*				                 *
//*	    Steven Gibson		     *
//*	    40270320		         *
//*	    Assessment 1		     *
//*	    Last modified	13/10/16 *
//*	    Invoice Window		     *
//*				                 *
//********************************

// This GUI shows the user an Invoice for an Attendee object

namespace Assessment_1
{
    /// <summary>
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : Window
    {
        ConferenceWindow Parent;
        public Invoice(ConferenceWindow myParent) // this allows the conference window to write to this window
        {
            Parent = myParent;
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Parent.Show();//after the ok button is clicked it will show the confenece window then hide this one
            this.Close();
        }
    }
}
