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

        public int Iterations;
        //public Dictionary<Sorter.SortType, int > SortResults { get; set; }

        public Experiment() { }
        public Experiment(string text)
        {
            Iterations = 0;
            Text = text;
            //SortResults = new Dictionary<Sorter.SortType, int>();
            //SortResults[Sorter.SortType.Bubble] = 0;
            //SortResults[Sorter.SortType.QSort] = 0;
            //SortResults[Sorter.SortType.SortTree] = 0;
            //SortResults[Sorter.SortType.Instert] = 0;
            //SortResults[Sorter.SortType.MergeSort] = 0;
            //SortResults[Sorter.SortType.HeapTree] = 0;
            //SortResults[Sorter.SortType.Radix] = 0;
            //SortResults[Sorter.SortType.RedBlackTree] = 0;
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
