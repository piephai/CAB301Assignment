using System;


namespace CAB301Assignment
{

    public class Member
    {
        public Movie[] borrowedMovies;
        private int NUM;

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
            this.borrowedMovies = new Movie[1];
        }

        //Declarations
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public int PhoneNumber { get; set; }
        public int Password { get; set; }


        //Borrow a movie increases the size of the borrowedMovies array
        public void BorrowMovie(Movie movie)
        {
            this.borrowedMovies[NUM] = movie;
            Array.Resize<Movie>(ref borrowedMovies, borrowedMovies.Length + 1);
            NUM += 1;

        }


        //Return the currently held copy of movie DVD and remove that movie DVD from borrowedMovies array
        public void ReturnCurrentBorrowedMovies(Movie movie)
        {
            
            for (int i = 0; i < borrowedMovies.Length; i++)
            {
                try
                {
                    if (movie.Title == borrowedMovies[i].Title)
                    {
                        borrowedMovies[i] = null;
                    }
                }
                catch (NullReferenceException)
                {
                    
                }
            }

        }



        //Check for the member currently borrowed movies
        public void CurrentlyBorrowedMovie()
        {
            if (borrowedMovies.Length == 1)
            {
                Console.WriteLine("This user currently has no borrowed movie");
            }
            else
            {
                foreach (Movie movie in borrowedMovies)
                {
                    if (movie == null)
                    {//Do nothing and pass over

                    }
                    else
                    {
                        movie.PrintMovie();
                    }
                }
            }
        }

        //To write out the member information
        public override string ToString()
        {
            return String.Format("\n\n" +
                "First Name: {0}\nLast Name: {1}\nAddress: {2}\n" +
                "Phone Number: 61+ {3}\nPassword (4 Digits Number): {4}" +
                "\nUsername: {5}\nNumber of movies borrowing: {6}", char.ToUpper(FirstName[0]) +
                FirstName.Substring(1), char.ToUpper(LastName[0]) +
                LastName.Substring(1), Address, PhoneNumber,
                Password, UserName, borrowedMovies.Length - 1);
        }
    }
}




        

