using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClankGraph : Graph
{
    public ClankGraph() : base()
    {
        GameObject tiles = GameObject.Find("Tiles");
        foreach (Transform transform in tiles.transform.GetComponentsInChildren<Transform>())
        {
            AddNode(transform.gameObject.GetComponent<ClankNode>());
        }

        GameObject edges = GameObject.Find("Edges");
        foreach (Transform transform in edges.transform.GetComponentsInChildren<Transform>())
        {
            AddEdge(transform.gameObject.GetComponent<ClankEdge>());
        }

    }
}
