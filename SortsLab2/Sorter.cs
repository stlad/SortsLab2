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
            return "bs";
        }

        public static string QSort(Experiment exp)
        {
            return "qs";
        }

        public static string SortTree(Experiment exp)
        {
            return "st";
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
