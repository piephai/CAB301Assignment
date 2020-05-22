using System;
using System.Collections.Generic;

namespace CAB301Assignment
{
    public class MemberCollection

    {
        static Member[] members = new Member[400];

        public static void AddMember()
        {
            int index = Array.IndexOf(members, null);
            if (index != -1)
            {
                Console.Clear();
                Console.WriteLine("--------Add new member-------");
               
                members[index] = new Member();
                Console.WriteLine("First name: ");
                members[index].FirstName = Console.ReadLine();
                Console.WriteLine("Last name: ");
                members[index].LastName = Console.ReadLine();
                Console.WriteLine("Address: ");
                members[index].Address = Console.ReadLine();
                
                members[index].PhoneNumber = PhoneNumberChecker();
                members[index].Password = PasswordChecker();
                Console.WriteLine("");
                Member.PrintMemberDetails();
                Console.WriteLine("\nPress any key to go back to staff menu");
                Console.ReadKey();



            }
        }

        public static void FindMemberContactPhoneNumber(string n)
        {
            //TODO:
        }

        private static int PhoneNumberChecker()
        {
            int numericalOutput = 0;
            bool valid = false;
            while ( valid == false)
            {
                Console.WriteLine("PhoneNumber (10 digits including the " +
                    "starting 0): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out numericalOutput) &&
                    input.Length == 10)
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

        public static int PasswordChecker()
        {
            bool valid = false;
            int currentPassword = 0;
            while (valid == false)
            {
                Console.WriteLine("Password (4 digits number): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out currentPassword) &&
                    input.Length == 4
                    )
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