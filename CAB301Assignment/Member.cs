using System;
using System.Collections.Generic;

namespace CAB301Assignment
{

    public class Member
    {
        //Default empty constructor
        public Member()
        {
        }

        //Initialises a new member
        public Member(string firstName, string lastName, string address,
            string fullName, string userName, int phoneNumber, int password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.FullName = fullName;
            this.UserName = userName;
            this.PhoneNumber = phoneNumber;
            this.Password = password;
        }

        //Declarations
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public int PhoneNumber { get; set; }
        public int Password { get; set; }


        //Print member details when the user is first created
        //public void PrintMemberDetails()
        //{
        //    Console.WriteLine("The following user was created: ");
        //    Console.WriteLine("First name: " + FirstName);
        //    Console.WriteLine("Last name: " + LastName);
        //    Console.WriteLine("Address: " + Address);
        //    Console.WriteLine("Phone Number: 61+ " + PhoneNumber);
        //    Console.WriteLine("Password (4 Digits Number): " + Password);
        //    Console.WriteLine("Username: " + UserName);
        //}

        public override string ToString()
        {
            return String.Format("User: \n" +
                "First name: {0}\nLast name: {1}\nAddress: {2}\n" +
                "Phone Number: 61+ {3}\nPassword (4 Digits Number): {4}" +
                "\nUsername: {5}", FirstName, LastName, Address, PhoneNumber,
                Password, UserName);
        }
    }
}




        

