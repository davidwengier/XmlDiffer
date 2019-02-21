using System;
using System.Drawing;
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
            string left = @"<Rule><String Name=""Bar"" /><String Name=""Foo"" /></Rule>";
            string right = left;

            var tvw1 = new TestTreeProvider();
            var tvw2 = new TestTreeProvider();
            using var leftReader = new StringReader(left);
            using var rightReader = new StringReader(right);
            var leftLoader = new XmlLoader(leftReader, tvw1);
            var rightLoader = new XmlLoader(rightReader, tvw2);

            var comparer = new XmlComparer();
            comparer.Compare(leftLoader.RootElement, leftLoader.NodeMappings, rightLoader.RootElement, rightLoader.NodeMappings);

            Assert.False(tvw1.HasDifferences);
            Assert.False(tvw2.HasDifferences);
            Assert.False(tvw1.Elements[0].HasDifference);
            Assert.False(tvw2.Elements[0].HasDifference);
            Assert.False(tvw1.Elements[1].HasDifference);
            Assert.False(tvw2.Elements[1].HasDifference);
            Assert.False(tvw1.Elements[2].HasDifference);
            Assert.False(tvw2.Elements[2].HasDifference);
            Assert.False(tvw1.Attributes[0].HasDifference);
            Assert.False(tvw1.Attributes[1].HasDifference);
        }

        [Fact]
        public void Test2()
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

            Assert.False(tvw1.HasDifferences);
            Assert.False(tvw2.HasDifferences);
            Assert.False(tvw1.Elements[0].HasDifference);
            Assert.False(tvw2.Elements[0].HasDifference);
            Assert.False(tvw1.Elements[1].HasDifference);
            Assert.False(tvw2.Elements[1].HasDifference);
            Assert.False(tvw1.Elements[2].HasDifference);
            Assert.False(tvw2.Elements[2].HasDifference);
            Assert.False(tvw1.Attributes[0].HasDifference);
            Assert.False(tvw1.Attributes[1].HasDifference);
        }

        [Fact]
        public void Test3()
        {
            string left = @"<Rule><String Name=""Bar"" /><String Name=""Foo"" /></Rule>";
            string right = @"<Rule><String Name=""Bar""><String Name=""Foo"" /></String></Rule>";

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
            Assert.False(tvw1.Elements[1].HasDifference);
            Assert.False(tvw2.Elements[1].HasDifference);
            // The 3rd node in each document is different because they're at different levels
            Assert.True(tvw1.Elements[2].HasDifference);
            Assert.Equal(Color.Green, tvw1.Elements[2].Color);
            Assert.True(tvw2.Elements[2].HasDifference);
            Assert.Equal(Color.Green, tvw2.Elements[2].Color);
            Assert.False(tvw1.Attributes[0].HasDifference);
            Assert.False(tvw1.Attributes[1].HasDifference);
        }

        [Fact]
        public void Test4()
        {
            string left = @"<Rule><String Name=""Bar"" /></Rule>";
            string right = @"<Rule><String Name=""Bar"" Count=""1"" /></Rule>";

            var tvw1 = new TestTreeProvider();
            var tvw2 = new TestTreeProvider();
            using var leftReader = new StringReader(left);
            using var rightReader = new StringReader(right);
            var leftLoader = new XmlLoader(leftReader, tvw1);
            var rightLoader = new XmlLoader(rightReader, tvw2);

            var comparer = new XmlComparer();
            comparer.Compare(leftLoader.RootElement, leftLoader.NodeMappings, rightLoader.RootElement, rightLoader.NodeMappings);

            Assert.Equal("<Rule>", tvw1.Elements[0].Text);
            Assert.Equal(Color.Empty, tvw1.Elements[0].Color);
            Assert.Equal("<Rule>", tvw2.Elements[0].Text);
            Assert.Equal(Color.Empty, tvw2.Elements[0].Color);

            Assert.Equal(@"<String Name=""Bar"">", tvw1.Elements[1].Text);
            Assert.Equal(Color.Empty, tvw1.Elements[1].Color);
            Assert.Equal(@"<String Name=""Bar"">", tvw2.Elements[1].Text);
            Assert.Equal(Color.Red, tvw2.Elements[1].Color);

            Assert.Equal(@"Name=""Bar""", tvw1.Attributes[0].Text);
            Assert.Equal(Color.Empty, tvw1.Attributes[0].Color);
            Assert.Equal(@"Name=""Bar""", tvw2.Attributes[0].Text);
            Assert.Equal(Color.Empty, tvw2.Attributes[0].Color);

            Assert.Equal(@"Count=""1""", tvw2.Attributes[1].Text);
            Assert.Equal(Color.Green, tvw2.Attributes[1].Color);
        }

        [Fact]
        public void Test5()
        {
            string left = @"<Rule><String Name=""Bar"" /></Rule>";
            string right = @"<Rule><Foo /><String Name=""Bar"" /></Rule>";

            var tvw1 = new TestTreeProvider();
            var tvw2 = new TestTreeProvider();
            using var leftReader = new StringReader(left);
            using var rightReader = new StringReader(right);
            var leftLoader = new XmlLoader(leftReader, tvw1);
            var rightLoader = new XmlLoader(rightReader, tvw2);

            var comparer = new XmlComparer();
            comparer.Compare(leftLoader.RootElement, leftLoader.NodeMappings, rightLoader.RootElement, rightLoader.NodeMappings);

            Assert.Equal("<Rule>", tvw1.Elements[0].Text);
            Assert.Equal(Color.Empty, tvw1.Elements[0].Color);
            Assert.Equal("<Rule>", tvw2.Elements[0].Text);
            Assert.Equal(Color.Empty, tvw2.Elements[0].Color);

            Assert.Equal(@"<String Name=""Bar"">", tvw1.Elements[1].Text);
            Assert.Equal(Color.Empty, tvw1.Elements[1].Color);
            Assert.Equal(@"<Foo>", tvw2.Elements[1].Text);
            Assert.Equal(Color.Green, tvw2.Elements[1].Color);
            Assert.Equal(@"<String Name=""Bar"">", tvw2.Elements[2].Text);
            Assert.Equal(Color.Empty, tvw2.Elements[2].Color);
        }


        [Fact]
        public void Test6()
        {
            string left = @"<Rule><Bar /></Rule>";
            string right = @"<Rule><Foo /></Rule>";

            var tvw1 = new TestTreeProvider();
            var tvw2 = new TestTreeProvider();
            using var leftReader = new StringReader(left);
            using var rightReader = new StringReader(right);
            var leftLoader = new XmlLoader(leftReader, tvw1);
            var rightLoader = new XmlLoader(rightReader, tvw2);

            var comparer = new XmlComparer();
            comparer.Compare(leftLoader.RootElement, leftLoader.NodeMappings, rightLoader.RootElement, rightLoader.NodeMappings);

            Assert.Equal("<Rule>", tvw1.Elements[0].Text);
            Assert.Equal(Color.Empty, tvw1.Elements[0].Color);
            Assert.Equal("<Rule>", tvw2.Elements[0].Text);
            Assert.Equal(Color.Empty, tvw2.Elements[0].Color);

            Assert.Equal(@"<Bar>", tvw1.Elements[1].Text);
            Assert.Equal(Color.Green, tvw1.Elements[1].Color);
            Assert.Equal(@"<Foo>", tvw2.Elements[1].Text);
            Assert.Equal(Color.Green, tvw2.Elements[1].Color);
        }

        [Fact]
        public void Test7()
        {
            string left = @"<Rule><Foo /><String Name=""Bar"" /></Rule>";
            string right = @"<Rule><String Name=""Bar"" /></Rule>";

            var tvw1 = new TestTreeProvider();
            var tvw2 = new TestTreeProvider();
            using var leftReader = new StringReader(left);
            using var rightReader = new StringReader(right);
            var leftLoader = new XmlLoader(leftReader, tvw1);
            var rightLoader = new XmlLoader(rightReader, tvw2);

            var comparer = new XmlComparer();
            comparer.Compare(leftLoader.RootElement, leftLoader.NodeMappings, rightLoader.RootElement, rightLoader.NodeMappings);

            Assert.Equal("<Rule>", tvw1.Elements[0].Text);
            Assert.Equal(Color.Empty, tvw1.Elements[0].Color);
            Assert.Equal("<Rule>", tvw2.Elements[0].Text);
            Assert.Equal(Color.Empty, tvw2.Elements[0].Color);

            Assert.Equal(@"<Foo>", tvw1.Elements[1].Text);
            Assert.Equal(Color.Green, tvw1.Elements[1].Color);
            Assert.Equal(@"<String Name=""Bar"">", tvw2.Elements[1].Text);
            Assert.Equal(Color.Empty, tvw2.Elements[1].Color);
            Assert.Equal(@"<String Name=""Bar"">", tvw1.Elements[2].Text);
            Assert.Equal(Color.Empty, tvw1.Elements[2].Color);
        }

        [Fact]
        public void Test8()
        {
            string left = @"<Rule><String Name=""Bar"" /></Rule>";
            string right = @"<Rule><String Count=""1"" /></Rule>";

            var tvw1 = new TestTreeProvider();
            var tvw2 = new TestTreeProvider();
            using var leftReader = new StringReader(left);
            using var rightReader = new StringReader(right);
            var leftLoader = new XmlLoader(leftReader, tvw1);
            var rightLoader = new XmlLoader(rightReader, tvw2);

            var comparer = new XmlComparer();
            comparer.Compare(leftLoader.RootElement, leftLoader.NodeMappings, rightLoader.RootElement, rightLoader.NodeMappings);

            Assert.Equal("<Rule>", tvw1.Elements[0].Text);
            Assert.Equal(Color.Empty, tvw1.Elements[0].Color);
            Assert.Equal("<Rule>", tvw2.Elements[0].Text);
            Assert.Equal(Color.Empty, tvw2.Elements[0].Color);

            Assert.Equal(@"<String Name=""Bar"">", tvw1.Elements[1].Text);
            Assert.Equal(Color.Green, tvw1.Elements[1].Color);
            Assert.Equal(@"<String>", tvw2.Elements[1].Text);
            Assert.Equal(Color.Green, tvw2.Elements[1].Color);

            Assert.Equal(@"Name=""Bar""", tvw1.Attributes[0].Text);
            Assert.Equal(Color.Empty, tvw1.Attributes[0].Color);
            Assert.Equal(@"Count=""1""", tvw2.Attributes[0].Text);
            Assert.Equal(Color.Empty, tvw2.Attributes[0].Color);
        }

          [Fact]
        public void Test9()
        {
            string left = @"<Rule><String><String.DataSource><DataSource ItemType=""Fish"" /></String.DataSource></String></Rule>";
            string right = @"<Rule><String><String.DataSource><DataSource ItemType=""Pants"" /></String.DataSource></String></Rule>";

            var tvw1 = new TestTreeProvider();
            var tvw2 = new TestTreeProvider();
            using var leftReader = new StringReader(left);
            using var rightReader = new StringReader(right);
            var leftLoader = new XmlLoader(leftReader, tvw1);
            var rightLoader = new XmlLoader(rightReader, tvw2);

            var comparer = new XmlComparer();
            comparer.Compare(leftLoader.RootElement, leftLoader.NodeMappings, rightLoader.RootElement, rightLoader.NodeMappings);

            Assert.Equal("<Rule>", tvw1.Elements[0].Text);
            Assert.Equal(Color.Empty, tvw1.Elements[0].Color);
            Assert.Equal("<Rule>", tvw2.Elements[0].Text);
            Assert.Equal(Color.Empty, tvw2.Elements[0].Color);

            Assert.Equal(@"<String Name=""Bar"">", tvw1.Elements[1].Text);
            Assert.Equal(Color.Green, tvw1.Elements[1].Color);
            Assert.Equal(@"<String>", tvw2.Elements[1].Text);
            Assert.Equal(Color.Green, tvw2.Elements[1].Color);

            Assert.Equal(@"Name=""Bar""", tvw1.Attributes[0].Text);
            Assert.Equal(Color.Empty, tvw1.Attributes[0].Color);
            Assert.Equal(@"Count=""1""", tvw2.Attributes[0].Text);
            Assert.Equal(Color.Empty, tvw2.Attributes[0].Color);
        }
    }
}
