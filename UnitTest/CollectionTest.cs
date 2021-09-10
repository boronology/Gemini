using System;
using Xunit;
using Boronology.Gemini;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UnitTest
{
    public class CollectionTest
    {
        [Fact]
        public void ListCloneTest()
        {
            var list = new List<string>
            {
                "list",
                "clone",
                null,
                "test",
            };

            var clone = list.DeepClone() as List<string>;

            Assert.Equal(clone, list);
            Assert.NotSame(clone, list);

            Assert.Equal(clone[0], list[0]);
            Assert.NotSame(clone[0], list[0]);

            Assert.Equal(clone[1], list[1]);
            Assert.NotSame(clone[1], list[1]);

            Assert.Null(clone[2]);

            Assert.Equal(clone[3], list[3]);
            Assert.NotSame(clone[3], list[3]);
        }

        [Fact]
        public void DictionaryCloneTest()
        {
            var dict = new Dictionary<string, int>
            {
                { "1st", 1245 },
                { "2nd", 4213121},
                { "3rd", -940 },
                { "4th", 0},
            };
            var clone = dict.DeepClone();
            Assert.Equal(clone, dict);
            Assert.NotSame(clone, dict);

        }

        [Fact]
        public void ObservableCollectionCloneTest()
        {
            var oc = new ObservableCollection<object>
            {
                "string",
                12,
                23.456,
                new Action(() => {}),
            };
            
            var clone = oc.DeepClone() as ObservableCollection<object>;

            Assert.Equal(clone, oc);
            Assert.NotSame(clone, oc);

            Assert.Equal(clone[0], oc[0]);
            Assert.NotSame(clone[0], oc[0]);

            Assert.Equal(clone[3], oc[3]);
            Assert.NotSame(clone[3], oc[3]);

        }
    }
}