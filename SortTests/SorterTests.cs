using NUnit.Framework;
using SortsLab2;
using System.Linq;

namespace SortTests
{
    public class SortTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [TestCase("mama")]
        [TestCase("a")]
        [TestCase("ba")]
        [TestCase("asjdhsbddwdw")]
        public void BubbleTest(string str)
        {
            var exp = new Experiment(str);
            var res = Sorter.BubbleSort(exp);

            var trueRes = str.ToCharArray().OrderBy(n=>n);
            Assert.AreEqual(trueRes, res);
        }



        [TestCase("mama")]
        [TestCase("a")]
        [TestCase("ba")]
        [TestCase("asjdhsbddwdw")]
        public void QSortTest(string str)
        {
            var exp = new Experiment(str);
            var res = Sorter.QSort(exp);

            var trueRes = str.ToCharArray().OrderBy(n => n);
            Assert.AreEqual(trueRes, res);
        }

        [TestCase("mama")]
        [TestCase("a")]
        [TestCase("ba")]
        [TestCase("asjdhsbddwdw")]
        public void SortTreeTest(string str)
        {
            var exp = new Experiment(str);
            var res = Sorter.SortTree(exp);

            var trueRes = str.ToCharArray().OrderBy(n => n);
            Assert.AreEqual(trueRes, res);
        }

        [TestCase("mama")]
        [TestCase("a")]
        [TestCase("ba")]
        [TestCase("asjdhsbddwdw")]
        public void InsertTest(string str)
        {
            var exp = new Experiment(str);
            var res = Sorter.InsertSort(exp);

            var trueRes = str.ToCharArray().OrderBy(n => n);
            Assert.AreEqual(trueRes, res);
        }

        [TestCase("mama")]
        [TestCase("a")]
        [TestCase("ba")]
        [TestCase("asjdhsbddwdw")]
        public void MergeTest(string str)
        {
            var exp = new Experiment(str);
            var res = Sorter.MergeSort(exp);

            var trueRes = str.ToCharArray().OrderBy(n => n);
            Assert.AreEqual(trueRes, res);
        }


        [TestCase("mama")]
        [TestCase("a")]
        [TestCase("ba")]
        [TestCase("asjdhsbddwdw")]
        public void HeaptreeTest(string str)
        {
            var exp = new Experiment(str);
            var res = Sorter.HeapTreeSort(exp);

            var trueRes = str.ToCharArray().OrderBy(n => n);
            Assert.AreEqual(trueRes, res);
        }

        [TestCase("mama")]
        [TestCase("bdsedasdsdwddas")]
        [TestCase("a")]
        [TestCase("bbbbbbb")]
        [TestCase("ba")]
        [TestCase("asjdhsbddwdw")]
        public void RadixTest(string str)
        {
            var exp = new Experiment(str);
            var res = Sorter.RadixSort(exp);

            var trueRes = str.ToCharArray().OrderBy(n => n);
            Assert.AreEqual(trueRes, res);
        }
    }
}