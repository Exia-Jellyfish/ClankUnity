using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge<T> : MonoBehaviour
{
    protected Node<T> startNode;
    protected Node<T> endNode;

    public Node<T> StartNode { get => startNode; }
    public Node<T> EndNode { get => endNode; }

    /*public override string ToString()
    {
        string s = "(" + startNode.Id + " -> " + endNode.Id + ")";
        return s;
    }*/
}
