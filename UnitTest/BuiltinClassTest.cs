using System;
using Xunit;
using Boronology.Gemini;

namespace UnitTest
{
    public class BuiltinClassTest
    {
        [Fact]
        public void StringCloneTest()
        {
            string str = "abcde";

            string cloned = str.DeepClone() as string;

            Assert.NotNull(cloned);
            //文字列は一致
            Assert.Equal(cloned, str);
            //参照は異なる
            Assert.NotSame(cloned, str);
        }
    }
}