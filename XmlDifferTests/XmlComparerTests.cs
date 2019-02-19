using System;
using System.IO;
using System.Text.RegularExpressions;
using XmlDiffer;
using Xunit;

namespace XmlDifferTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string left = @"<Rule><String Name=""Foo"" /><String Name=""Bar"" /></Rule>";
            string right = @"<Rule><String Name=""Bar"" /><String Name=""Foo"" /></Rule>";

            var tvw1 = new TestTreeProvider();
            var tvw2 = new TestTreeProvider();
            using var leftReader = new StringReader(left);
            using var rightReader = new StringReader(right);
            var leftLoader = new XmlLoader(leftReader, tvw1);
            var rightLoader = new XmlLoader(rightReader, tvw2);

            var comparer = new XmlComparer();
            comparer.Compare(leftLoader.RootElement, leftLoader.NodeMappings, rightLoader.RootElement, rightLoader.NodeMappings);

            Assert.True(tvw1.HasDifferences);
            Assert.True(tvw2.HasDifferences);
            Assert.False(tvw1.Elements[0].HasDifference);
            Assert.False(tvw2.Elements[0].HasDifference);
            Assert.True(tvw1.Elements[1].HasDifference);
            Assert.True(tvw2.Elements[1].HasDifference);
            Assert.True(tvw1.Elements[2].HasDifference);
            Assert.True(tvw2.Elements[2].HasDifference);
        }
    }
}
