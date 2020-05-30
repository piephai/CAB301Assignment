using System;
namespace CAB301Assignment
{
    public class Menus
    {
        private static string currentUserName;

        public static void MainMenu()

        {
            


        //Menu calling the user to action
        Action printMenu = () =>
                {
                    Console.WriteLine("1. Staff Login");
                    Console.WriteLine("2. Member Login");
                    Console.WriteLine("0. Exit");

                };

            Console.Clear();
            Console.WriteLine("Welcome to the Community Library");
            Console.WriteLine("===========Main Menu==========");

            printMenu();
            Console.WriteLine("==============================");
            Console.WriteLine(" \n Please make a selection (1-2," +
                    " or 0 to exit) ");

            int choice = GetUserChoice(printMenu, 3);

            if (choice == 0)
            {
                Console.WriteLine("Thank you for visiting the community " +
                    "library");
                Console.ReadKey();
            }

            //Switch statement based on user choice
            switch (choice)

            {
                case 1:
                    LoginMenu("staff");
                    break;

                case 2:
                    LoginMenu("member");
                    break;



            }

        }

        //Member Menu
        static void MemberMenu()
        {
            MovieCollection MovieCollection = new MovieCollection();
            MemberCollection MemberCollection = new MemberCollection();
            Action printMenu = () =>
            {
                Console.WriteLine("1. Display all movies");
                Console.WriteLine("2. Borrow a movie DVD");
                Console.WriteLine("3. Return a movie DVD");
                Console.WriteLine("4. List current borrowed movie DVDs");
                Console.WriteLine("5. Display top 10 most popular movies");
                Console.WriteLine("0. Return to the main menu");
            };

            Console.Clear();
            Console.WriteLine("===========Member Menu==========");
            printMenu();
            Console.WriteLine("================================");
            Console.WriteLine(" \n Please make a selection (1-5," +
               " or 0 to return to the main menu) ");

            int choice = GetUserChoice(printMenu, 6);

            if (choice == 0)
            {
                MainMenu();
            }
            switch (choice)
            {
                case 1:
                    MovieCollection.DisplayAllMovies();
                    Console.ReadKey();
                    MemberMenu();
                    break;

                case 2:
                    MovieCollection.DisplayAllMovies();
                    Console.WriteLine("\n\n=========Borrow a movie========");
                    Console.Write("Enter the title of the movie you want to borrow: ");
                    string title = Console.ReadLine();
                    MemberCollection.BorrowMovie(MemberCollection.FindMember(currentUserName), MovieCollection.FindMovie(title));
                    Console.ReadKey();
                    MemberMenu();
                    break;

                case 3:
                    Console.WriteLine("Return a movie DVD");
                    break;

                case 4:
                    Console.WriteLine("========Currently borrowed movies=========");
                    MemberCollection.CurrentBorrowedMovie(MemberCollection.FindMember(currentUserName));
                    Console.ReadKey();
                    MemberMenu();
                    break;

                case 5:
                    Console.WriteLine("Top 10 most popular movies");
                    break;

                case 0:
                    MainMenu();
                    break;
                default:
                    throw new NotImplementedException();


            }

        }

        //Staff Menu
        static void StaffMenu()
        {
            MemberCollection MemberCollection = new MemberCollection();
            MovieCollection MovieCollection = new MovieCollection();

            //Creating the staff menu option
            Action printMenu = () =>
                {
                    Console.WriteLine("1. Add a new movie DVD");
                    Console.WriteLine("2. Remove a movie DVD");
                    Console.WriteLine("3. Register a new Member");
                    Console.WriteLine("4. Find a registered member's phone number");
                    Console.WriteLine("5. Display member info"); //TODO: Delete after
                    Console.WriteLine("0. Return to the main menu");
                };

            Console.Clear();
            Console.WriteLine("===========Staff Menu==========");
            printMenu();
            Console.WriteLine("================================");
            Console.WriteLine(" \n Please make a selection (1-5," +
               " or 0 to return to the main menu) "); //TODO: Change from 5 to 4 after testing

            int choice = GetUserChoice(printMenu, 6);

            if (choice == 0)
            {
                MainMenu();

            }
            switch (choice)
            {
                case 1: //Add movie
                    MovieCollection.AddMovie();
                    Console.WriteLine("\nPress any key to go back to staff menu");
                    Console.ReadKey();
                    StaffMenu();
                    break;

                case 2: //Remove movie
                    MovieCollection.RemoveMovie();
                    Console.WriteLine("\nPress any key to go back to staff menu");
                    Console.ReadKey();
                    StaffMenu();
                    break;

                case 3: //Add new member
                    MemberCollection.AddMember();
                    Console.WriteLine("\nPress any key to go back to staff menu");
                    Console.ReadKey();
                    StaffMenu();
                    break;

                case 4://Find member phone number from their name
                    MemberCollection.FindMemberContactPhoneNumber();
                    StaffMenu();
                    break;

                case 5://Show all of the members info
                    MemberCollection.DisplayAllMembersInfo();
                    StaffMenu();
                    break;


                default:
                    throw new NotImplementedException();


            }

        }


        //Genre option menu
        public static string GenreOptions()
        {
            Action printMenu = () =>
            {
                Console.WriteLine("1. Drama");
                Console.WriteLine("2. Action");
                Console.WriteLine("3. Triller");
                Console.WriteLine("4. Animated");
                Console.WriteLine("5. Family");
                Console.WriteLine("6. Sci-Fi");
                Console.WriteLine("7. Comedy");
                Console.WriteLine("8. Other");
            };
            string userInput = "";
            Console.WriteLine("\nPlease select one of the genre below");
            printMenu();
            Console.Write("Plese make a selection (1-8): ");
            int choice = GetUserChoiceMovieCreation(printMenu, 8);
            switch (choice)
            {
                case 1:
                    userInput = "Drama";
                    Console.WriteLine("You selected {0}", userInput);
                    return userInput;

                case 2:
                    userInput = "Action";
                    Console.WriteLine("You selected {0}", userInput);
                    return userInput;

                case 3:
                    userInput = "Triller";
                    Console.WriteLine("You selected {0}", userInput);
                    return userInput;

                case 4:
                    userInput = "Animated";
                    Console.WriteLine("You selected {0}", userInput);
                    return userInput;

                case 5:
                    userInput = "Family";
                    Console.WriteLine("You selected {0}", userInput);
                    return userInput;

                case 6:
                    userInput = "Sci-Fi";
                    Console.WriteLine("You selected {0}", userInput);
                    return userInput;

                case 7:
                    userInput = "Comedy";
                    Console.WriteLine("You selected {0}", userInput);
                    return userInput;

                case 8:
                    userInput = "Other";
                    Console.WriteLine("You selected {0}", userInput);
                    return userInput;

            }
            return userInput;
        }

        //Classification option menu
        public static string ClassificationOptions()
        {
            Action printMenu = () =>
            {
                Console.WriteLine("1. General (G)");
                Console.WriteLine("2. Parental Guidance (PG)");
                Console.WriteLine("3. Mature (M15+)");
                Console.WriteLine("4. Mature Accompanied (MA15+)");

            };
            string userInput = "";
            Console.WriteLine("\nSelect the classification: ");
            printMenu();
            Console.Write("Please make a selection (1-4): ");
            int choice = GetUserChoiceMovieCreation(printMenu, 4);

            switch (choice)
            {
                case 1:
                    userInput = "G";
                    Console.WriteLine("You selected {0}", userInput);
                    return userInput;

                case 2:
                    userInput = "PG";
                    Console.WriteLine("You selected {0}", userInput);
                    return userInput;

                case 3:
                    userInput = "M15+";
                    Console.WriteLine("You selected {0}", userInput);
                    return userInput;

                case 4:
                    userInput = "MA15+";
                    Console.WriteLine("You selected {0}", userInput);
                    return userInput;


            }

            return userInput;

        }

        // Getting user choice and making sure that their choice is valid 
        static int GetUserChoice(Action printMenu, int choiceMax)
        {
            int choice = 0;
            bool isValid = false;
            while (isValid == false)
            {

                string temp = Console.ReadLine();
                bool result = int.TryParse(temp, out choice);
                if (result && choice >= 0 && choice < choiceMax)
                {
                    isValid = true;

                }
                else
                {
                    Console.WriteLine("");
                    printMenu();
                    Console.Write("\nPlease enter a valid number: ");
                    isValid = false;
                }

            }
            return choice;



        }

        //Helper function for getting user chocie during adding movie
        static int GetUserChoiceMovieCreation(Action printMenu, int choiceMax)
        {
            {
                int choice = 0;
                bool isValid = false;
                while (isValid == false)
                {

                    string temp = Console.ReadLine();
                    bool result = int.TryParse(temp, out choice);
                    if (result && choice > 0 && choice < choiceMax)
                    {
                        isValid = true;

                    }
                    else
                    {
                        Console.WriteLine("");
                        printMenu();
                        Console.Write("\nPlease enter a valid number: ");
                        isValid = false;
                    }

                }
                return choice;



            }

        }

        //User Login Menu
        public static void LoginMenu(string menuChoice)
        {
            bool close = false;
            Console.Clear();

            //Continous loop until user enter correct username and password
            while (close == false)
            {
                Console.WriteLine("\nPlease enter your " + menuChoice +
                    " username: ");
                currentUserName = Console.ReadLine();
                Console.WriteLine("Please enter your " + menuChoice +
                    " password");
                string password = Console.ReadLine();


                //Staff login
                if (menuChoice == "staff" )
                   
                    
                {
                    if (currentUserName == "staff" && password == "today123") //staff username and password has to match the preset one
                    {
                        close = true;
                        StaffMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Incorrect Username or " +
                            "Password"
                            + "\nPlease re-enter your " +
                            "login details \n");

                    }

                }

                //Member login
                
                else if (menuChoice == "member")
                {
                    try
                    { //Check to see if the member with the entered username or password exist in the members array
                        Member foundMember = Array.Find(MemberCollection.members,
                            item => item.UserName == currentUserName &&
                            item.Password.ToString() == password);
                        if (foundMember.UserName == currentUserName &&
                            foundMember.Password.ToString() == password)
                        {
                            close = true;

                            //MemberCollection.currentLoggedIn[MemberCollection.currentLoggedIndex] = currentUserName;
                            //Array.Resize(ref MemberCollection.currentLoggedIn, MemberCollection.currentLoggedIn.Length + 1);
                            //MemberCollection.currentLoggedIndex += 1;
                            MemberMenu();
                            
                        }
                    }
                    catch(NullReferenceException)
                    {
                        Console.Clear();
                        Console.WriteLine("Incorrect Username or " +
                            "Password"
                            + "\nPlease re-enter your " +
                            "login details \n");
                    }
                }

            }
        }
    }
}



