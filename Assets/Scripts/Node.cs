using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private List<Edge> edges;
    private int id;

    public Node(int id)
    {
        edges = new List<Edge>();
        this.id = id;
    }

    public int Id { get => id; set => id = value; }

    public void AddEdge(Edge edge)
    {
        edges.Add(edge);
    }

    public override string ToString()
    {
        string s = "Node " + id + ": [";
        foreach(Edge edge in edges)
        {
            s += edge.ToString() + ", ";
        }
        s += "]";
        return s;
    }

}
