using System;

namespace CAB301Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }


       

        static void MainMenu()

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

        uint choice = GetUserChoice(printMenu, 3);

        //Switch statement based on user choice
        switch (choice)

            {
            case 1:
                    StaffMenu();
                break;

            case 2:
                    MemberMenu();
                break;

            case 0:
                Console.WriteLine("Thank you for visiting the community " +
                    "library");
                break;
            default:
                throw new NotImplementedException();


            }

        }

        //Member Menu
        static void MemberMenu()
        {
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

            uint choice = GetUserChoice(printMenu, 6);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("All movies");
                    break;

                case 2:
                    Console.WriteLine("Borrow a movie DVD");
                    break;

                case 3:
                    Console.WriteLine("Return a movie DVD");
                    break;

                case 4:
                    Console.WriteLine("All current borrowed movie DVDs");
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
            //Creating the staff menu option
            Action printMenu = () =>
            {
                Console.WriteLine("1. Add a new movie DVD");
                Console.WriteLine("2. Remove a movie DVD");
                Console.WriteLine("3. Register a new Member");
                Console.WriteLine("4. Find a registered member's phone number");
                Console.WriteLine("0. Return to the main menu");
            };

            Console.Clear();
            Console.WriteLine("===========Staff Menu==========");
            printMenu(); 
            Console.WriteLine("================================");
            Console.WriteLine(" \n Please make a selection (1-4," +
               " or 0 to return to the main menu) ");

            uint choice = GetUserChoice(printMenu, 6);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Add a new movie DVD");
                    break;

                case 2:
                    Console.WriteLine("Remove a movie DVD");
                    break;

                case 3:
                    Console.WriteLine("Register a new member");
                    break;

                case 4:
                    Console.WriteLine("Registered Member's Phone Number");
                    break;

                case 0:
                    MainMenu();
                    break;
                default:
                    throw new NotImplementedException();


            }

        }

        // Getting user choice and making sure that their choice is valid 
        static uint GetUserChoice (Action printMenu, int choiceMax)
            {
                uint choice = 0;
                Action getInput = () =>
                {
                    uint.TryParse(Console.ReadLine(), out choice);
                };

                getInput();
         
                    while (choice < 0 || choice > choiceMax)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid key entered. " +
                            "Please try again");
                        printMenu();
                        getInput();
                    }
                    return choice;
            
            }
        }
}
