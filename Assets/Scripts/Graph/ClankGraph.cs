using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClankGraph : Graph
{
    public ClankGraph() : base()
    {
        GameObject tiles = GameObject.Find("Tiles");
        for (int i = 0; i < tiles.transform.childCount; i++)
        {
            AddNode(tiles.transform.GetChild(i).gameObject.GetComponent<ClankNode>());
        }

        GameObject edges = GameObject.Find("Edges");
        for (int i = 0; i < edges.transform.childCount; i++)
        {
            AddEdge(edges.transform.GetChild(i).gameObject.GetComponent<ClankEdge>());
        }

    }
}
