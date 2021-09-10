using System;
using Xunit;

namespace UnitTest
{
    public class BuiltinClassTest
    {
        [Fact]
        public void TestName()
        {
            int i = 2;
            Assert.Equal(2, i);
        }
    }
}