using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    protected Node startNode;
    protected Node endNode;
    private bool isDirected;
    public Node StartNode { get => startNode; }
    public Node EndNode { get => endNode; }
    public bool IsDirected { get => isDirected; }

/*    public Edge(Node startNode, Node endNode)
    {
        this.startNode = startNode;
        this.endNode = endNode;
    }*/

    /*public override string ToString()
    {
        string s = "(" + startNode.Id + " -> " + endNode.Id + ")";
        return s;
    }*/
}
