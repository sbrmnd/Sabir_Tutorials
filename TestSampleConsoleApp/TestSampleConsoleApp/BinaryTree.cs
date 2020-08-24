using System.Collections;
using System;


namespace TestSampleConsoleApp
{
    public class Node
    {
        public Node left, right;
        public int data;
        public Node(int data)
        {
            this.data = data;
            left = right = null;
        }
    }
    public class BinaryTree
    {
        //Level-Order Traversal (BFS)  breadth-first-search
        public void levelOrder(Node root)
        {
            if(root == null)
            {
                return;
            }

            Queue queue = new Queue();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                //Remove the present head.
                Node tempnode = (Node)queue.Dequeue();
                Console.Write(tempnode.data + " ");

                if (tempnode.left != null)
                {
                    queue.Enqueue(tempnode.left);
                }
                if(tempnode.right != null)
                {
                    queue.Enqueue(tempnode.right);
                }
            }
        }
        public Node Insert(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data <= root.data)
                {
                    cur = Insert(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = Insert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }

    }
}
