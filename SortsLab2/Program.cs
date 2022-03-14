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
            //var exp = new Experiment("assjdowkdasldpaeldjeifasdasdasdkkimdiojsidkspobmog,bokbtikovbmtitogtigjtriv");
            
            Console.WriteLine("Введите название файла со строками: ");
            var fileName = Console.ReadLine();

            var file = System.IO.File.ReadLines(fileName).ToList();
            var lab = new Laboratory(file);

            lab.MakeAllExperiments();
            lab.Serialyze("result.xml");
            Console.WriteLine("Готово!");
            Console.ReadKey();
        }



    }
}
