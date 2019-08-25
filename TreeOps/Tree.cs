using System;
using System.Collections.Generic;

namespace TreeOps
{

    public class Tree
    {
        public TreeNode Root;

        public class TreeNode
        {
            public int Data;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(int data)
            {
                this.Data = data;
                Left = null;
                Right = null;
            }
        }

        public TreeNode BuildTree(int[] input, TreeNode root, int index)
        {
            if (index < input.Length)
            {
                var newRoot = new TreeNode(input[index]);
                root = newRoot;

                // insert left child 
                root.Left = BuildTree(input, root.Left, 2 * index + 1);

                // insert right child 
                root.Right = BuildTree(input, root.Right, 2 * index + 2);
            }

            this.Root = root;
            return root;
        }

        public void BuildBinaryTree(int[] input,TreeNode root)
        {
            TreeNode result = null;

            foreach(int i in input)
            {
                result = BinaryTreeInsert(ref root,i);
            }

            this.Root = result;
        }

        public TreeNode BinaryTreeInsert(ref TreeNode root, int data)
        {
            if(root == null)
            {
                root = new TreeNode(data);
            }
            else if(root.Data > data)
                root.Left = BinaryTreeInsert(ref root.Left,data);
            else if(root.Data <= data)
                root.Right = BinaryTreeInsert(ref root.Right,data);
        
            return root;

        }

        public int[] LevelOrderTraversal()
        {
            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
            List<int> resultList = new List<int>();

            TreeNode temp = this.Root;

            if (Root != null)
                nodeQueue.Enqueue(temp);

            while (nodeQueue.Count != 0)
            {
                Console.WriteLine($"{temp.Data} ");
                resultList.Add(temp.Data);

                if (temp.Left != null)
                    nodeQueue.Enqueue(temp.Left);
                if (temp.Right != null)
                    nodeQueue.Enqueue(temp.Right);

                nodeQueue.Dequeue();
                if (nodeQueue.Count != 0)
                    temp = nodeQueue.Peek();
            }

            return resultList.ToArray();
        }

        public int[] PreOrderTraversal()
        {
            List<int> results = new List<int>();
            PreOrderTraversal(this.Root, results);

            return results.ToArray();
        }

        private void PreOrderTraversal(TreeNode root, List<int> results)
        {
            results.Add(root.Data);

            if (root.Left != null)
                PreOrderTraversal(root.Left, results);
            if (root.Right != null)
                PreOrderTraversal(root.Right, results);
        }

        public int[] PostOrderTraversal()
        {
            List<int> results = new List<int>();
            PostOrderTraversal(this.Root, results);

            return results.ToArray();
        }

        private void PostOrderTraversal(TreeNode root, List<int> results)
        {
            if (root.Left != null)
                PostOrderTraversal(root.Left, results);
            if (root.Right != null)
                PostOrderTraversal(root.Right, results);

            results.Add(root.Data);
        }

        public int[] InOrderTraversal()
        {
            List<int> results = new List<int>();
            InOrderTraversal(this.Root, results);

            return results.ToArray();
        }

        private void InOrderTraversal(TreeNode root, List<int> results)
        {
            if (root.Left != null)
                InOrderTraversal(root.Left, results);

            results.Add(root.Data);

            if (root.Right != null)
                InOrderTraversal(root.Right, results);
        }
    }
}
