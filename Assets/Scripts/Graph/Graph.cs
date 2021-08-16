using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    private static int EdgeId = 0; 
    protected List<Edge> edges;
    public Dictionary<int, Node> nodes;
    public Graph()
    {
        nodes = new Dictionary<int, Node>();
        edges = new List<Edge>();

    }

    public void AddNode(Node node)
    {
        // AlreadyExist     Resultat
        //      0           node
        //      1           node
        if (nodes.ContainsKey(node.id))
        {
            edges.RemoveAll(edge => nodes[node.id].Edges.Contains(edge));
        }
        nodes[node.id] = node;
        foreach (Edge edge in node.Edges)
        {
            edges.Add(edge);
        }
    }

    public void AddEdge(Edge edge)
    {
        //TODO : nodeedgeid 
        edge.Id = EdgeId++;
        edges.Add(edge);

        nodes[edge.StartNodeId].AddEdge(edge);
        nodes[edge.EndNodeId].AddEdge(edge);
    }

    public void Debug()
    {
        string s = "Graph :\n";
        foreach(Node n in nodes)
        {
            s += n.ToString() + "\n";
        }
        UnityEngine.Debug.Log("Debug");
        UnityEngine.Debug.Log(s);
    }
}
