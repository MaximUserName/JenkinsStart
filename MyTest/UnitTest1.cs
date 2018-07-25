using System;
using System.Collections.Generic;
using myapi.Controllers;
using Xunit;

namespace MyTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var controller = new ValuesController();
            Assert.IsAssignableFrom<IEnumerable<string>>(controller.Get());
        }
    }
}
