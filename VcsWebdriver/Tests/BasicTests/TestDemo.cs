using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace VcsWebdriver
{
    public class TestsDemo
    {
        [Test]
        public static void TestExample()
        {
            //1.preconditions
            //2.steps
            //3.result check
            Assert.AreEqual(2, 2, "2 !=2");

        }

        [Test]
        public static void Dalinasi995is3()
        {
            double liekana = 995 % 3;
            Assert.Zero(liekana,"995 nesidalina is 3");
        }
        [Test]
        public static void DabarPirmadienis()
        {
            DateTime dabar = DateTime.Now;
            Assert.AreEqual(DayOfWeek.Monday, dabar.DayOfWeek, "dabar ne pirmadienis");
        }
        [Test]
        public static void Emptytest()
        {
            Thread.Sleep(5000);
            Assert.Pass();
        }
    }
}
