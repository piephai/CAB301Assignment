using System;
using System.Collections.Generic;

namespace CAB301Assignment
{

    public class Member
    {
       

        public static string firstName, lastName, address, borrowedDVDs;
        public static int phoneNumber, password;


        public string FirstName
        {
            get { return firstName.ToLower(); }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName.ToLower(); }
            set { lastName = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public int PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string BorrowedDVDs
        {
            get { return borrowedDVDs; }
            set { borrowedDVDs = value; }
        }

        public int Password
        {
            get { return password; }
            set { password = value; }
        }

        

        public static void PrintMemberDetails()
        {
            Console.WriteLine("The following user was created: ");
            Console.WriteLine("First name: " + firstName);
            Console.WriteLine("Last name: " + lastName);
            Console.WriteLine("Address: " + address);
            Console.WriteLine("Phone Number: 61+ " + phoneNumber);
            Console.WriteLine("Password (4 Digits Number): " + password);
        }


    }
}




        

