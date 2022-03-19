using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortsLab2
{
    public sealed class RedBlackTree<TKey, TValue>
    {
        private readonly RedBlackTreeNode<TKey> _leaf = RedBlackTreeNode<TKey>.CreateLeaf();

        public RedBlackTree()
        {
            Root = _leaf;
        }


        public char Get(TKey key)
        {
            try
            {
                int hashedKey = key.GetHashCode();
                RedBlackTreeNode<TKey> node = Root;
                do
                {
                    if (node.HashedKey == hashedKey)
                        return node.Value;
                    node = hashedKey < node.HashedKey ? node.Left : node.Right;
                } while (true);
            }
            catch (NullReferenceException)
            {
                throw new KeyNotFoundException();
            }
        }

        internal RedBlackTreeNode<TKey> Root { get; private set; }

        public void Add(TKey key, char value, Experiment exp )
        {
            RedBlackTreeNode<TKey> newNode = RedBlackTreeNode<TKey>.CreateNode(key, value, RedBlackTreeNode<TKey>.ColorEnum.Red, key.GetHashCode());
            Insert(newNode, exp);
        }

        private void Insert(RedBlackTreeNode<TKey> z, Experiment exp)
        {
            exp.SortIterations[(int)Sorter.SortType.RedBlackTree]++;
            var y = _leaf;
            var x = Root;
            while (x != _leaf)
            {
                y = x;
                x = z.Value < x.Value ? x.Left : x.Right;
            }

            z.Parent = y;
            if (y == _leaf)
            {
                Root = z;
            }
            else if (z.Value < y.Value)
            {
                y.Left = z;
            }
            else
            {
                y.Right = z;
            }

            z.Left = _leaf;
            z.Right = _leaf;
            z.Color = RedBlackTreeNode<TKey>.ColorEnum.Red;
            InsertFixup(z, exp);
        }

        private void InsertFixup(RedBlackTreeNode<TKey> z, Experiment exp)
        {
            while (z.Parent.Color == RedBlackTreeNode<TKey>.ColorEnum.Red)
            {
                if (z.Parent == z.Parent.Parent.Left)
                {
                    var y = z.Parent.Parent.Right;
                    if (y.Color == RedBlackTreeNode<TKey>.ColorEnum.Red)
                    {
                        z.Parent.Color = RedBlackTreeNode<TKey>.ColorEnum.Black;
                        y.Color = RedBlackTreeNode<TKey>.ColorEnum.Black;
                        z.Parent.Parent.Color = RedBlackTreeNode<TKey>.ColorEnum.Red;
                        z = z.Parent.Parent;
                    }
                    else
                    {
                        if (z == z.Parent.Right)
                        {
                            z = z.Parent;
                            exp.SortIterations[(int)Sorter.SortType.RedBlackTree]++;
                            RotateLeft(z);
                        }

                        z.Parent.Color = RedBlackTreeNode<TKey>.ColorEnum.Black;
                        z.Parent.Parent.Color = RedBlackTreeNode<TKey>.ColorEnum.Red;
                        exp.SortIterations[(int)Sorter.SortType.RedBlackTree]++;
                        RotateRight(z.Parent.Parent);
                    }
                }
                else
                {
                    var y = z.Parent.Parent.Left;
                    if (y.Color == RedBlackTreeNode<TKey>.ColorEnum.Red)
                    {
                        z.Parent.Color = RedBlackTreeNode<TKey>.ColorEnum.Black;
                        y.Color = RedBlackTreeNode<TKey>.ColorEnum.Black;
                        z.Parent.Parent.Color = RedBlackTreeNode<TKey>.ColorEnum.Red;
                        z = z.Parent.Parent;
                    }
                    else
                    {
                        if (z == z.Parent.Left)
                        {
                            z = z.Parent;
                            exp.SortIterations[(int)Sorter.SortType.RedBlackTree]++;
                            RotateRight(z);
                        }

                        z.Parent.Color = RedBlackTreeNode<TKey>.ColorEnum.Black;
                        z.Parent.Parent.Color = RedBlackTreeNode<TKey>.ColorEnum.Red;
                        exp.SortIterations[(int)Sorter.SortType.RedBlackTree]++;
                        RotateLeft(z.Parent.Parent);
                    }
                }
            }

            Root.Color = RedBlackTreeNode<TKey>.ColorEnum.Black;
        }

        private void RotateLeft(RedBlackTreeNode<TKey> x)
        {
            var y = x.Right;
            x.Right = y.Left;
            if (y.Left != _leaf)
            {
                y.Left.Parent = x;
            }

            y.Parent = x.Parent;
            if (x.Parent == _leaf)
            {
                Root = y;
            }
            else if (x == x.Parent.Left)
            {
                x.Parent.Left = y;
            }
            else
            {
                x.Parent.Right = y;
            }

            y.Left = x;
            x.Parent = y;
        }

        private void RotateRight(RedBlackTreeNode<TKey> x)
        {
            var y = x.Left;
            x.Left = y.Right;
            if (y.Right != _leaf)
            {
                y.Right.Parent = x;
            }
            y.Parent = x.Parent;
            if (x.Parent == _leaf)
            {
                Root = y;
            }
            else if (x == x.Parent.Left)
            {
                x.Parent.Left = y;
            }
            else
            {
                x.Parent.Right = y;
            }

            y.Right = x;
            x.Parent = y;
        }
    }
}
