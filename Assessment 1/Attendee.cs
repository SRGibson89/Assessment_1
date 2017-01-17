using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

//********************************
//*				                 *
//*	    Steven Gibson		     *
//*	    40270320		         *
//*	    Assessment 1		     *
//*	    Last modified	13/10/16 *
//*	    Attendee Class		     *
//*				                 *
//********************************

// This class is a sub-class of Person, it has data only relvent to people attending the conference

namespace Assessment_1
{
    public class Attendee:Person 
    {
        Institution new_institution;
        private int attendee_ref;
        private string paper_title;
        private string reg_type;
        private bool paid;
        private bool presenting;
        private string institution_name;
        private string confernce_name;
        public double cost = 0.00;
        private double student_cost = 300.00;
        private double full_cost = 500.00;
        private double discount = 0.10;

        // constructor for making and valdating the object
        public Attendee(string first,string sur, int attend, string inst,string inst_a, string con, string reg ,string pay,string pres, string paper)
        {
            new_institution = new Institution(inst,inst_a) ;
            base.Firstname = first;
            base.Surname = sur;
            Attendee_ref = attend;
            Confernce_name = con;
            Reg_type = reg;
            Paid_check(pay);
            Presenting_check(pres);
            Paper_title = paper;
            getCost();
            MessageBox.Show("Attendee " + attendee_ref + " has been created");
        }
        public int Attendee_ref
        {
            get { return attendee_ref; }

            set
            {
                // checks to see if the number is vaild
                    if ((value < 40000) || (value > 60000))
                    {
                        
                    throw new ArgumentException("Please enter a different ID number \nBetween 40000 and 60000");
                    }
                    else
                    {
                        attendee_ref = value;
                    }
             }
        }
        public string Paper_title
        {
            get { return paper_title; }
            set 
            {
                // checks to see if the paper title is needed or should be blank
                if ((value == "")&&(presenting == true))
                {
                throw new ArgumentException("Please Enter Paper title this cannot be left blank if presenting");
                }
                if ((value != "")&&(presenting == false))
                {
                    throw new ArgumentException("Please remove paper title if not presenting");
                }
                else
                {
                paper_title = value; 
                }
            }
        }
        public string Reg_type
        {
            get { return reg_type; }
            set 
            {
                // checks to see if the registration type has been entered
                if (value == "")
                {
                    throw new ArgumentException("Please check Registration Type");
                }
                else
                {
                   reg_type = value;
                } 
            }
        }
        public bool Paid
        {
            get { return paid; }
            set
            {
                 
                paid = value; }
        }
        public bool Presenting
        {
            get { return presenting; }
            set
            {
                presenting = value;
            }
        }
        public string Institution_name
        {
            get { return new_institution.Institution_name; }
            
        }

        public string Institution_address
        {
            get { return new_institution.Institution_address; }
        }
        public string Confernce_name
        {
            get { return confernce_name; }
            set 
            {
                // checks to see if the conference name has been entered
                if (value == "")
                {
                    throw new ArgumentException("A conference name must be entered");
                }
                else
                {
                confernce_name = value;
                }
            }
        }
        // this checks to see if the attendee has paid
        public bool Paid_check(string pay)
        {
            if (pay == "Yes")
            {
                return paid = true;
            }
            if (pay =="")
            {
                throw new ArgumentException("has the attendee paid?");
            }
            else
            {
                return paid = false;
            }
        }
        // this checks if the attendee is presenting at the conference
        public bool Presenting_check(string pres)
        {
            if (pres == "Yes")
            {
                return presenting = true;
            }
            if (pres == "")
            {
                throw new ArgumentException("Is the attendee Presenting?");
            }
            else
            {
                return presenting = false;
            }
        }

        // works out how much a ticket cost for the attendee based on what registraion type they are
        private void getCost()
        {
            if ((reg_type == "Student") && (presenting==false))
            {
                cost = student_cost;
            }
            if ((reg_type == "Student") && (presenting==true))
            {
                cost = (student_cost -(student_cost*discount));
            }
            if ((reg_type == "Full") && (presenting==false))
            {
                cost = full_cost;
            }
            if ((reg_type == "Full") && (presenting == true))
            {
                cost = (full_cost - (full_cost * discount));
            }
            
        }
    }
}
