using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//********************************
//*				                 *
//*	    Steven Gibson		     *
//*	    40270320		         *
//*	    Assessment 1		     *
//*	    Last modified	13/10/16 *
//*	    Person Class		     *
//*				                 *
//********************************

// This is the base class has a first name and last name, this could be extended to hold more data
// at a later date such as phone number or address

namespace Assessment_1
{
    public class Person
    {
        private string firstname = "";
        private string surname = "";

        public string Firstname
        {
            get 
            { return firstname; }
        
            set
            {
                //checks to see if a firstname has been entered
                if (value == "")
                {
                    throw new ArgumentException("Please enter first name");
                }
                else
                {
                firstname = value;
                } 
            }

        }

        public string Surname
        {
            get { return surname; }
            set 
            {
                // checks if a surname has been entered
                if (value == "")
                {
                    throw new ArgumentException("Please enter surname");
                }
                else
                {
                    surname = value;
                } 
                  
            }
        }
    }

    
}
