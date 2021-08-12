using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClankEdge : Edge
{
    public GameObject test;
    public ClankEdge(Node startNode, Node endNode) : base(startNode, endNode)
    {

    }
    private int movementCost = 1;
    private int attackCost = 0;
    private bool isLocked = false;
}
