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
        #region 二叉树的遍历
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
            PreOrderTraversalNoReCur(root, cb);
        }
        public void PreOrderTraversalNoReCur(BinaryTreeNode<T> node, Action<T> cb)
        {
            if (node == null) return;
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(node);
            while (stack.Count != 0)
            {
                node = stack.Pop();
                cb?.Invoke(node.value);
                if (node.right != null)
                {
                    stack.Push(node.right);
                }
                if (node.left != null)
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
            if (node == null) return;
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
            while (stack.Count != 0 || node != null) //第二个条件是最初进入的条件
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                else
                {
                    node = stack.Pop();
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
            while (stack2.Count != 0)
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
            if (node == null) return;
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(node);
            while (queue.Count != 0)
            {
                node = queue.Dequeue();
                cb?.Invoke(node.value);
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }
        #endregion
        #endregion
        #region 树型DP相关问题
        #region 判断一颗树是否是二叉搜索树
        public class IsBSTReturnStruct<T> where T : IComparable
        {
            public bool isBST;
            public T max;
            public T min;
            public IsBSTReturnStruct(bool isBST, T max, T min)
            {
                this.isBST = isBST;
                this.max = max;
                this.min = min;
            }


        }
        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(root).isBST;

        }
        public IsBSTReturnStruct<T> IsBinarySearchTree(BinaryTreeNode<T> node)
        {
            if (node == null) return null;
            IsBSTReturnStruct<T> left = IsBinarySearchTree(node.left);
            IsBSTReturnStruct<T> right = IsBinarySearchTree(node.right);
            //得到三者最值（左子树，右子树，当前节点）
            T min = node.value;
            T max = node.value;
            if (left != null)
            {
                min = min.CompareTo(left.min) < 0 ? min : left.min;
                max = max.CompareTo(left.max) < 0 ? max : left.max;
            }
            if (right != null)
            {
                min = min.CompareTo(right.min) < 0 ? min : right.min;
                max = max.CompareTo(right.max) < 0 ? max : right.max;
            }

            bool isBST = true;

            if (left != null && (!left.isBST || left.max.CompareTo(node.value) > 0))
            {
                isBST = false;
            }
            if (right != null && (!right.isBST || right.max.CompareTo(node.value) < 0))
            {
                isBST = false;
            }
            return new IsBSTReturnStruct<T>(isBST, max, min);

        }
        #endregion
        #region 判断一棵树是否是满二叉树
        public class IsFullTrueReturnStruct
        {
            public bool isFull;
            public int height;
            public int nodes;

            public IsFullTrueReturnStruct(bool isFull, int height, int nodes)
            {
                this.isFull = isFull;
                this.height = height;
                this.nodes = nodes;
            }
        }
        public bool IsFullTree()
        {
            return IsFullTree(root).isFull;
        }
        public IsFullTrueReturnStruct IsFullTree(BinaryTreeNode<T> node)
        {
            if (node == null) return new IsFullTrueReturnStruct(true,0,0);
            IsFullTrueReturnStruct left = IsFullTree(node.left);
            IsFullTrueReturnStruct right = IsFullTree(node.right);
            int height = left.height > right.height ? left.height+1 : right.height+1;
            int nodes = left.nodes + right.nodes + 1;
            bool isFull = nodes == Math.Pow(2,height)-1 ? true : false;
            
            return new IsFullTrueReturnStruct(isFull,height,nodes);
        }

        #endregion
        #region 判断一棵树是否是平衡二叉树
        public class IsBalanceTreeReturnStruct
        {
            public bool isBalance;
            public int height;
            

            public IsBalanceTreeReturnStruct(bool isBalance, int height)
            {
                this.isBalance = isBalance;
                this.height = height;
            }
        }
        public bool IsBalanceTree()
        {
            return IsBalanceTree(root).isBalance;
        }
        public IsBalanceTreeReturnStruct IsBalanceTree(BinaryTreeNode<T> node)
        {
            if (node == null) return new IsBalanceTreeReturnStruct(true,0);
            IsBalanceTreeReturnStruct left = IsBalanceTree(node.left);
            IsBalanceTreeReturnStruct right = IsBalanceTree(node.right);
            int height = left.height > right.height ? left.height+1 :right.height+1;
            bool isBalance = Math.Abs(left.height - right.height) <= 1 ? true : false;
            return new IsBalanceTreeReturnStruct(isBalance,height);
        }
        #endregion
        #endregion
    }

}
