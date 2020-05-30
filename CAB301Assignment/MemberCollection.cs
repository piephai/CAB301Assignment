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
        private Movie[] borrowedMovies;



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
            string searchUserName = "";

            Console.WriteLine("--------Add new member-------");
            Console.Write("First name: ");
            firstName = Console.ReadLine().ToLower();
            Console.Write("Last name: ");
            lastName = Console.ReadLine().ToLower();
            userName = lastName + firstName;
            try
            {/*Search for whether or not username already exists in array. Search is done through username since 
                                                                        username = lastname + firstname and it is unique*/
                Member foundMember = Array.Find(members, item =>
                item.UserName == userName);
                searchUserName = foundMember.UserName;
            }
            catch (NullReferenceException)
            {

            }
            if (userName == searchUserName)
            {//Username match that of one in the existing members array
                Console.Clear();
                Console.WriteLine("{0} {1} already exists",
                    char.ToUpper(firstName[0]) + firstName.Substring(1),
                    char.ToUpper(lastName[0]) + lastName.Substring(1));
            }
            else
            {//Continue member creation onto address 
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

                //Print out the name of the person you just created 
                Console.WriteLine("Sucessfully created: {0} {1}",
                    char.ToUpper(members[index].FirstName[0]) + members[index].FirstName.Substring(1),
                    char.ToUpper(members[index].LastName[0]) + members[index].LastName.Substring(1));

                //Console.WriteLine("\n" + members[index].ToString());
                index += 1;


            }
        }

       
        //Find member contact from full name
        public void FindMemberContactPhoneNumber()
        {

            Console.Clear();
            string tempFirstName;
            string tempLastName;

            Console.WriteLine("--------Find registered member phone number" +
            "---------");
            Console.Write("First name: ");
            tempFirstName = Console.ReadLine();
            Console.Write("Last name: ");
            tempLastName = Console.ReadLine();
            string tempUserName = tempLastName.ToLower() + tempFirstName.ToLower();

            ////Find the phone number of a registered user

            try
            {
                Member foundMember = Array.Find(members, item =>
                item.UserName == tempUserName); //Find member in the array matching by their username

                //Print the member's phone number
                Console.WriteLine("{0} {1}'s phone nubmer is: 0{2}",
                    char.ToUpper(foundMember.FirstName[0]) +
                    foundMember.FirstName.Substring(1)
                    , char.ToUpper(foundMember.LastName[0]) +
                    foundMember.LastName.Substring(1), foundMember.PhoneNumber);

                Console.ReadKey();

            }

            //If the member does not exist
            catch (NullReferenceException)
            {

                Console.WriteLine("Member not found:");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();


            }

        }

        private void borrowMovie(Member member, Movie movie)
        {
            if (movie.GetCurrentCopy() != 0)
            {
                member.BorrowMovie(movie);
                movie.Borrow();

                Console.WriteLine("The following movie was borrowed: {0} by: {1}{2}"
                    , movie.getTitle(), member.FirstName, member.LastName);
            }
            else
            {
                Console.WriteLine("The selected movie: {0} has no more " +
                    "available copies to borrow");
            }
        }

        public void BorrowMovie()
        {
            string title = "";
            Console.WriteLine("=========Borrow a movie========");
            Console.Write("Enter the title of the movie you want to borrow: ");
            title = Console.ReadLine();
        }


        //TODO: Login check to see if the user is logged in
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

        public void DisplayAllMembersInfo()
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
            int searchNum = 0;
            
            bool valid = false;
            while (valid == false)
            {
                
                Console.WriteLine("PhoneNumber (10 digits including the " +
                    "starting 0): ");
                string input = Console.ReadLine();
                try
                {
                    int.TryParse(input, out numericalOutput);
                    Member foundMember = Array.Find(members, item => item.PhoneNumber == numericalOutput);
                    searchNum = foundMember.PhoneNumber;
                }
                catch (NullReferenceException)
                {

                }
                if (int.TryParse(input, out numericalOutput) &&
                    input.Length == 10 && numericalOutput != searchNum)//Phone number can only contain 10 digits and is unique
                {
                    valid = true;
                    int.TryParse(input, out numericalOutput);
                }

                else
                {
                    Console.WriteLine("\nInvalid phone number"); /*Invalid response could be due to phone number that already exists
                                                                     or just incorrect input in general*/
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





