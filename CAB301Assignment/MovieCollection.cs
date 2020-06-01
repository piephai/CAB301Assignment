using System;
using CAB301Assignment;

namespace CAB301Assignment
{
    public class MovieCollection
    {
        public static BinarySearchTree binaryTree = new BinarySearchTree();


        public void PreMadeMovies()
        {
            Movie newMovie1 = new Movie("Love Island", "Johnny Depp ", "Koal ",
        60, "Comedy", 2019, "M", 2, 2);
            Movie newMovie2 = new Movie("Prisoners", "Leonardo", "JK Rowling",
                128, "Triller ", 2018, "MA15+", 3, 3);
            Movie newMovie3 = new Movie("A Little", "Phai Chai", "Emily Pomeroy"
                , 120, "Animated", 2019, "G", 1, 1);
            Movie newMovie4 = new Movie("Jason Bourne", "Actor 1", "Director 1"
                , 165, "Action", 2008, "M", 1, 3);
            Movie newMovie5 = new Movie("Joseph", "Actor 2", "Director 2"
                , 110, "Sci-Fi", 2013, "MA15+", 1, 5);
            Movie newMovie6 = new Movie("Sim", "James Mc ", "Deno ",
        120, "Action", 2019, "MA15+", 1, 1);
            Movie newMovie7 = new Movie("Harry Potter", "Harry", "JK Rowling",
                128, "Triller ", 2015, "M15+", 3, 3);
            Movie newMovie8 = new Movie("Jedi", "Sam Lawson", "Joker"
                , 120, "Animated", 2019, "G", 1, 2);
            Movie newMovie9 = new Movie("1917", "Ben Hamilton", "JFF"
                , 165, "Action, Triller", 2019, "M", 3, 2);
            Movie newMovie10 = new Movie("Avengers", "Chris Pratt", "Stanley"
                , 130, "Action", 2018, "MA15+", 4, 10);
            Movie newMovie11 = new Movie("Scary Movie 5", "John Cena", "HK Bent"
                , 130, "Horror, comedy", 2016, "MA15+", 2, 4);
            Movie newMovie12 = new Movie("movie1", "s1", "d1"
              , 120, "Animated", 2019, "G", 1, 5);
            Movie newMovie13 = new Movie("movie2", "s2", "d2"
                , 165, "Action, Triller", 2019, "M", 3, 2);
            Movie newMovie14 = new Movie("movie3", "s3", "d3"
                , 130, "Action", 2018, "MA15+", 4, 2);
            Movie newMovie15 = new Movie("movie4", "s4", "d4"
                , 130, "Horror, comedy", 2016, "MA15+", 2, 1);


            binaryTree.Add(newMovie1);
            binaryTree.Add(newMovie2);
            binaryTree.Add(newMovie3);
            binaryTree.Add(newMovie4);
            binaryTree.Add(newMovie5);
            binaryTree.Add(newMovie6);
            binaryTree.Add(newMovie7);
            binaryTree.Add(newMovie8);
            binaryTree.Add(newMovie9);
            binaryTree.Add(newMovie10);
            binaryTree.Add(newMovie11);
            binaryTree.Add(newMovie12);
            binaryTree.Add(newMovie13);
            binaryTree.Add(newMovie14);
            binaryTree.Add(newMovie15);

        }
        public void AddMovie()
        {

            string title = "";
            string starring = "";
            string director = "";
            string searchTitle = "";
            string classification, genre;
            int duration = 0;
            int releaseDate = 0;
            int copies = 0;
            int borrowedFrequency = 0;

            
            Movie Movie = new Movie();

            Console.WriteLine("------Add new movie-------");
            title = "";
            while (String.IsNullOrEmpty(title))
            {
                Console.Write("Movie title: ");
                title = Console.ReadLine();
                if (String.IsNullOrEmpty(title))
                {
                    Console.WriteLine("Title field cannot be empty");
                }

                try
                {//Check to see if movie title already exists in the binary tree
                    searchTitle = binaryTree.SearchByTitle(title).Data().getTitle();

                }
                catch (NullReferenceException)
                {

                }
            }

            if (searchTitle == title)
            {//Title matches that of one in the binary tree
                Console.Write("Enter the number of copies you want to add: ");
                int.TryParse(Console.ReadLine(), out copies);
                binaryTree.SearchByTitle(title).Data().AddCopy(copies);
            }
            else
            {//Continue in the process of adding movie
               
                while (String.IsNullOrEmpty(starring))
                {
                    Console.Write("Starring: ");
                    starring = Console.ReadLine();
                    if (String.IsNullOrEmpty(starring))
                    {
                        Console.WriteLine("Starring field cannot be empty");
                    }
                }
                //Check if the director field is null or empty if not then continue
                
                while (String.IsNullOrEmpty(director))
                {
                    Console.Write("Director(s): ");
                    director = Console.ReadLine();
                    if (String.IsNullOrEmpty(director))
                    {
                        Console.WriteLine("Director field cannot be empty");
                    }
                }

                //Check if duration field is greater than 0 if it is then continue
                duration = 0;
                while (duration <= 0)
                {
                    Console.Write("Movie Duration (minutes): ");
                    int.TryParse(Console.ReadLine(), out duration);
                    if (duration <= 0)
                    {
                        Console.WriteLine("Invalid movie duration");
                    }
                }

                genre = Menus.GenreOptions(); //Display the genre options

                //Check to see if release date is in the set range
                releaseDate = 0;
                while (releaseDate < 1900 || releaseDate > 2025)
                {
                    Console.Write("Release date (year): ");
                    int.TryParse(Console.ReadLine(), out releaseDate);
                    if (releaseDate < 1900 || releaseDate > 2025)
                    {
                        Console.WriteLine("Please enter a valid release date");
                    }
                }
                classification = Menus.ClassificationOptions(); //Display the classification options
                while (copies <= 0)
                {
                    Console.Write("Number of copies: ");
                    int.TryParse(Console.ReadLine(), out copies);
                    if (copies <= 0)
                    {
                        Console.WriteLine("Invalid number of copies");
                    }
                }


                Movie newMovie = new Movie(title, starring, director, duration,
                genre, releaseDate, classification, copies, borrowedFrequency); //Initialise a new movie object with the user inputs

                binaryTree.Add(newMovie); //Add movie to binary tree
                Console.WriteLine("=========Movie Added=======");
                DisplayMovieInfoCreation(title, starring, director, duration, genre,
                    releaseDate, classification, copies); //Display the movie that has just been added


            }
        }




        //Display movie info
        private void DisplayMovieInfoCreation(string title, string starring,
            string director, int duration, string genre, int releaseDate,
            string classification, int copies)
        {
            Console.WriteLine("\nTitle: {0}\nStarring: {1}\nDirector: {2}" +
                        "\nDuration (minutes): {3}\nGenre: {4}\nRelease Date (year): {5}" +
                        "\nClassification: {6}\nNumber of copies: {7}",
                        title, starring, director, duration,
                        genre, releaseDate, classification, copies);
        }

        //Display all movies in alphabetical order
        public void DisplayAllMovies()
        {
            Console.WriteLine("================All Movies============");
            binaryTree.InOrderTraversal();

        }

        //Remove a movie from the binary tree
        public void RemoveMovie()
        {

            bool isFound = false;
            Console.WriteLine("-----Remove a movie------");
            Console.Write("Please enter the title of the movie " +
                "you want to remove: ");
            string userInput = Console.ReadLine();


            while (isFound == false)
            {
                try //Search for the movie with a matching title in the binary tree
                {
                    binaryTree.SearchByTitle(userInput).Data().getTitle();
                    isFound = true;
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("\nThe movie you entered does not exist");
                    Console.Write("\nPlease enter the title of the movie you" +
                        " want to remove: ");
                    userInput = Console.ReadLine();
                }
            }

            //Delete the movie in the binary tree if found
            binaryTree.Delete(binaryTree.SearchByTitle(userInput).Data());
            Console.WriteLine("\n\nThe movie '{0}' has been deleted",
             userInput);


        }
        //Find the movie object
        public Movie FindMovie(string title)
        {
            try
            {
                return binaryTree.SearchByTitle(title).Data();
            }
            catch (NullReferenceException)
            {

            }
            return null;
        }

        //Partition for quick sort
        public int Partition(Movie[] movies, int left, int right)
        {
            Movie temp;
            int pivot = movies[right].GetBorrowedFrequency(); //Set the pivot 
            int i = left - 1;

            for (int j = left; j <= right - 1; j++) //Set the starting value j to be the equal to left then iterate up to the left index of value right
            {
                if (movies[j].GetBorrowedFrequency() <= pivot)
                {
                    i++; //Increase i value if j borrowed frequency is less than the pivot
                    temp = movies[i]; //Set the Temp movie to the current movies[i]
                    movies[i] = movies[j]; //Now the movies[i] is equal to the current index of movies[j]
                    movies[j] = temp; //Movie[j] is now the new Movie temp
                }//i will have increased after the iteration 
            }
            temp = movies[i + 1]; //Set the new temp to be movies the new i value + 1
            movies[i + 1] = movies[right];
            movies[right] = temp;
            return i + 1;

        }

        //Quick sort
        public void QuickSort(Movie[] movies, int left, int right)
        {
            // For Recursion
            if (left < right)
            {
                int pivot = Partition(movies, left, right);
                QuickSort(movies, left, pivot - 1);
                QuickSort(movies, pivot + 1, right);
            }
        }

        //Display top 10 most borrowed movies
        public void DisplayTop10()
        {
            int indexSize = binaryTree.BTSize(binaryTree.Root); //Set the index size to be the size of the Binary Tree
            Movie[] movies = new Movie[indexSize];

            binaryTree.BinaryTreeToArray(binaryTree.Root, movies);
            QuickSort(movies, 0, movies.Length - 1);
            PrintTop10(movies);
        }


        //Try and print the top 10 movies
        private void PrintTop10(Movie[] movies)
        {
            for (int i = movies.Length; i > movies.Length - 11; i--)
            {
                try
                {
                    Console.WriteLine("The movie {0} has been borrowed {1} times",
                        movies[i].getTitle(), movies[i].GetBorrowedFrequency());
                }
                catch
                {

                }
            }
        }


        //Node class
        public class Node
        {

            private Movie data;
            private Node lChild;
            private Node rChild;


            public Node(Movie movie)
            {
                this.data = movie;
            }

            public Node()
            {
            }

            public Node RightChild
            {
                get { return rChild; }
                set { rChild = value; }
            }
            public Movie Data()
            {
                return data;
            }

            public Node LeftChild
            {
                get { return lChild; }
                set { lChild = value; }
            }


            public void Add(Movie movie)
            {
                //Check to see if movie title is before current title
                if (movie.Title.CompareTo(data.Title) <= 0)

                {
                    if (lChild == null)
                    {
                        lChild = new Node(movie); //Check to see if the left child node is null if it is add new node at left child

                    }
                    else
                    {
                        lChild.Add(movie); //If left child node is not null insert movie object into it
                    }
                }
                else
                {
                    if (rChild == null)
                    {
                        rChild = new Node(movie);
                    }
                    else
                    {
                        rChild.Add(movie);
                    }
                }
            }

            public Node SearchByTitle(Node currentNode, string searchTitle)
            {
                if (currentNode != null)
                {
                    //If title match current Node
                    if (searchTitle.CompareTo(currentNode.data.getTitle()) == 0)
                    {
                        return currentNode;
                    }

                    //If the title is located to the right of the current node
                    else

                    {
                        if (searchTitle.CompareTo(currentNode.data.getTitle()) < 0)
                        {//If the title is located to the left of the current node
                            return SearchByTitle(currentNode.lChild, searchTitle);
                        }
                        else
                        {
                            return SearchByTitle(currentNode.rChild, searchTitle);
                        }
                    }
                }
                else
                {
                    return null; //If node does not exist
                }
            }

            public Node Search(Node currentNode, Movie movie)
            {
                if (currentNode != null)
                {
                    if (movie == currentNode.data)
                    {
                        return currentNode;
                    }
                    else
                    {
                        if (movie.getTitle().CompareTo(currentNode.data.getTitle()) < 0)
                        {//Movie title comes before the current node movie.Title so move down the left side of the tree by one node
                            return Search(currentNode.lChild, movie);
                        }
                        else
                        {//Move down the right side of the tree by one Node
                            return Search(currentNode.rChild, movie);
                        }
                    }
                }
                else
                {
                    return null;
                }

            }

            //Sorting alphabetically by the movie title
            public void InOrderTraversal()
            {
                //First go to left child its children will be null so print its data
                if (lChild != null)
                    lChild.InOrderTraversal();
                Console.Write(data);

                //Then we go to the right node which will print itself as both its children are null
                if (rChild != null)
                    rChild.InOrderTraversal();
            }

            public void PreOrderTraversal()
            {
                Console.Write(data);
                if (lChild != null)
                {
                    lChild.InOrderTraversal();
                }
                if (rChild != null)
                {
                    rChild.PreOrderTraversal();
                }
            }

            public void PostOrderTraversal()
            {
                if (lChild != null)
                {
                    lChild.InOrderTraversal();
                }
                if (rChild != null)
                {
                    rChild.InOrderTraversal();
                }
                Console.Write(data);
            }

            public void BinaryTreeToArray(Node currentNode)
            {
                if (currentNode != null)
                {
                    BinaryTreeToArray(currentNode.lChild);
                }



            }
        }

        //BST class
        public class BinarySearchTree
        {
            private Node root;

            public Node Root
            {
                get { return root; }
            }


            public void Add(Movie movie)
            {


                if (root != null)
                {       //If root is not null then add method is called on root node
                    root.Add(movie);
                }

                else
                {      //Else root is null then root is new node
                    root = new Node(movie);
                }

            }

            public Node SearchByTitle(string searchTitle)
            {
                //If root is not null we call find method on the root
                if (root != null)
                {

                    return root.SearchByTitle(root, searchTitle);


                }
                else
                {
                    //If root is null then return null since there is nothing to find
                    return null;
                }
            }

            public Node Search(Movie movie)
            {
                if (root != null)
                {
                    return root.Search(root, movie);
                }
                else
                {
                    return null;
                }
            }

            public void Delete(Movie movie)
            {
                //Set current and parent node to root so when a node is remove it is done
                // from the parent node
                Node currentNode = root;
                Node parentNode = root;
                bool islChild = false;
                if (currentNode == null)
                {
                    return;
                }

                //Loop through to find matching node unless no node is found
                while (currentNode != null && currentNode.Data() != movie)
                {
                    parentNode = currentNode;

                    //If the data is less than the current data 
                    if (movie.getTitle().CompareTo(currentNode.Data().getTitle())
                        < 0)
                    {
                        currentNode = currentNode.LeftChild;
                        islChild = true;

                    } //If the data is more than the current data
                    else
                    {
                        currentNode = currentNode.RightChild;
                        islChild = false;
                    }
                }
                //If no node is found return
                if (currentNode == null)
                {
                    return;
                }

                //Check for leaf node (node with no children)
                if (currentNode.LeftChild == null &&
                    currentNode.RightChild == null)
                {
                    //Root has no parent to check for what child it is
                    if (currentNode == root)
                    {
                        root = null;
                    }
                    //Check if child of parent should be deleted
                    else
                    {
                        if (islChild)
                        {
                            //Remove left child reference
                            parentNode.LeftChild = null;
                        }
                        else
                        {
                            //Remove right child reference
                            parentNode.RightChild = null;
                        }
                    }
                }
                //Has only one left child
                else if (currentNode.RightChild == null)
                {
                    if (currentNode == root)
                    {
                        root = currentNode.LeftChild;
                    }
                    else
                    {
                        //Left or right child
                        if (islChild)
                        {
                            parentNode.LeftChild = currentNode.LeftChild;
                        }
                        else
                        {
                            parentNode.RightChild = currentNode.RightChild;
                        }
                    }
                }
                else //Current node has both children
                {
                    //Find sucessorNode
                    Node sucessorNode = GetSuccessor(currentNode);

                    //If the current node is the root node then the new root is the sucessorNode node
                    if (currentNode == root)
                    {
                        root = sucessorNode;
                    }
                    else if (islChild)
                    {//if this is the left child set the parents left child node as the sucessorNode node
                        parentNode.LeftChild = sucessorNode;
                    }
                    else
                    {//if this is the right child set the parents right child node as the sucessorNode node
                        parentNode.RightChild = sucessorNode;
                    }

                }
            }

            //Helper function to allocated a node as the new successor node
            private Node GetSuccessor(Node node)
            {
                Node parentOfSuccessor = node;
                Node sucessorNode = node;
                Node currentNode = node.RightChild;

                //Starting at the right child go down every left child nodes
                while (currentNode != null)
                {
                    parentOfSuccessor = sucessorNode;
                    sucessorNode = currentNode;
                    currentNode = currentNode.LeftChild;// Go to the next left node
                }
                //if the succesor is not just the right node then
                if (sucessorNode != node.RightChild)
                {
                    //set the Left node on the parent node of the succesor node to the right child node of the sucessorNode in case it has one
                    parentOfSuccessor.LeftChild = sucessorNode.RightChild;
                    //attach the right child node of the node being deleted to the sucessorNodes right node
                    sucessorNode.RightChild = node.RightChild;
                }
                //attach the left child node of the node being deleted to the sucessorNodes leftnode node
                sucessorNode.LeftChild = node.LeftChild;

                return sucessorNode;
            }


            //Display nodes in order
            public void InOrderTraversal()
            {
                if (root != null)
                {
                    Console.WriteLine("");
                    root.InOrderTraversal();
                }
            }
            //Display nodes pre order
            public void PreOrderTraversal()
            {
                if (root != null)
                {
                    Console.WriteLine("\nPre Order: \n");
                    root.PreOrderTraversal();
                }
            }
            //Display nodes post order
            public void PostOrderTraversal()
            {
                if (root != null)
                {
                    Console.WriteLine("\nPost Order: \n");
                    root.PostOrderTraversal();
                }
            }

            //Check for the size of the binary tree
            public int BTSize(Node currentNode)
            {
                int size = 1;
                if (currentNode != null)
                {
                    size += BTSize(currentNode.LeftChild);
                    size += BTSize(currentNode.RightChild);

                }
                else
                {
                    return 0;
                }
                return size;
            }

            //Change the binary tree into array recursively
            public void BinaryTreeToArray(Node node, Movie[] movies)
            {

                if (node != null)
                {
                    BinaryTreeToArray(node.LeftChild, movies);
                    for (int i = 0; i < movies.Length; i++)
                    {
                        if (movies[i] == null)
                        {
                            movies[i] = node.Data();
                            break;
                        }
                    }
                    BinaryTreeToArray(node.RightChild, movies);
                }
            }

        }

    }
}








