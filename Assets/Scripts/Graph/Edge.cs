using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge
{
    private Node startNode;
    private Node endNode;

    public Edge(Node startNode, Node endNode)
    {
        this.startNode = startNode;
        this.endNode = endNode;
    }

    public Node StartNode { get => startNode;}
    public Node EndNode { get => endNode;}

    public override string ToString()
    {
        string s = "(" + startNode.Id + " -> " + endNode.Id + ")";
        return s;
    }
}
