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

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Что делаем?");
                Console.WriteLine("[1] Лаборатория + xml выгрузка \n[2] Просто сортировка строки \n \n\n\n\n[x] Выход");
                var c = Console.ReadLine();
                if (c[0] == 'x') break;
                switch (c[0])
                {
                    case '1':
                        Console.Clear();
                        LaboratoryModule();
                        Console.Clear();
                        break;
                    case '2':
                        Console.Clear();
                        FreeModeModule();
                        Console.Clear();
                        break;
                    case 'i':
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("НЕВЕРНАЯ КОММАНДА!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }

        }

        public static void LaboratoryModule()
        {
            Console.WriteLine("Введите название файла со строками: ");
            var fileName = Console.ReadLine();

            var file = System.IO.File.ReadLines(fileName).ToList();
            var lab = new Laboratory(file);

            lab.MakeAllExperiments();

            Console.WriteLine("Готово!");
            Console.WriteLine("\n\n\nВведите название файла для записи результата (.xml)");
            var resFileName = Console.ReadLine();
            lab.Serialyze(resFileName);
            Console.WriteLine("\n\n\n------Нажмите любую кнопку для выхода------");
            Console.ReadKey();
        }


        public static void FreeModeModule()
        {
            Console.WriteLine("Введите столку для сортировки");
            var str = Console.ReadLine();
            Console.Clear();
            var exp = new Experiment(str);

            exp.MakeAllSorts();
            Console.WriteLine("\n\n\n------Нажмите любую кнопку для выхода------");
            Console.ReadKey();
        }

    }
}
