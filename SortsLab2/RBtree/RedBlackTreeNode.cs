using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortsLab2
{
    internal sealed class RedBlackTreeNode<TKey>
    {
        public enum ColorEnum
        {
            Red,
            Black
        };

        public readonly char Value;

        public readonly TKey Key;

        public readonly bool IsLeaf;

        public readonly int HashedKey;

        public ColorEnum Color;

        public RedBlackTreeNode<TKey> Parent;

        public RedBlackTreeNode<TKey> Left;

        public RedBlackTreeNode<TKey> Right;

        public static RedBlackTreeNode<TKey> CreateLeaf()
        {
            return new RedBlackTreeNode<TKey>();
        }

        public static RedBlackTreeNode<TKey> CreateNode(TKey key, char value, ColorEnum color, int hashedKey)
        {
            return new RedBlackTreeNode<TKey>(key, value, color, hashedKey);
        }

        internal RedBlackTreeNode(TKey key,char value, ColorEnum color, int hashedKey)
        {
            Value = value;
            HashedKey = hashedKey;
            Color = color;
            Key = key;
        }

        internal RedBlackTreeNode()
        {
            IsLeaf = true;
            Color = ColorEnum.Black;
            HashedKey = 0;
        }

        public RedBlackTreeNode<TKey> Grandparent => Parent?.Parent;

        public RedBlackTreeNode<TKey> Sibling =>
            Parent == null ? null : Parent.Left == this ? Parent.Right : Parent.Left;

        public RedBlackTreeNode<TKey> Uncle => Parent?.Sibling;
    }
}
