using System;


namespace CAB301Assignment
{
    public class MemberCollection

    {
        static int NUM = 100;
        public static Member[] members = new Member[NUM];
        static private int index = 0;



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
            string firstName = "";
            string lastName = "";
            string address = "";
            string userName;
            int phoneNumber, password;

            Console.WriteLine("--------Add new member-------");
            while (String.IsNullOrEmpty(firstName))
            {
                Console.Write("First name: ");
                firstName = Console.ReadLine().ToLower();
                if (String.IsNullOrEmpty(firstName))
                {
                    Console.WriteLine("First name cannot be empty\n");
                }
            }
            while (String.IsNullOrEmpty(lastName))
            {
                Console.Write("Last name: ");
                lastName = Console.ReadLine().ToLower();
                if (String.IsNullOrEmpty(lastName))
                {
                    Console.WriteLine("Last name cannot be empty\n");
                }
            }
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

                Console.WriteLine("\n{0} {1} already exists",
                    char.ToUpper(firstName[0]) + firstName.Substring(1),
                    char.ToUpper(lastName[0]) + lastName.Substring(1));
            }
            else
            {//Continue member creation onto address
                while (String.IsNullOrEmpty(address))
                {
                    Console.Write("Address: ");
                    address = Console.ReadLine();
                    if (String.IsNullOrEmpty(address))
                    {
                        Console.WriteLine("Address cannot be empty\n");
                    }
                }
            
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

        //Find member by their user name
        public Member FindMember(string userName)
        {

            Member found = Array.Find(members, item => item.UserName == userName);
            if (found.UserName == userName)
            {
                return found;
            }


            else
            {
                Console.WriteLine("Member not found");
                return null;
            }

        }

        //Find member contact from full name
        public void FindMemberContactPhoneNumber()
        {

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
                Console.WriteLine("{0} {1}'s phone number is: 0{2}",
                    char.ToUpper(foundMember.FirstName[0]) +
                    foundMember.FirstName.Substring(1)
                    , char.ToUpper(foundMember.LastName[0]) +
                    foundMember.LastName.Substring(1), foundMember.PhoneNumber);
                Console.WriteLine("Press any key to go back to the staff menu");

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


        //Member borrow movie DVD
        public void BorrowMovie(Member member, Movie movie)
        {
            string foundMovieTitle;

            FindIfMovieExists(movie);
            CheckerIfMemberHasMoreThan10Borrow(member);
            foundMovieTitle = FindIfMemberHasMovie(member, movie);
            if (movie.GetCurrentCopy() != 0 && foundMovieTitle != movie.Title)
            {//Case 1: There is an available copy of the movie DVD and the user does not have a copy of the same DVD currently

                member.BorrowMovie(movie);
                movie.Borrow();
                Console.WriteLine("The following movie was borrowed: {0}"
                    , movie.getTitle());
            }

            else if (movie.GetCurrentCopy() != 0 && foundMovieTitle == movie.Title)
            {//Case 2: There is an avilable copy of the movie DVD but the user have borrowed a copy of the movie and have not yet returned it
                Console.WriteLine("You currently have a copy of this movie");
            }

            else
            {//Case 3: There is no movie DVD available to borrow
                Console.WriteLine("The movie: {0} has no more " +
                    "available copies to borrow", movie.Title);
            }

        }


        // Return movies
        public void ReturnBorrowedMovie(Member member, Movie movie)
        {
            string foundMovieTitle;

            FindIfMovieExists(movie);
            foundMovieTitle = FindIfMemberHasMovie(member, movie);

            if (foundMovieTitle == movie.Title)
            { //Case 1: Member title matches that of the one te member currently held
                member.ReturnCurrentBorrowedMovies(movie);
                movie.Return();

                Console.WriteLine("The movie {0} was returned", movie.Title);
            }
            else
            { //Case 2: Member does not currently hold a copy of the movie DVD 
                Console.WriteLine("You are not currently borrowing the movie: {0}", movie.Title);
            }


        }

        //Get the current borrowed movies
        public void CurrentBorrowedMovie(Member member)
        {
            try
            {
                member.CurrentlyBorrowedMovie();
            }
            catch
            {

            }
        }


        /*==========================Helper methods===========================*/

        //Check if user has the movie DVD already
        private string FindIfMemberHasMovie(Member member, Movie movie)
        {

            string tempMovieTitle = "";
            try
            {//Check if user has already got a copy of this movie DVD
                Movie foundMovie = Array.Find(member.borrowedMovies, item => item.Title == movie.Title);
                tempMovieTitle = foundMovie.Title;

            }
            catch (NullReferenceException)
            {


            }
            return tempMovieTitle;


        }

        //Check to see if the user entered movie exists
        public void FindIfMovieExists(Movie movie)
        {
            bool isFound = false;

            while (isFound == false)
            {
                try //Search for the movie with a matching title in the binary tree
                {
                    MovieCollection.binaryTree.SearchByTitle(movie.Title).Data().getTitle();
                    isFound = true;
                }
                catch (NullReferenceException) //Title is not found
                {
                    
                    Console.WriteLine("\nThe Movie you entered does not exist");
                    Console.WriteLine("\nPress any key to go back to members menu");
                    Console.ReadKey();
                    Menus.MemberMenu();
                }
            }
        }

        //Check if member has more than 10 borrowed movies
        public void CheckerIfMemberHasMoreThan10Borrow(Member member)
        {
            if (member.borrowedMovies.Length - 1 > 9)
            {
                Console.WriteLine("\n\nYou cannot borrow more than 10 movie DVDs " +
                    "at the same time");
                Console.WriteLine("\nPress any key to go back to members menu\n");
                Console.ReadKey();
                Menus.MemberMenu();
            }

        }

        //Display all the member info
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





