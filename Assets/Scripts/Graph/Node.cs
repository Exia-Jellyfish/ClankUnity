using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    protected List<Edge> edges;
    public int id;

    /*public Node(int id)
    {
        edges = new List<Edge>();
        this.id = id;
    }*/

    private void Awake()
    {
        edges = new List<Edge>();
        Debug.Log("Awake");
        Debug.Log(edges);
    }

    public int Id { get => id; set => id = value; }
    public List<Edge> Edges { get => edges; }

    public void AddEdge(Edge edge)
    {
        edges.Add(edge);
    }
    public override string ToString()
    {
        Debug.Log(this.gameObject);
        string s = "Node " + id + ": [";
        foreach(Edge edge in edges)
        {
            s += edge.ToString() + ", ";
        }
        s += "]";
        return s;
    }

}
