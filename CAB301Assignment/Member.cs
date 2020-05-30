using System;


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
            string userName, int phoneNumber, int password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.UserName = userName;
            this.PhoneNumber = phoneNumber;
            this.Password = password;
        }

        //Declarations
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public int PhoneNumber { get; set; }
        public int Password { get; set; }


        public override string ToString()
        {
            return String.Format("\n\n" +
                "First Name: {0}\nLast Name: {1}\nAddress: {2}\n" +
                "Phone Number: 61+ {3}\nPassword (4 Digits Number): {4}" +
                "\nUsername: {5}", char.ToUpper(FirstName[0]) +
                FirstName.Substring(1), char.ToUpper(LastName[0]) +
                LastName.Substring(1), Address, PhoneNumber,
                Password, UserName);
        }
    }
}




        

