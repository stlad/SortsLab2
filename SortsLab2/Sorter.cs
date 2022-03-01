using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortsLab2
{
    /// <summary>
    /// Класс содержит все сортировки
    /// </summary>
    public static class Sorter
    {
        public enum SortType
        {
            Bubble,
            QSort,
            SortTree,
            Instert, //вставками
            MergeSort,
            HeapTree,
            Radix,
            RedBlackTree
        }

        public static Dictionary<SortType, Func<Experiment, string>> Sorts { get; set; }

        static Sorter()
        {
            Sorts = new Dictionary<SortType, Func<Experiment, string>>();
            Sorts[SortType.Bubble] = BubbleSort;
            Sorts[SortType.QSort] = QSort;
            Sorts[SortType.SortTree] = SortTree;
            Sorts[SortType.Instert] = InsertSort;
            Sorts[SortType.MergeSort] = MergeSort;
            Sorts[SortType.HeapTree] = HeapTreeSort;
            Sorts[SortType.Radix] = RadixSort;
            Sorts[SortType.RedBlackTree] = RedBlackSort;
        }

        public static string BubbleSort(Experiment exp)
        {
            var str = new StringBuilder(exp.Text);
            var wasSwaps = true;
            for(int i = 0; i< str.Length; i++)
            {
                wasSwaps = false;
                for(int j = 0; j<str.Length - i-1 ;j++)
                {
                    exp.SortIterations[SortType.Bubble]++;          //учет итерации
                    if(str[j] > str[j+1])
                    {
                        (str[j], str[j + 1]) = (str[j + 1], str[j]);
                        wasSwaps = true;
                    }

                }
                if (!wasSwaps) break;
            }

            return str.ToString();
        }

        public static string QSort(Experiment exp)
        {
            var str = new StringBuilder(exp.Text);
            RecursionQSort(exp, str, 0, str.Length - 1);
            return str.ToString();
        }

        private static void RecursionQSort(Experiment exp, StringBuilder str, int start, int end)
        {
            if (end == start) return;

            var pivot = str[end];
            var storeIndex = start;


            for(int i = start; i<end; i++)
            {
                exp.SortIterations[SortType.QSort]++;           //учет итерации
                if(str[i] <= pivot)
                {
                    (str[i], str[storeIndex]) = (str[storeIndex], str[i]);
                    storeIndex++;
                }
            }

            (str[storeIndex], str[end]) = (str[end], str[storeIndex]);

            if (storeIndex > start) RecursionQSort(exp, str, start, storeIndex - 1);
            if (storeIndex < end) RecursionQSort(exp, str, storeIndex+1,end );
        }
       
        public static string SortTree(Experiment exp)
        {
            BinaryTree root = null;
            var str = exp.Text;
            for(int i = 0; i < str.Length; i++)
            {
                exp.SortIterations[SortType.SortTree]++;
                root = AddNode(exp, root, str[i]);
            }
            var res = new StringBuilder();
            GetTree(exp, root, res);
            return res.ToString();
        }

        private static BinaryTree AddNode(Experiment exp, BinaryTree tree, char val)
        {
            exp.SortIterations[SortType.SortTree]++;
            if (tree == null)
            {
                tree = new BinaryTree();
                tree.key = val;
                tree.Right = null;
                tree.Left = null;
            }
            else
            {
                if (val < tree.key)
                    tree.Left = AddNode(exp, tree.Left, val);
                else
                    tree.Right = AddNode(exp, tree.Right, val);

            }
            return tree;
        }

        private static void GetTree(Experiment exp, BinaryTree tree, StringBuilder res)
        {

            if (tree == null) return;

            exp.SortIterations[SortType.SortTree]++;

            GetTree(exp, tree.Left, res);
            res.Append(tree.key);
            GetTree(exp, tree.Right, res);

        }

        public static string InsertSort(Experiment exp)
        {
            return "is";
        }

        public static string MergeSort(Experiment exp)
        {
            return "ms";
        }

        public static string HeapTreeSort(Experiment exp)
        {
            return "hts";
        }

        public static string RadixSort(Experiment exp)
        {
            return "rs";
        }

        public static string RedBlackSort(Experiment exp)
        {
            return "rbs";
        }
    }
}
