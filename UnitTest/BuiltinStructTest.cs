using System;
using Xunit;
using Boronology.Gemini;

namespace UnitTest
{
    public class BuiltinStructTest
    {
        
        [Fact]
        public void IntCloneTest()
        {
            int i = 42;
            object cloned = i.DeepClone();

            Assert.Equal(cloned, i);
        }

        [Fact]
        public void DecimalCloneTest()
        {
            decimal d = 27M;
            object cloned = d.DeepClone();
            Assert.Equal(d, cloned);
        }

        [Fact]
        public void NullableCloneTest()
        {
            Nullable<double> nd1 = null;
            object cloned1 = nd1.DeepClone();
            Assert.Equal(nd1, cloned1);

            Nullable<double> nd2 = 34.567;
            object cloned2 = nd2.DeepClone();
            Assert.Equal(nd2, cloned2);


        }
    }
}