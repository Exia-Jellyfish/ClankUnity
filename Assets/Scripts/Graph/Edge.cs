using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    private int startNodeId;
    private int endNodeId;
    private bool isDirected;
    public int StartNodeId { get => startNodeId; set => startNodeId = value; }
    public int EndNodeId { get => endNodeId; set => endNodeId = value; }
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
