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
        60, "Comedy", "2019/10/19", "M");
            Movie newMovie2 = new Movie("Prisoners", "Leonardo", "JK Rowling",
                128, "Triller ", "2017/05/24 ", "MA15+");
            Movie newMovie3 = new Movie("A Little", "Phai Chai", "Emily Pomeroy"
                , 120, "Animated", "2015/08/12 ", "G");
            Movie newMovie4 = new Movie("Jason Bourne", "Actor 1", "Director 1"
                , 165, "Action", "2012/07/12", "M");
            Movie newMovie5 = new Movie("Joseph", "Actor 2", "Director 2"
                , 110, "Sci-Fi", "2014/03/12", "MA15+");

            binaryTree.Add(newMovie1);
            binaryTree.Add(newMovie2);
            binaryTree.Add(newMovie3);
            binaryTree.Add(newMovie4);
            binaryTree.Add(newMovie5);
            binaryTree.PreOrderTraversal();
            binaryTree.InOrderTraversal();
            binaryTree.PostOrderTraversal();
        }
        public void AddMovie()
        {

            string title, starring, director, genre, releaseDate,
                classification;
            int duration;



            Console.WriteLine("------Add new movie-------");
            Console.Write("Movie title: ");
            title = Console.ReadLine();
            Console.Write("Starring: ");
            starring = Console.ReadLine();
            Console.Write("Director(s): ");
            director = Console.ReadLine();
            Console.Write("Movie Duration: ");
            int.TryParse(Console.ReadLine(), out duration);
            Console.Write("Genre: ");
            genre = Menus.GenreOptions();
            Console.Write("Release date: ");
            releaseDate = Console.ReadLine();
            Console.Write("Classification: ");
            classification = Menus.ClassificationOptions();

            Movie newMovie = new Movie(title, starring, director, duration,
            genre, releaseDate, classification);

            binaryTree.Add(newMovie);
            binaryTree.InOrderTraversal();


            //tree.PreOrderDisplay();
            //tree.InOrderDisplay();
            //tree.Delete(newMovie3.ToString());
            //tree.PostOrderDisplay();
        }

        public void DisplayInfo()
        {
            binaryTree.InOrderTraversal();
        }

        public void RemoveMovie()
        {



            bool isFound = false;
            Console.WriteLine("-----Remove a movie------");
            Console.Write("Please enter the title of the movie " +
                "you want to remove: ");
            string userInput = Console.ReadLine();


            while (isFound == false)
            {
                try
                {
                    binaryTree.Search(userInput).Data().getTitle();
                    isFound = true;
                }
                catch (NullReferenceException)
                {
                    binaryTree.InOrderTraversal();
                    Console.WriteLine("\nThe movie you entered does not exist");
                    Console.Write("\nPlease enter the title of the movie you" +
                        "want to remove: ");
                    userInput = Console.ReadLine();
                }
            }

            
            binaryTree.Delete(binaryTree.SearchMovie(userInput).Data());
            binaryTree.InOrderTraversal();
            Console.WriteLine("\nThe movie '{0}' has been deleted",
             userInput);


        }

       


        public class Node
        {

            private Movie data;
            private Node lChild;
            private Node rChild;
            private bool isDeleted;

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

            //Check to see if something is deleted
            public bool IsDelete
            {
                get { return isDeleted; }
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

            public Node Search(Node currentNode, string searchTitle)
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
                            return Search(currentNode.lChild, searchTitle);
                        }
                        else
                        {
                            return Search(currentNode.rChild, searchTitle);
                        }
                    }
                }
                else
                {
                    return null; //If node does not exist
                }
            }

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

            public Movie searchMovie(string searchTitle)
            {
                try
                {

                    return binaryTree.Search(searchTitle).Data();
                }
                catch (NullReferenceException)
                {

                }
                return null;
            }



        }

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

            public Node Search(string searchTitle)
            {
                //If root is not null we call find method on the root
                if (root != null)
                {

                    return root.Search(root, searchTitle);


                }
                else
                {
                    //If root is null then return null since there is nothing to find
                    return null;
                }
            }

            public Node SearchMovie(string searchTitle)
            {
                if (root != null)
                {
                    return root.Search(root, searchTitle);
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
                while (currentNode != null && currentNode.Data()!= movie)
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

            //public void SoftDelete(Movie movie)
            //{
            //    Node toDelete = Search(movie);

            //    if (toDelete!= null)
            //    {
            //        toDelete.IsDelete();
            //    }
            //}

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
                    Console.WriteLine("\nIn Order: \n");
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







            //private Node BalanceTree(Movie movie)
            //{

            //}

            //private int max(int l, int r)
            //{
            //    return l > r ? l : r;
            //}
            //private int getHeight(Movie movie)
            //{
            //    int height = 0;
            //    if (root != null)
            //    {
            //        int l = getHeight();
            //        int r = getHeight(root.Right);
            //        int m = max(l, r);
            //        height = m + 1;
            //    }
            //    return height;
            //}
            //private int balance_factor(Node current)
            //{
            //    int l = getHeight(current.left);
            //    int r = getHeight(current.right);
            //    int b_factor = l - r;
            //    return b_factor;
            //}
        }
    }
}






//      public class Node
//    {
//        //Declrations
//        Movie data;         //Data
//        Node lChild; //Left child
//        Node rChild; //Right child

//        //Constructor
//        public Node(Movie movie)
//        {
//            data = movie;
//        }

//        //Properties

//        public Node Right
//        {
//            get { return rChild; }
//            set { rChild = value; }
//        }
//        public Movie Data
//        {
//            get { return data; }
//            set { data = value; }
//        }

//        public Node Left
//        {
//            get { return lChild; }
//            set { lChild = value; }
//        }


//    }

//    public class BinarySearchTreeNode
//    {
//        private Movie data; // Value
//        private BinarySearchTreeNode lchild; // Left child
//        private BinarySearchTreeNode rchild; // Right child




//        public Movie Data
//        {
//            get { return data; }
//            set { data = value; }
//        }

//        public BinarySearchTreeNode(Movie data)
//        {
//            this.data = data;
//            lchild = null;
//            rchild = null;
//        }

//        public BinarySearchTreeNode LChild
//        {
//            get { return lchild; }
//            set { lchild = value; }
//        }

//        public BinarySearchTreeNode RChild
//        {
//            get { return rchild; }
//            set { rchild = value; }
//        }



//        public class BinarySearchTree 
//    {
//        private Node root;
//            private Movie data;
//            private Node lChild;
//            private Node rChild;

//        //Initialising
//        public BinarySearchTree()
//        {
//            root = null;
//        }

//        //Return the found node
//        public bool Search(IComparable data)
//        {
//            return Search(data, root);
//        }

//        //Check of node is empty
//        public bool IsEmpty()
//        {
//            return root == null;
//        }


//        ////Search all for a node in the tree return true if node exist and return that node
//        //private bool Search(IComparable data, BinarySearchTreeNode r)
//        //{
//        //    if (r != null)
//        //    {
//        //        if (data.CompareTo(r.Data) == 0)
//        //            return true;
//        //        else if (data.CompareTo(r.Data) < 0)
//        //            return Search(data, r.LChild);
//        //        else
//        //            return Search(data, r.RChild);
//        //    }
//        //    else
//        //        return false;
//        //}

//        //Insert a node into the tree
//        public void Insert(IComparable data)
//        {
//            if (root == null)
//                root = new BinarySearchTreeNode(data);
//            else
//                Insert(data, root);
//        }

//        //Insert an data into the binary tree at proot
//        private void Insert(Movie movie)
//        {
//            if (String.CompareOrdinal(movie.Title, data.Title) < 0)
//            {
//                if (lChild == null)
//                   lChild = new BinarySearchTreeNode(movie);
//                else
//                    Insert(data, proot.LChild);
//            }
//            else
//            {
//                if (proot.RChild == null)
//                    proot.RChild = new BinarySearchTreeNode(data);
//                else
//                    Insert(data, proot.RChild);
//            }
//        }


//        public void Delete(IComparable data)
//        {
//            // Search for data and its parent
//            BinarySearchTreeNode proot = root; // Search reference
//            BinarySearchTreeNode parent = null; // Parent of proot
//            while ((proot != null) && (data.CompareTo(proot.Data) != 0))
//            {
//                parent = proot;
//                if (data.CompareTo(proot.Data) < 0) // Move to the lChild of proot
//                    proot = proot.LChild;
//                else
//                    proot = proot.RChild;
//            }

//            if (proot != null) // Check to see if search is successful
//            {
//                // Case 1: Data has two children
//                if (proot.LChild != null && proot.RChild != null)
//                {
//                    // Find the furthest rChild node in lChild
//                    if (proot.LChild.RChild == null) // If the rChild subtree of proot.LChild is empty
//                    {
//                        proot.Data = proot.LChild.Data;
//                        proot.LChild = proot.LChild.LChild;
//                    }
//                    else
//                    {
//                        BinarySearchTreeNode p = proot.LChild;
//                        BinarySearchTreeNode parentP = proot; 
//                        while (p.RChild != null)
//                        {
//                            parentP = p;
//                            p = p.RChild;
//                        }
//                        // Copy the data at p to proot
//                        proot.Data = p.Data;
//                        parentP.RChild = p.LChild;
//                    }
//                }
//                else // Cases 2 & 3: The data has no or only one child
//                {
//                    BinarySearchTreeNode child;
//                    if (proot.LChild != null)
//                        child = proot.LChild;
//                    else
//                        child = proot.RChild;

//                    // Remove node proot
//                    if (proot == root) //Change the root node after remove
//                        root = child;
//                    else
//                    {
//                        if (proot == parent.LChild)
//                            parent.LChild = child;
//                        else
//                            parent.RChild = child;
//                    }
//                }

//            }
//        }

//        //Display nodes in pre order
//        public void PreOrderDisplay()
//        {
//            Console.Write("Pre-Order: ");
//            PreOrderTraversal(root);
//            Console.WriteLine();
//        }

//        //Nodes are pre ordered
//        private void PreOrderTraversal(BinarySearchTreeNode root)
//        {
//            if (root != null)
//            {
//                Console.Write(root.Data);
//                PreOrderTraversal(root.LChild);
//                PreOrderTraversal(root.RChild);
//            }

//        }



//        //Display node in post order
//        public void PostOrderDisplay()
//        {
//            Console.WriteLine("Post Order: ");
//            PostOrderTraversal(root);
//            Console.WriteLine();
//        }

//        //Sort nodes post order
//        private void PostOrderTraversal(BinarySearchTreeNode root)
//        {
//            if (root != null)
//            {
//                PostOrderTraversal(root.LChild);
//                PostOrderTraversal(root.RChild);
//                Console.Write(root.Data);
//            }

//        }

//        //Clear all the nodes in the tree
//        public void Clear()
//        {
//            root = null;
//        }


//    }
//}





