using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node<T> : MonoBehaviour
{
    protected List<Edge<T>> edges;
    protected int id;

    public Node(int id)
    {
        edges = new List<Edge<T>>();
        this.id = id;
    }

    public int Id { get => id; set => id = value; }

    public void AddEdge(Edge<T> edge)
    {
        edges.Add(edge);
    }

    public override string ToString()
    {
        string s = "Node " + id + ": [";
        foreach(Edge<T> edge in edges)
        {
            s += edge.ToString() + ", ";
        }
        s += "]";
        return s;
    }

}
