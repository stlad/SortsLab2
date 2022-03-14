using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortsLab2
{
    public class BinaryTree
    {
        public BinaryTree Left { get; set; }
        public BinaryTree Right { get; set; }
        public char key { get; set; }
    }


    public class RedBlackTree
    {
        public enum RBColor { Red, Black }
        public RedBlackTree Left;
        public RedBlackTree Right;
        public RedBlackTree Parent;
        public RedBlackTree.RBColor Color;
        public char data;

        public RedBlackTree() {
            Left = null;
            Right = null; 
            Color = RBColor.Black;
        }

        /// <summary> Пораждает лист (sentinel, NIL) дерева </summary>
        public static RedBlackTree GetNIL()
        {
            var sent = new RedBlackTree();
            sent.Left = null;
            sent.Right = null;
            sent.Parent = null;
            sent.Color = RBColor.Black;
            return sent;

        }

        public bool IsSntinel() =>  Color == RBColor.Black && Left == null && Right == null;

        public static void RotateLeft(RedBlackTree x, RedBlackTree root)
        {
            var y = x.Right;

            x.Right = y.Left;
            if (!y.Left.IsSntinel())
                y.Left.Parent = x;

            if (!y.IsSntinel()) y.Parent = x.Parent;
            if (x.Parent != null)
            {
                if (x == x.Parent.Left)
                    x.Parent.Left = y;
                else
                    x.Parent.Right = y;
            }
            else root = y;

            y.Left = x;
            if (!x.IsSntinel()) x.Parent = y;
        }


        public static void RotateRight(RedBlackTree x, RedBlackTree root)
        {
            var y = x.Left;
            x.Left = y.Right;

            if (!y.Right.IsSntinel()) y.Right.Parent = x;

            if (!y.IsSntinel()) y.Parent = x.Parent;
            if (x.Parent != null)
            {
                if (x == x.Parent.Right)
                    x.Parent.Right = y;
                else
                    x.Parent.Left = y;
            }
            else root = y;

            y.Right = x;
            if (!x.IsSntinel()) x.Parent = y;
        }

        public static void InsertFixup(RedBlackTree x, RedBlackTree root)
        {
            while(x!=root && x.Parent.Color == RBColor.Red)
            {
                if(x.Parent == x.Parent.Parent.Left)
                {
                    var y = x.Parent.Parent.Right;
                    if (y.Color == RBColor.Red)
                    {
                        x.Parent.Color = RBColor.Black;
                        y.Color = RBColor.Black;
                        x.Parent.Parent.Color = RBColor.Red;
                        x = x.Parent.Parent;
                    }
                    else
                    {
                        if(x==x.Parent.Right)
                        {
                            x = x.Parent;
                            RotateLeft(x, root);
                        }

                        x.Parent.Color = RBColor.Black;
                        x.Parent.Parent.Color = RBColor.Red;
                        RotateRight(x.Parent.Parent, root);
                    }
                }
                else
                {
                    var y = x.Parent.Parent.Left;
                    if(y.Color == RBColor.Red)
                    {
                        x.Parent.Color = RBColor.Black;
                        y.Color = RBColor.Black;
                        x.Parent.Parent.Color = RBColor.Red;
                        x= x.Parent.Parent;
                    }
                    else
                    {
                        if(x==x.Parent.Left)
                        {
                            x = x.Parent;
                            RotateRight(x, root);
                        }
                        x.Parent.Color = RBColor.Black;
                        x.Parent.Parent.Color = RBColor.Red;
                        RotateLeft(x.Parent.Parent, root);
                    }
                }
            }
            root.Color = RBColor.Black;
        }


        public static RedBlackTree InsertNode(char data, RedBlackTree root)
        {
            var current = root;
            RedBlackTree parent = null;
            while(!current.IsSntinel())
            {
                if(data == current.data) return current;

                parent = current;
                current = (data < current.data) ? current.Left : current.Right;
            }
            var x = new RedBlackTree();
            x.data = data;
            x.Parent = parent;
            x.Left = GetNIL();
            x.Right = GetNIL();
            x.Color = RBColor.Red;

            if (parent != null)
            {
                if (data < parent.data)
                    parent.Left = x;
                else
                    parent.Right = x;
            }
            else root = x;


            return x;
        }

        public static RedBlackTree CreateTree(string str)
        {
            var tree= new RedBlackTree();
            for(int i = 0; i< str.Length;i++)
            {
                InsertNode(str[i], tree);
            }
            return tree;
        }

    }





}
