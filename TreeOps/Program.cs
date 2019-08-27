using System;
using System.Linq;

namespace TreeOps
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] inputData = { 1 , 2, 3, 4, 5, 6, 7, 8 , 9, 10, 11,12,13,14 };
            int[] inputBTData = {10,7,14,20,1,5,8};
            int[] inputBTData2 = { 10, 7, 14,22 , 20, 1, 21,5, 8 };
            Random rnd = new System.Random();
            int[] randomInputData = Enumerable.Repeat(0, 10).Select(i => rnd.Next(0, 100)).ToArray();
            
            var tree = new Tree();
            var bTree = new Tree();
            var randTree = new Tree();

            tree.BuildTree(inputData);

            //BST search for largest node...
            bTree.BuildBinaryTree(inputBTData2);
            var BiggestNode = bTree.GetLargestBstNode();
            var BiggestInt = inputBTData2.OrderByDescending(i => i).First();

            randTree.BuildBinaryTree(randomInputData);
            
            var result = bTree.LevelOrderTraversal();
            result = tree.LevelOrderTraversal();
            result = tree.PostOrderTraversal();
            result = tree.InOrderTraversal();

            int height = 0;
                        
            height = tree.GetDepth();
            height = bTree.GetDepth();
            height = randTree.GetDepth();

           }
    }
}
