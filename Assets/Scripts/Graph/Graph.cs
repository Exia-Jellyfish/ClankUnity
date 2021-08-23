using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Graph
{
    private static int EdgeId = 0; 
    protected List<Edge> edges;
    protected Dictionary<int, Node> nodes;
    public Graph()
    {
        nodes = new Dictionary<int, Node>();
        edges = new List<Edge>();

    }
    public Node GetNode(int id)
    {
        return nodes[id];
    }

    public List<Node> GetNodes()
    {
        return nodes.Values.ToList();
    }

    public int GetNodesNumber()
    {
        return nodes.Count;
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

    public Edge FindConnectingEdge(Node node1, Node node2)
    {
        foreach (Edge edge in node1.Edges)
        {
            if (edge.StartNodeId == node2.id || edge.EndNodeId == node2.id)
            {
                return edge;
            }
        }
        return null;
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
