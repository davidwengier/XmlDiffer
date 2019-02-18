using System;
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

            var leftLoader = new XmlLoader(left, null);
            var rightLoader = new XmlLoader(right, null);

            var comparer = new XmlComparer();
            comparer.Compare(leftLoader.RootElement, leftLoader.NodeMappings, rightLoader.RootElement, rightLoader.NodeMappings);
            
        }
    }
}
