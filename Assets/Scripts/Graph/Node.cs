using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private List<Edge> edges;
    public int id;

    /*public Node(int id)
    {
        edges = new List<Edge>();
        this.id = id;
    }*/

    private void Awake()
    {
        edges = new List<Edge>();
    }

    public int Id { get => id; set => id = value; }
    public List<Edge> Edges { get => edges; }

    public void AddEdge(Edge edge)
    {
        edges.Add(edge);
    }
    public override string ToString()
    {
        string s = "Node " + id + ": [";
        foreach(Edge edge in Edges)
        {
            s += edge.ToString() + ", ";
        }
        s += "]";
        return s;
    }

}
