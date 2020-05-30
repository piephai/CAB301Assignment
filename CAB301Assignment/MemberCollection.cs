using System;


namespace CAB301Assignment
{
    public class MemberCollection

    {
        //private int index = 0;
        static int NUM = 100;
        public static Member[] members = new Member[NUM];
        static private int index = 0;
        private string firstName, lastName, address, userName;
        private int phoneNumber, password;


        //Default empty Constructor
        public MemberCollection() { }

        public static void PreMadeMembers()
        {
            members[0] = new Member("jon", "snow", "28B, Alice Street",
                "snowjon", 0447819213, 1234);
            
            members[1] = new Member("bob", "ross", "99A, Chermside Rd",
                "rossbob", 0434473839, 1234);


        }
        //Add new member to the array
        public void AddMember()
        {
            Console.WriteLine("--------Add new member-------");
            Console.Write("First name: ");
            firstName = Console.ReadLine().ToLower();
            Console.Write("Last name: ");
            lastName = Console.ReadLine().ToLower();
            userName = lastName + firstName;
            Console.Write("Address: ");
            address = Console.ReadLine();
            phoneNumber = PhoneNumberChecker();
            password = PasswordChecker();

            while (members[index] != null)
            {
                index += 1;

            }
           
            members[index] = new Member(firstName, lastName, address,
               userName, phoneNumber, password);
            Console.WriteLine("Sucessfully created: {0} {1}",
                members[index].FirstName,
                members[index].LastName);
            Console.WriteLine("\n" + members[index].ToString());
            index += 1;


        }

        //TODO: Check if member already exists
        private (string, string) CheckMemberExist()
        {
            bool isExist = true;
            while (isExist)
            {
                Console.Write("First name: ");
                firstName = Console.ReadLine().ToLower();
                Console.Write("Last name: ");
                lastName = Console.ReadLine().ToLower();
                foreach (Member member in members)
                {
                    if (member.FirstName == firstName && member.LastName
                        == lastName)
                    {
                        isExist = true;
                        Console.WriteLine("{0} {1} is already registered",
                            firstName, lastName);
                    }
                    else
                    {

                        isExist = false;
                    }
                }
            }
            return (firstName, lastName);
        }
        //TODO: Find member contact from name
        public void FindMemberContactPhoneNumber()
        {
            //Find member contact phone number using name
            Console.Clear();
            string tempFirstName;
            string tempLastName;

            Console.WriteLine("--------Find registered member phone number" +
                "---------");
            Console.Write("First name: ");
            tempFirstName = Console.ReadLine();
            Console.Write("Last name: ");
            tempLastName = Console.ReadLine();
         
            ////Find the phone number of a registered user
            
                foreach (Member member in members)
                {
                try
                {
                    if (member.FirstName == tempFirstName && member.LastName == tempLastName)
                    {
                        Console.Clear();
                        Console.WriteLine("{0} {1} phone number is: 0{2}",
                            tempFirstName, tempLastName, member.PhoneNumber);
                        Console.ReadKey();
                        

                    }
                    else
                    {
                        Console.WriteLine("Member not found");
                        Console.ReadKey();
                    }
                }
                    catch(NullReferenceException)
                    {
                        Console.WriteLine("Member not found");
                    Console.ReadKey();
                    }
                break;

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
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i] != null)
                {
                    Console.WriteLine(members[i].ToString());
                }
                else
                {
                    Console.ReadKey();
                    return;
                }
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





