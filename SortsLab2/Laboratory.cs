using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortsLab2
{
    /// <summary>
    /// Класс содержит коллекию экспериментов, по которой строится сравнительная таблица.
    /// Отсюда происходит xml-сериализация всех експериментов.
    /// </summary>
    public class Laboratory
    {
        public List<Experiment> Experiments = new List<Experiment>();

        public Laboratory(List<string> exps)
        {
            foreach(var str in exps)
                Experiments.Add(new Experiment(str));
        }

        public void MakeAllExperiments()
        {
            foreach(var exp in Experiments)
            {
                exp.MakeAllSortsQuiet();
            }
        }

        public void Serialyze(string fileName)
        {
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Experiment>));
            System.IO.StreamWriter file = new System.IO.StreamWriter(fileName);
            writer.Serialize(file, Experiments);
        }

        //private static void Xmltry()
        //{
        //    var b = new Book();
        //    b.Title = "Lord of the rings";
        //    b.a.Add(1);
        //    b.a.Add(6);
        //    b.a.Add(5);
        //    b.a.Add(2);
        //    var writer = new System.Xml.Serialization.XmlSerializer(typeof(Book));
        //    System.IO.StreamWriter sw = new System.IO.StreamWriter("books.xml");

        //    writer.Serialize(sw, b);
        //    sw.Close();

        //    //var reader = new System.Xml.Serialization.XmlSerializer(typeof(Book));
        //    //var file = new System.IO.StreamReader("books.xml");
        //    //Book book = (Book)reader.Deserialize(file);
        //    //file.Close();
        //}
    }
}
