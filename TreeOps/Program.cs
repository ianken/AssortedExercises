using System;

namespace TreeOps
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] inputData = { 1, 2, 3, 4, 5, 6, 7, 8, 9,10,10 };
            int[] inputBTData = {10,7,14,20,1,5,8};
            Random rnd = new System.Random();
            
            var tree = new Tree();
            var bTree = new Tree();

            tree.BuildTree(inputData, tree.Root, 0);
            bTree.BuildBinaryTree(inputBTData,bTree.Root);

            var result = bTree.LevelOrderTraversal();
            result = tree.LevelOrderTraversal();
            result = tree.PostOrderTraversal();
            result = tree.InOrderTraversal();

        }
    }
}
