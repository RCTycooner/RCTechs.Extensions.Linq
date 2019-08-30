using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace RCTechs.Extensions.Linq.Test
{
    [TestClass]
    public class MaxOrDefaultTests
    {
        [TestMethod]
        public void Test1()
        {
            List<int> list = new List<int>()
            {
                1,
                5,
                2,
                2,
            };

            Assert.AreEqual(5, list.MaxOrDefault());
        }
        [TestMethod]
        public void Test2()
        {
            List<int> list = new List<int>()
            {
                1,
                5,
                2,
                2,
            };

            Assert.AreEqual(5, list.MaxOrDefault(x => x));
        }

        [TestMethod]
        public void Test3()
        {
            List<Foo> list = new List<Foo>()
            {
                new Foo(1),
                new Foo(5),
                new Foo(2),
                new Foo(2),
            };

            Assert.AreEqual(5, list.MaxOrDefault(x => x.IntProp));
        }
    }
}
