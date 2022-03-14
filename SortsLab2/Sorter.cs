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
            Insert, //вставками
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
            Sorts[SortType.Insert] = InsertSort;
            Sorts[SortType.MergeSort] = MergeSort;
            Sorts[SortType.HeapTree] = HeapTreeSort;
            Sorts[SortType.Radix] = RadixSort;
            Sorts[SortType.RedBlackTree] = RedBlackSort;
        }
        //*----------------ПУЗЫРЕК----------------------------------------
        public static string BubbleSort(Experiment exp)
        {
            var str = new StringBuilder(exp.Text);
            var wasSwaps = true;
            for(int i = 0; i< str.Length; i++)
            {
                wasSwaps = false;
                for(int j = 0; j<str.Length - i-1 ;j++)
                {
                    exp.SortIterations[(int)SortType.Bubble]++;          //учет итерации
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

        //*--------------------БЫСТАРЯ СОРТИРОВКА------------------------------------
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
                exp.SortIterations[(int)SortType.QSort]++;           //учет итерации
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

        //*--------------------БИНАРНОЕ ДЕРЕВО----------------------------------
        public static string SortTree(Experiment exp)
        {
            BinaryTree root = null;
            var str = exp.Text;
            for(int i = 0; i < str.Length; i++)
            {
                exp.SortIterations[(int)SortType.SortTree]++;
                root = AddNode(exp, root, str[i]);
            }
            var res = new StringBuilder();
            GetTree(exp, root, res);
            return res.ToString();
        }

        private static BinaryTree AddNode(Experiment exp, BinaryTree tree, char val)
        {
            exp.SortIterations[(int)SortType.SortTree]++;
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

            exp.SortIterations[(int)SortType.SortTree]++;

            GetTree(exp, tree.Left, res);
            res.Append(tree.key);
            GetTree(exp, tree.Right, res);

        }

        //*--------------------ВСТАВКАМИ------------------------------------
        public static string InsertSort(Experiment exp)
        {
            var str = new StringBuilder(exp.Text);

            for(int i = 1; i< str.Length; i++)
            {
                for(int j = i; j>0 && str[j-1] > str[j]; j--)
                {
                    exp.SortIterations[(int)Sorter.SortType.Insert]++;
                    (str[j-1], str[j]) = (str[j],str[j-1]);
                }
            }
            return str.ToString();
        }

        //*--------------------СЛИЯНИЕМ------------------------------------
        public static string MergeSort(Experiment exp)
        {
            var str = new StringBuilder(exp.Text);
            RecursionMerge(exp, str, 0, str.Length - 1);
            return str.ToString();
        }

        private static void RecursionMerge(Experiment exp, StringBuilder str, int leftIndex, int rightIndex)
        {
            if (leftIndex + 1 >= rightIndex) return;

            var middleI = (leftIndex + rightIndex) / 2;
            RecursionMerge(exp, str, leftIndex, middleI);
            RecursionMerge(exp, str, middleI, rightIndex);
            Merge(exp, str, leftIndex, middleI, rightIndex);
        }
        
        private static void Merge(Experiment exp, StringBuilder str, int left, int middle, int right)
        {
            var it1 = 0;
            var it2 = 0; 
            var buffer = new StringBuilder(exp.Text);

            while((left+it1 < middle) &&( middle + it2 < right))
            {
                exp.SortIterations[(int)SortType.MergeSort]++;
                if (str[left + it1] < str[middle + it2])
                {
                    buffer[it1 + it2] = str[left + it1];
                    it1++;
                }
                else
                {
                    buffer[it1 + it2] = str[middle + it2];
                    it2++;
                }

            }


            while(left+it1< middle)
            {
                buffer[it1 + it2] = str[left + it1];
                it1++;
            }

            while(middle+it2<right)
            {
                buffer[it1 + it2] = str[middle + it2];
                it2++;
            }

            for(int i = 0; i< it1+it2; i++)
            {
                str[left + i] = buffer[i];
            }
        }
        //https://neerc.ifmo.ru/wiki/index.php?title=%D0%A1%D0%BE%D1%80%D1%82%D0%B8%D1%80%D0%BE%D0%B2%D0%BA%D0%B0_%D1%81%D0%BB%D0%B8%D1%8F%D0%BD%D0%B8%D0%B5%D0%BC


        //*-------------------ПИРАМИДАЛЬНАЯ (КУЧЕЙ)-------------------------------------
        public static string HeapTreeSort(Experiment exp)
        {
            //элементы дерева a[i] a[2i+1] a[2i+2]
            var str = new StringBuilder(exp.Text);
            heapSort(exp, str, str.Length);
            return str.ToString();
        }

        private static void heapify(Experiment exp, StringBuilder str, int heapSize, int i)
        {
            exp.SortIterations[(int)Sorter.SortType.HeapTree]++;

            var largest = i;
            var left = 2 * i + 1;
            var right = 2 * i + 2;

            if(heapSize > left && str[left] > str[largest])
                largest = left;
            if (heapSize > right && str[right] > str[largest])
                largest = right;

            if (largest != i)
            {
                (str[i], str[largest]) = (str[largest], str[i]);
            }
            else return;
            heapify(exp, str, heapSize, largest);
        }

        private static void heapSort(Experiment exp, StringBuilder str, int n)
        {
            for(int i = n/2 -1; i>=0; i--)
                heapify(exp, str, n, i);

            for (int i = n - 1; i >= 0; i--)
            {
               (str[0], str[i]) = (str[i], str[0]);
                heapify(exp, str, i, 0);
            }
        }

        //*----------------------ПОРАЗРЯДНАЯ СОРТИРОВКА----------------------------------
        public static string RadixSort(Experiment exp)
        {
            var startArr = new List<int>[10];
            var targetArr = new List<int>[10];

            for (int i = 0; i < exp.Text.Length; i++)
            {
                var digit = ((int)exp.Text[i]) % 10;
                if(startArr[digit] == null ) startArr[digit] = new List<int>();
                startArr[digit].Add((int)exp.Text[i]);
            }
            var digitRank = 1;
            var isEnd = false;
            while(true)
            {
                for (int i =0; i< startArr.Length; i++)
                {
                    for(int j =0; startArr[i]!=null && j<startArr[i].Count; j++)
                    {
                        exp.SortIterations[(int)Sorter.SortType.Radix]++;

                        var digit = (startArr[i][j] / (int)Math.Pow(10, digitRank)) % 10;
                        if(targetArr[digit] == null ) targetArr[digit] = new List<int>();
                        targetArr[digit].Add(startArr[i][j]);

                        if(j==exp.Length-1) isEnd = true;
                    }
                }
                digitRank++;
                startArr = targetArr;
                

                if (isEnd) break;
                targetArr = new List<int>[10];
            }

            var str = new StringBuilder();
            foreach (var c in startArr[0])
                str.Append((char)c);

            return str.ToString(); ;
        }

        //*--------------------------------------------------------
        public static string RedBlackSort(Experiment exp)
        {
            return "Not Implemented yet";
        }
    }
}
