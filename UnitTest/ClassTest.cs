using System;
using Xunit;
using Boronology.Gemini;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void ClassTest()
        {
            var uri = new Uri("https://example.com", UriKind.Absolute);
            var cloned = uri.DeepClone();

            Assert.Equal(cloned, uri);
            Assert.NotSame(cloned, uri);
        }
    }
}
