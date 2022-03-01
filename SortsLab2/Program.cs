using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/serialization/how-to-read-object-data-from-an-xml-file

namespace SortsLab2
{
    

    public class Program
    {

        
        public static void Main()
        {
            var exp = new Experiment("some string");
            var exp1 = new Experiment("new string 1");

            var exp2 = new Experiment("new string 123");

            var exp3 = new Experiment("new string545546");

            var lab = new Laboratory();
            lab.Experiments.Add(exp);
            lab.Experiments.Add(exp1);
            lab.Experiments.Add(exp2);
            lab.Experiments.Add(exp3);


            lab.Serialyze();
            var s = typeof(List<Experiment>);
        }


        
    }

    public class Book
    {
        public string Title { get; set; }
        public List<int> a = new List<int>();
    }
}
