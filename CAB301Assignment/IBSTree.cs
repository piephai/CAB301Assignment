using System;
namespace CAB301Assignment
{

	public interface IBinarySearchTree
	{
        //Return true if the binary tree is empty else return false.
		bool IsEmpty();

        //Insert an item into the binary tree
		void Insert(Movie item);

        //Remove an item from the binary tree
		void Delete(Movie item);

        //Search for an item in the binary tree
		bool Search(string item);


        //Remove every items in the binary tree
		void Clear();



	}
}

