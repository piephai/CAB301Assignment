﻿using System;
namespace CAB301Assignment
{
    public class Movie
    {

        public Movie() { }
        public string Title { get; set; }
        public string Starring { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public int ReleaseDate { get; set; }
        public string Classification { get; set; }
        private int copies;
        private int borrowedFrequency;

        public int GetBorrowedFrequency()
        {
            return this.borrowedFrequency;
        }

        public int GetCurrentCopy ()
        {
            return this.copies;
        }
        public void AddCopy(int numCopies)
        {
            for (int i = 0; i < numCopies; i++)
            {
                this.copies += 1;
            }
        }

        public void Borrow()
        {
            this.borrowedFrequency += 1;
            this.copies -= 1;
        }

        public string getTitle()
        {
            return Title;
        }

        public Movie (string title, string starring, string director,
            int duration, string genre, int releaseDate,
            string classification, int copies)
        {
            this.Title = title;
            this.Starring = starring;
            this.Director = director;
            this.Duration = duration;
            this.Genre = genre;
            this.ReleaseDate = releaseDate;
            this.Classification = classification;
            this.copies = copies;
            this.borrowedFrequency = 0;
        }

        public void IncrementMovieFrequency()
        {
            this.borrowedFrequency += 1;
        }

        public void RemoveCopies()
        {
            this.copies -= 1;
        }

        public void PrintMovie()
        {
            Console.WriteLine("\nTitle: {0}\nStarring: {1}\nDirector: {2}" +
                    "\nDuration: {3}\nGenre: {4}\nRelease Date: {5}" +
                    "\nClassification: {6}\nNumber of copies: {7}\nNumber of times borrowed: {8}",
                    Title, Starring, Director, Duration,
                    Genre, ReleaseDate, Classification, copies, borrowedFrequency);
        }

        public override string ToString()
        {
            return String.Format("\n\nTitle: {0}\nStarring:{1}\nDirector:{2}\n" +
                "Duration {3}min\nGenre: {4}\n" +
                "Release Date: {5}\nRating: " +
                "{6}\nNumber of copies: {7}", Title,
                Starring, Director, Duration, Genre, ReleaseDate,
                Classification, copies);
        }


    }
}
