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


    public List<Node> FindAdjacentNodes()
    {
        List<Node> adjacentNodes = new List<Node>();
        foreach (Edge edge in Edges)
        {
            if (edge.StartNode.id == id)
            {
                adjacentNodes.Add(edge.EndNode);
            }
            else
            {
                adjacentNodes.Add(edge.StartNode);
            }
        }
        return adjacentNodes;

    }
    public List<Node> FindDirectedAdjacentNodes()
    {
        List<Node> adjacentNodes = new List<Node>();
        foreach(Edge edge in Edges)
        {
            // isStartNode  isDirected  Resultat
            //      0           0       Add(startNode)    
            //      0           1       rien
            //      1           0       Add(endNode)
            //      1           1       Add(endNode)
            if (edge.StartNode.id == id)
            {
                adjacentNodes.Add(edge.EndNode);
            }
            else if (!edge.IsDirected)
            {
                adjacentNodes.Add(edge.StartNode);
            }
        }
        return adjacentNodes;
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
