using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph<T>
{
    protected List<Node<T>> nodes;
    protected List<Edge<T>> edges;
    public Graph()
    {
        nodes = new List<Node<T>>();
        edges = new List<Edge<T>>();
    }

    public void AddNode(Node<T> node)
    {
        nodes.Add(node);
    }

    public void AddEdge(Edge<T> edge)
    {
        edges.Add(edge);
        edge.StartNode.AddEdge(edge);
        edge.EndNode.AddEdge(edge);
    }

    public void Debug()
    {
        string s = "Graph :\n";
        foreach(Node<T> n in nodes)
        {
            s += n.ToString() + "\n";
        }
        UnityEngine.Debug.Log(s);
    }
}
