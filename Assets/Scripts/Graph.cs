using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    private List<Node> nodes;
    private List<Edge> edges;
    public Graph()
    {
        nodes = new List<Node>();
        edges = new List<Edge>();
    }

    public void AddNode(Node node)
    {
        nodes.Add(node);
    }

    public void AddEdge(Edge edge)
    {
        edges.Add(edge);
        edge.StartNode.AddEdge(edge);
        edge.EndNode.AddEdge(edge);
    }

    public void Debug()
    {
        string s = "Graph :\n";
        foreach(Node n in nodes)
        {
            s += n.ToString() + "\n";
        }
        UnityEngine.Debug.Log(s);
    }
}
