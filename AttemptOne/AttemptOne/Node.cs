using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;

namespace AttemptOne
{
    public class Node
    {
        private readonly string _name;
        private readonly List<Connection> _connections = new List<Connection>();

        public static Node ParseInput(string input)
        {
            var nodes = new Dictionary<string, Node>();
            var connections = input.Split(',');
            string firstNodeName = connections[0].Substring(0, connections[0].IndexOf("(", StringComparison.Ordinal));
            foreach (var connection in connections)
            {
                var indexOfOpenBraket = connection.IndexOf("(", StringComparison.Ordinal);
                var indexOfCloseBracket = connection.IndexOf(")", StringComparison.Ordinal);

                var sourceNode = connection.Substring(0, indexOfOpenBraket);
                var targetNode = connection.Substring(indexOfCloseBracket + 1);
                string weightValue = connection.Substring(indexOfOpenBraket + 1, indexOfCloseBracket - indexOfOpenBraket - 1);
                var weight = double.Parse(weightValue);

                if (!nodes.ContainsKey(sourceNode))
                {
                    nodes.Add(sourceNode, new Node(sourceNode));
                }
                var node = nodes[sourceNode];
                if (!nodes.ContainsKey(targetNode))
                {
                    nodes.Add(targetNode, new Node(targetNode));
                }
                node.AddTarget(nodes[targetNode], weight);
            }

            return nodes[firstNodeName];

        }

        private void AddTarget(Node node, double weight)
        {
            _connections.Add(new Connection(node, weight));
            if (_connections.Sum(c => c.Weight) > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(weight));
            }
        }

        public Node(string name)
        {
            _name = name;
        }

        public Node GivenInputGetNode(double breakpoint)
        {
            double accumulator = 0;
            foreach (var connection in _connections)
            {
                accumulator = accumulator + connection.Weight;
                if (accumulator >= breakpoint)
                {
                    return connection.Node;
                }
            }

            return this;
        }

        public string GetNodeName()
        {
            return _name;

        }
    }

    internal struct Connection
    {
        public Node Node { get; }
        public double Weight { get; }

        public Connection(Node node, double weight)
        {
            Node = node;
            Weight = weight;
        }
    }
}
