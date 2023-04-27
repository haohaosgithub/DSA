using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    public class BinaryTreeNode<T> where T : IComparable
    {
        public T value;
        public BinaryTreeNode<T> left;
        public BinaryTreeNode<T> right;

        public BinaryTreeNode(T value, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            this.value  = value;
            this.left = left;
            this.right = right;
        }
    }

    public class BinaryTree<T> where T : IComparable
    {
        public BinaryTreeNode<T> root;
        public BinaryTree(BinaryTreeNode<T> root)
        {
            this.root = root;
        }
        #region 遍历
        #region 先序遍历
        public void PreOrderTraversal(Action<T> cb)
        {
            PreOrderTraversal(root, cb);
        }
        public void PreOrderTraversal(BinaryTreeNode<T> node, Action<T> cb)
        {
            if (node == null) return;
            cb?.Invoke(node.value);
            PreOrderTraversal(node.left, cb);
            PreOrderTraversal(node.right, cb);
        }
        public void PreOrderTraversalNoReCur(Action<T> cb)
        {
            PreOrderTraversalNoReCur(root,cb);
        }
        public void PreOrderTraversalNoReCur(BinaryTreeNode<T> node, Action<T> cb)
        {
            if (node == null) return;
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(node);
            while(stack.Count != 0)
            {
                node = stack.Pop();
                cb?.Invoke(node.value);
                if(node.right != null)
                {
                    stack.Push(node.right);
                }
                if(node.left != null)
                {
                    stack.Push(node.left);
                }
            }

        }
        #endregion
        #region 中序遍历
        public void InOrderTraversal(Action<T> cb)
        {
            InOrderTraversal(root, cb);
        }
        public void InOrderTraversal(BinaryTreeNode<T> node, Action<T> cb)
        {
            if(node == null) return;
            InOrderTraversal(node.left, cb);
            cb?.Invoke(node.value);
            InOrderTraversal(node.right, cb);
        }
        public void InOrderTraversalNoReCur(Action<T> cb)
        {
            InOrderTraversalNoReCur(root, cb);
        }
        public void InOrderTraversalNoReCur(BinaryTreeNode<T> node, Action<T> cb)
        {
            if (node == null) return;
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            while (stack.Count != 0 ||node !=null) //第二个条件是最初进入的条件
            {
                if(node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                else
                {
                    node  = stack.Pop();
                    cb?.Invoke(node.value);
                    node = node.right;
                }
            }

        }
        #endregion
        #region 后序遍历
        public void PostOrderTraversal(Action<T> cb)
        {
            PostOrderTraversal(root, cb);
        }
        public void PostOrderTraversal(BinaryTreeNode<T> node, Action<T> cb)
        {
            if (node == null) return;
            PostOrderTraversal(node.left, cb);
            PostOrderTraversal(node.right, cb);
            cb?.Invoke(node.value);
        }
        public void PostOrderTraversalNoReCur(Action<T> cb)
        {
            PostOrderTraversalNoReCur(root, cb);
        }
        public void PostOrderTraversalNoReCur(BinaryTreeNode<T> node, Action<T> cb)
        {
            if (node == null) return;
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            Stack<BinaryTreeNode<T>> stack2 = new Stack<BinaryTreeNode<T>>();
            stack.Push(node);
            while (stack.Count != 0)
            {
                node = stack.Pop();
                stack2.Push(node);
                if (node.left != null)
                {
                    stack.Push(node.left);
                }
                if (node.right != null)
                {
                    stack.Push(node.right);
                }
            }
            while(stack2.Count != 0)
            {
                node = stack2.Pop();
                cb?.Invoke(node.value);
            }
        }
        #endregion
        #region 层序遍历
        public void LevelOrderTraversal(Action<T> cb)
        {
            LevelOrderTraversal(root, cb);
        }
        public void LevelOrderTraversal(BinaryTreeNode<T> node, Action<T> cb)
        {
            if(node == null) return;
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(node);
            while(queue.Count != 0) 
            {
                node = queue.Dequeue();
                cb?.Invoke(node.value);
                if(node.left != null) 
                {
                    queue.Enqueue(node.left);
                }
                if(node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }
        #endregion
        #endregion
    }

}
