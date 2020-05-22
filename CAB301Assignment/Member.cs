using System;
namespace CAB301Assignment
{

    public class Member
    {

        public string firstName;
        public string lastName;
        public string address;
        public int phoneNumber;
        public string borrowedDVDs;
        public int password;

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
  

        public void PrintMemberDetails()
        {
            Console.WriteLine("First name: " + firstName);
            Console.WriteLine("Last name: " + lastName);
            Console.WriteLine("Address: " + address);
            Console.WriteLine("Phone Number: " + phoneNumber);
            Console.WriteLine("Borrowed DVDS: " + borrowedDVDs);
            Console.WriteLine("Password: " + password);
        }

        


    }
}

