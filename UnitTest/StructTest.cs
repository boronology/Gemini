using System;
using Xunit;
using Boronology.Gemini;

namespace UnitTest
{
    public class StructTest
    {

        class FlatStruct
        {
            public string str;
            public long l;
        }

        [Fact]
        public void FlatStructCloneTest()
        {
            var s = new FlatStruct
            {
                str = "FlatStruct",
                l = 123L,
            };

            var cloned = (FlatStruct)s.DeepClone();

            Assert.Equal(cloned, s);
            Assert.NotSame(cloned, s);
            Assert.NotSame(cloned.str, s.str);
        }
    }
}