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
    public Node GetNode(int id)
    {
        return nodes[id];
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

    public List<Node> FindAdjacentNodes(Node node)
    {
        List<Node> adjacentNodes = new List<Node>();
        foreach (Edge edge in node.Edges)
        {
            if (edge.StartNodeId == node.id)
            {
                adjacentNodes.Add(nodes[edge.EndNodeId]);
            }
            else
            {
                adjacentNodes.Add(nodes[edge.StartNodeId]);
            }
        }
        return adjacentNodes;

    }

    public List<Node> FindDirectedAdjacentNodes(Node node)
    {
        List<Node> adjacentNodes = new List<Node>();
        foreach (Edge edge in node.Edges)
        {
            // isStartNode  isDirected  Resultat
            //      0           0       Add(startNode)    
            //      0           1       rien
            //      1           0       Add(endNode)
            //      1           1       Add(endNode)
            if (edge.StartNodeId == node.id)
            {
                adjacentNodes.Add(nodes[edge.EndNodeId]);
            }
            else if (!edge.IsDirected)
            {
                adjacentNodes.Add(nodes[edge.StartNodeId]);
            }
        }
        return adjacentNodes;
    }

    public void Debug()
    {
        string s = "Graph :\n";
        foreach (Edge e in edges)
        {
            s += e.ToString() + ", ";
        }
        s += "\n";
        foreach (Node n in nodes.Values)
        {
            s += n.ToString() + "\n";
        }
        UnityEngine.Debug.Log("Debug");
        UnityEngine.Debug.Log(s);
    }
}
