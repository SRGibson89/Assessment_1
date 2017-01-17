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
//*	    Last modified	20/10/16 *
//*	    Institution Class	     *
//*				                 *
//********************************

// This is a base class with a refrence from Attendee Class, This holds data about the instuition
// such as the address and name

namespace Assessment_1
{
    public class Institution
    {
        private string institution_name;
        private string institution_address;

        public string Institution_name
        {
            get { return institution_name; }
            set { institution_name = value; }

        }

        public string Institution_address
        {
            get { return institution_address; }
            set { institution_address = value; }

        }
         
        public Institution (string name,string address)
        {
            Institution_name = name;
            Institution_address = address;
        }
           
    }
}
