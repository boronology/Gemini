using System;
using Xunit;
using Boronology.Gemini;

namespace UnitTest
{
    public class StructTest
    {

        struct FlatStruct
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

            Assert.NotSame(cloned, s);
            Assert.Equal(cloned.str, s.str);
            Assert.NotSame(cloned.str, s.str);
            Assert.Equal(cloned.l, s.l);
        }
    }
}