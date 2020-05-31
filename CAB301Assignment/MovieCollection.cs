using System;
using CAB301Assignment;

namespace CAB301Assignment
{
    public class MovieCollection
    {
        public static BinarySearchTree binaryTree = new BinarySearchTree();


        public static void PreMadeMovies()
        {
            Movie newMovie1 = new Movie("Love Island", "Johnny Depp ", "Koal ",
        60, "Comedy", 2019, "M", 2);
            Movie newMovie2 = new Movie("Prisoners", "Leonardo", "JK Rowling",
                128, "Triller ", 2018, "MA15+", 3);
            Movie newMovie3 = new Movie("A Little", "Phai Chai", "Emily Pomeroy"
                , 120, "Animated", 2019, "G", 1);
            Movie newMovie4 = new Movie("Jason Bourne", "Actor 1", "Director 1"
                , 165, "Action", 2008, "M", 1);
            Movie newMovie5 = new Movie("Joseph", "Actor 2", "Director 2"
                , 110, "Sci-Fi", 2013, "MA15+", 1);
            Movie newMovie6 = new Movie("Sim", "James Mc ", "Deno ",
        120, "Action", 2019, "MA15+", 1);
            Movie newMovie7 = new Movie("Harry Potter", "Harry", "JK Rowling",
                128, "Triller ", 2015, "M15+", 3);
            Movie newMovie8 = new Movie("Jedi", "Sam Lawson", "Joker"
                , 120, "Animated", 2019, "G", 1);
            Movie newMovie9 = new Movie("1917", "Ben Hamilton", "JFF"
                , 165, "Action, Triller", 2019, "M", 3);
            Movie newMovie10 = new Movie("Avengers", "Chris Pratt", "Stanley"
                , 130, "Action", 2018, "MA15+", 4);
            Movie newMovie11 = new Movie("Scary Movie 5", "John Cena", "HK Bent"
                , 130, "Horror, comedy", 2016, "MA15+", 2);
            Movie newMovie12 = new Movie("movie1", "s1", "d1"
              , 120, "Animated", 2019, "G", 1);
            Movie newMovie13 = new Movie("movie2", "s2", "d2"
                , 165, "Action, Triller", 2019, "M", 3);
            Movie newMovie14 = new Movie("movie3", "s3", "d3"
                , 130, "Action", 2018, "MA15+", 4);
            Movie newMovie15 = new Movie("movie4", "s4", "d4"
                , 130, "Horror, comedy", 2016, "MA15+", 2);


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
            binaryTree.PreOrderTraversal();
            binaryTree.InOrderTraversal();
            binaryTree.PostOrderTraversal();
        }
        public void AddMovie()
        {

            string title, starring, director, genre,
                classification;
            int duration, releaseDate, copies;

            string searchTitle = "";
            Movie Movie = new Movie();

            Console.WriteLine("------Add new movie-------");
            Console.Write("Movie title: ");
            title = Console.ReadLine();

            try
            {//Check to see if movie title already exists in the binary tree
                searchTitle = binaryTree.SearchByTitle(title).Data().getTitle();

            }
            catch (NullReferenceException)
            {

            }

            if (searchTitle == title)
            {//Title matches that of one in the binary tree
                Console.Clear();
                Console.Write("Enter the number of copies you want to add: ");
                int.TryParse(Console.ReadLine(), out copies);
                binaryTree.SearchByTitle(title).Data().AddCopy(copies);
            }
            else
            {//Continue in the process of adding movie
                Console.Write("Starring: ");
                starring = Console.ReadLine();
                Console.Write("Director(s): ");
                director = Console.ReadLine();
                Console.Write("Movie Duration: ");
                int.TryParse(Console.ReadLine(), out duration);
                genre = Menus.GenreOptions(); //Display the genre options
                Console.Write("Release date: ");
                int.TryParse(Console.ReadLine(), out releaseDate);
                classification = Menus.ClassificationOptions(); //Display the classification options
                Console.Write("Number of copies: ");
                int.TryParse(Console.ReadLine(), out copies);


                //Check to see that the fields are not null or empty
                if (!String.IsNullOrEmpty(title) && !String.IsNullOrEmpty(starring)
                    && !String.IsNullOrEmpty(director) && releaseDate > 0 && duration > 0
                    && copies > 0)
                {
                    Movie newMovie = new Movie(title, starring, director, duration,
                    genre, releaseDate, classification, copies);

                    binaryTree.Add(newMovie); //Add movie to binary tree
                    Console.WriteLine("=========Movie Added=======");
                    DisplayMovieInfoCreation(title, starring, director, duration, genre,
                        releaseDate, classification, copies); //Display the movie that has just been added

                }
                else
                {//Field(s) were null or empty
                    DisplayMovieInfoCreation(title, starring, director, duration, genre,
                        releaseDate, classification, copies); //Display the movie that the user was trying to add
                    Console.WriteLine("\nInvalid Input (Fields cannot be empty or null)");
                    Console.WriteLine("\nPress any key to go back to staff menu");
                    return;
                }
            }
        }


        //Display movie info function
        private void DisplayMovieInfoCreation(string title, string starring,
            string director, int duration, string genre, int releaseDate,
            string classification, int copies)
        {
            Console.WriteLine("\nTitle: {0}\nStarring: {1}\nDirector: {2}" +
                        "\nDuration: {3}\nGenre: {4}\nRelease Date: {5}" +
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
                    binaryTree.InOrderTraversal();
                    Console.WriteLine("\nThe movie you entered does not exist");
                    Console.Write("\nPlease enter the title of the movie you" +
                        " want to remove: ");
                    userInput = Console.ReadLine();
                }
            }

            //Delete the movie in the binary tree if found
            binaryTree.Delete(binaryTree.SearchByTitle(userInput).Data());
            binaryTree.InOrderTraversal();
            Console.WriteLine("\n\nThe movie '{0}' has been deleted",
             userInput);


        }

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

        public int Partition(Movie[] movies, int left, int right)
        {
            Movie temp;
            int pivot = movies[right].GetBorrowedFrequency();
            int i = left - 1;

            for (int j = left; j <= right - 1; j++)
            {
                if (movies[j].GetBorrowedFrequency() <= pivot)
                {
                    i++;
                    temp = movies[i];
                    movies[i] = movies[j];
                    movies[j] = temp;
                }
            }
            temp = movies[i + 1];
            movies[i + 1] = movies[right];
            movies[right] = temp;
            return i + 1;

        }

        public void QuickSort(Movie[] movies, int left, int right)
        {
            // For Recusrion
            if (left < right)
            {
                int pivot = Partition(movies, left, right);
                QuickSort(movies, left, pivot - 1);
                QuickSort(movies, pivot + 1, right);
            }
        }

        public void DisplayTop10()
        {
            int indexSize = binaryTree.BTSize(binaryTree.Root);
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
                    Console.WriteLine("The movie {0} has been borrowed: {1}",
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
                //Node currentNode = this;
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
                        //If the title is located to the left of the current node
                        {
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
                        {//Movie title is less than that of the current node movie.Title so move down the left side of the tree by one node
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
                //first go to left child its children will be null so print its data
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








