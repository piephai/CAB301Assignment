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
                Console.WriteLine("Staff Login");
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

        //Customer Menu
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
            Console.WriteLine(" \n Please make a selection (1-5," +
               " or 0 to return to the main menu) ");


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
                        Console.WriteLine("Invalid key entered. Please try again");
                        printMenu();
                        getInput();
                    }
                    return choice;
            
            }
        }
}
