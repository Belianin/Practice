using System;

namespace Practice.DataStructures
{
    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;
        
        public bool Contains(T element)
        {
            return root?.Contains(element) ?? false;
        }

        public void Add(T element)
        {
            if (root == null)
                root = new TreeNode<T>(element);
            else
                root.Add(element);
        }

        public void Remove(T element)
        {
            if (root == null)
                return;

            if (root.Value.Equals(element))
            {
                if (root.Right == null)
                    root = root.Left;
                else
                    root = new TreeNode<T>(root.Right.Value)
                    {
                        Left = root.Left,
                        Right = root.Right.Right
                    };
            }
            else
                root.Remove(element);
        }

        public int Count => root?.Count ?? 0;
    }

    internal class TreeNode<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        public T Value { get; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T value)
        {
            Value = value;
        }

        public bool Contains(T element)
        {
            if (Value.Equals(element))
                return true;
            if (Value.CompareTo(element) < 0)
            {
                if (Left == null)
                    return false;
                return Left.Contains(element);
            }
            
            if (Right == null)
                return false;
            return Right.Contains(element);
        }

        public void Add(T element)
        {
            if (Value.CompareTo(element) < 0)
            {
                if (Left == null)
                    Left = new TreeNode<T>(element);
                else
                    Left.Add(element);
            }
            else
            {
                if (Right == null)
                    Right = new TreeNode<T>(element);
                else
                    Right.Add(element);
            }
        }

        public void Remove(T element)
        {
            if (Value.CompareTo(element) < 0)
            {
                if (Left == null)
                    return;

                if (Left.Value.Equals(element))
                    Left = RemoveChild(Left);
                else
                    Left.Remove(element);
            }
            else
            {
                if (Right == null)
                    return;

                if (Right.Value.Equals(element))
                    Right = RemoveChild(Right);
                else
                    Right.Remove(element);
            }

            static TreeNode<T> RemoveChild(TreeNode<T> child)
            {
                if (child.Right == null)
                    return child.Left;

                return new TreeNode<T>(child.Right.Value)
                {
                    Left = child.Left,
                    Right = child.Right.Right
                };
            }
        }

        public int Count => 1 + (Left?.Count ?? 0) + (Right?.Count ?? 0);
    }
}