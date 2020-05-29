using System;


namespace CAB301Assignment
{
    public class MemberCollection

    {
        //private int index = 0;
        static int NUM = 100;
        public static Member[] members = new Member[NUM];
        static private int index = 0;
        private string firstName, lastName, address, fullName, userName;
        private int phoneNumber, password;


        //Default empty Constructor
        public MemberCollection() { }


        //Add new member to the array
        public void AddMember()
        {
            Console.WriteLine("--------Add new member-------");
            Console.Write("First name: ");
            firstName = Console.ReadLine().ToLower();
            Console.Write("Last name: ");
            lastName = Console.ReadLine().ToLower();
            fullName = firstName + lastName;
            userName = lastName + firstName;
            Console.Write("Address: ");
            address = Console.ReadLine();
            phoneNumber = PhoneNumberChecker();
            password = PasswordChecker();

            members[index] = new Member(firstName, lastName, address,
                fullName, userName, phoneNumber, password);
            Console.WriteLine("Sucessfully created: {0} {1}",
                members[index].FirstName,
                members[index].LastName);
            index += 1;
        }

        //private (string, string) CheckMemberExist()
        //{
        //    bool isExist = true;
        //    while (isExist)
        //    {
        //        Console.Write("First name: ");
        //        firstName = Console.ReadLine().ToLower();
        //        Console.Write("Last name: ");
        //        lastName = Console.ReadLine().ToLower();
        //        foreach (Member member in members)
        //        {
        //            if (member.FirstName == firstName && member.LastName
        //                == lastName)
        //            {
        //                isExist = true;
        //                Console.WriteLine("{0} {1} is already registered",
        //                    firstName, lastName);
        //            }
        //            else
        //            {

        //                isExist = false;
        //            }
        //        }
        //    } return (firstName, lastName);
        //}
        //TODO: Find member contact from name
        public void FindMemberContactPhoneNumber()
        {
            //Find member contact phone number using name
            Console.Clear();
            Console.WriteLine("--------Find registered member phone number" +
                "---------");
            Console.Write("Enter registered member first and last name" +
                " with no space: ");


            //Find the name of the user using their phone number or find their
            //find their phone number using their name
            string input = Console.ReadLine();
            int uinput = 0;
            int.TryParse(Console.ReadLine(), out uinput);


            //TODO: See if it's easier to find stuff using other methods
            foreach (Member search in members)
            {
                if (search.FullName == input)
                {
                    Console.WriteLine("User phone number is: 61+ {0}",
                    search.PhoneNumber);
                    Console.ReadKey();

                }
                else if (search.PhoneNumber == uinput)
                {
                    Console.WriteLine("User full name is: {0} {1}",
                        search.FirstName, search.LastName);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Unable to find username or phone" +
                        "number");
                    Console.ReadKey();
                }
            }
        }



            //public void MemberLoginChecker()
            //{

            //foreach (Member search in members)
            //{
            //    int i = 0;
            //    username[i] = search.UserName 
            //}

            //}

            //int currentPhoneNumber = 0;
            //while (valid == false)
            //{
            //    if (Member.fullName.Equals(Console.ReadLine()))
            //    {
            //        currentPhoneNumber = Member.phoneNumber;
            //        Console.WriteLine("User phone number is: 61+ " +
            //        currentPhoneNumber);
            //        valid = true;
            //        Console.WriteLine("\n Press any key to go back to staff" +
            //            " menu");
            //        Console.ReadKey();


            //    }
            //    else
            //    {
            //        valid = false;
            //        Console.WriteLine("User does not exist");
            //    }
            //}

            //}
        
        public void ShowInfo()
        {
            for (int i = 0; i < NUM; i++)
            {
                Console.WriteLine(members[i]);
            }
        }


        //Test to see if the phone number is valid
        private int PhoneNumberChecker()
        {
            int numericalOutput = 0;
            bool valid = false;
            while (valid == false)
            {
                Console.WriteLine("PhoneNumber (10 digits including the " +
                    "starting 0): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out numericalOutput) &&
                    input.Length == 10)//Phone number can only contain 10 digits
                {
                    valid = true;
                    int.TryParse(input, out numericalOutput);
                }

                else
                {
                    Console.WriteLine("\nInvalid phone number");
                }
            }

            return numericalOutput;
        }


        //Test to see if password is valid
        public int PasswordChecker()
        {
            bool valid = false;
            int currentPassword = 0;
            while (valid == false)
            {
                Console.WriteLine("Password (4 digits number): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out currentPassword) &&
                    input.Length == 4
                    ) //Password can only contain 4 digits
                {
                    valid = true;
                    int.TryParse(input, out currentPassword);

                }
                else
                {

                    Console.WriteLine("Invalid password");
                }
            }
            return currentPassword;


        }
    }
}





