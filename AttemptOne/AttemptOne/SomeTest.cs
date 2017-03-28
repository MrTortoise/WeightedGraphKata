using System;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace AttemptOne
{
    public class SomeTest
    {
        public const string InputString = "a(0.8)b,a(0.2)c";

        [Test]
        public void ParseInput()
        {
            Node node = Node.ParseInput(InputString);
            var firstNodeName = node.GetNodeName();

            Assert.AreEqual("a", firstNodeName);
        }

        [Test]
        public void ATest()
        {
            Node node = Node.ParseInput(InputString);
            Node outputNode = node.GivenInputGetNode(0.9);
            Assert.AreEqual("c", outputNode.GetNodeName());
        }

        [Test]
        public void AnotherTest()
        {
            Node node = Node.ParseInput(InputString);
            Node nameOfNode = node.GivenInputGetNode(0.1);
            Assert.AreEqual("b", nameOfNode.GetNodeName());
        }
    }
}
