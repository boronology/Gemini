using System;
using Xunit;
using Boronology.Gemini;

namespace UnitTest
{
    public class ClassTest
    {
        [Fact]
        public void ClassCloneTest()
        {
            var uri = new Uri("https://example.com", UriKind.Absolute);
            var cloned = uri.DeepClone();

            Assert.Equal(cloned, uri);
            Assert.NotSame(cloned, uri);
        }
    }
}
