using System;
using Xunit;
using Boronology.Gemini;
using System.Collections.Generic;

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


        class Comparable1
        {
            public int IntMember;
            public string StringMember;

            public Comparable2<List<string>> ComparableMember;

            public bool Compare(Comparable1 target)
            {
                Assert.Equal(this.IntMember, target.IntMember);
                Assert.Equal(this.StringMember, target.StringMember);
                Assert.NotSame(this.StringMember, target.StringMember);
                Assert.NotSame(this.ComparableMember, target.ComparableMember);
                this.ComparableMember.Compare(target.ComparableMember);
                return true;
            }


        }

        class Comparable2<TValue>
        {
            public TValue ValueMember;
            public Uri UriMember;
            public bool Compare(Comparable2<TValue> target)
            {
                Assert.Equal(UriMember, target.UriMember);
                Assert.NotSame(UriMember, target.UriMember);

                Assert.Equal(ValueMember, target.ValueMember);
                Assert.NotSame(ValueMember, target.ValueMember);
                return true;
            }
        }

        [Fact]
        public void ClassCloneTest2()
        {
            var c1 = new Comparable1
            {
                IntMember = 124325,
                StringMember = "qwerty",
                ComparableMember = new Comparable2<List<string>>
                {
                    UriMember = new Uri("https://example.com"),
                    ValueMember = new List<string>
                    {
                        "abc", "def", "ghi",
                    },
                },
            };
            var clone = c1.DeepClone() as Comparable1;
            Assert.True(c1.Compare(clone));
        }
    }
}
