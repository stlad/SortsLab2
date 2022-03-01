using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortsLab2
{
    /// <summary>
    /// Класс експеримента
    /// Содержит одну строку. И результаты ее сортировок разными алгоритмами
    /// </summary>
    public class Experiment
    {
        public string Text { get; set; }
        public int Length => Text.Length;

        //public Dictionary<Sorter.SortType, int > SortIterations { get; set; }

        public int[] SortIterations { get; set; }
        public Experiment() { }
        public Experiment(string text)
        {
            Text = text;
            SortIterations = new int[8];

            SortIterations[(int)Sorter.SortType.Bubble] = 0;
            SortIterations[(int)Sorter.SortType.QSort] = 0;
            SortIterations[(int)Sorter.SortType.SortTree] = 0;
            SortIterations[(int)Sorter.SortType.Instert] = 0;
            SortIterations[(int)Sorter.SortType.MergeSort] = 0;
            SortIterations[(int)Sorter.SortType.HeapTree] = 0;
            SortIterations[(int)Sorter.SortType.Radix] = 0;
            SortIterations[(int)Sorter.SortType.RedBlackTree] = 0;
        }


        public void MakeSort(Sorter.SortType sortType)
        {
            var res =Sorter.Sorts[sortType](this);
            Console.WriteLine(res);
        }

        /// <summary>
        /// Проводит все сортировки сразу
        /// </summary>
        public void MakeAllSorts()
        {
            foreach(var sort in Sorter.Sorts.Values)
            {
                var st = sort(this);
                Console.WriteLine(st);
            }
        }

    }
}
