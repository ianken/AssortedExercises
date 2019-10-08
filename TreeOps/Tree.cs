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

        protected TreeNode BuildTree(int[] input, TreeNode root, int index = 0)
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

        public TreeNode BuildTree(int[] input)
        {
            return BuildTree(input, this.Root);
        }
        
        //public void BuildBinaryTree(int[] input,TreeNode root)
        public void BuildBinaryTree(int[] input)
        {
            TreeNode result = null;

            foreach(int i in input)
            {
                result = BinaryTreeInsert(result, i);
            }

            this.Root = result;
        }
               
        protected TreeNode BinaryTreeInsert(TreeNode node, int data)
        {
           if (node == null)
                return new TreeNode(data);
            else
            {
                if (data <= node.Data)
                    node.Left = BinaryTreeInsert(node.Left, data);
                else
                    node.Right = BinaryTreeInsert(node.Right, data);

               return node;
            }
        }

        public TreeNode GetLargestBstNode()
        {
            return GetLargestBstNode(this.Root);
        }

        protected TreeNode GetLargestBstNode(TreeNode root)
        {
            if (root.Right != null)
                return GetLargestBstNode(root.Right);
            else
                return root;
        }
        
        public int GetDepth()
        {
            return this.GetTreeDepth(this.Root);
        }

        protected  int GetTreeDepth(TreeNode root, int depth = 0)
        {
            
            if (root == null)  
            {
                return depth; 
            }
            else
            {  
                var leftHeight = GetTreeDepth(root.Left, depth + 1);  
                var rightHeight = GetTreeDepth(root.Right, depth +1);  
                    
                return Math.Max(leftHeight, rightHeight); 
            }  
        }

        public bool IsBinaryTree()
        {
            var treeData = this.InOrderTraversal();

            for (int i = 0; i < treeData.Length-1; i++)
            {
                if(treeData[i] >= treeData[i+1]) return false;
            }
    
            return true;

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
