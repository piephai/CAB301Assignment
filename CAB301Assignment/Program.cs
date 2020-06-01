using System;

namespace CAB301Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            MemberCollection MemberCollection = new MemberCollection();
            MemberCollection.PreMadeMembers();
            MovieCollection MovieCollection = new MovieCollection();
            MovieCollection.PreMadeMovies();
            Menus.MainMenu();
        }
    }
}




        
