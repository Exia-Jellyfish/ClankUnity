using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    private int id;
    protected int startNodeId;
    protected int endNodeId;
    public bool isDirected;

    public int StartNodeId { get => startNodeId; set => startNodeId = value; }
    public int EndNodeId { get => endNodeId; set => endNodeId = value; }
    public bool IsDirected { get => isDirected; }
    public int Id { get => id; set => id = value; }

    /*    public Edge(Node startNode, Node endNode)
        {
            this.startNode = startNode;
            this.endNode = endNode;
        }*/

    public override string ToString()
    {
        string s = "(" + startNodeId + " -> " + endNodeId + ")";
        return s;
    }
}
