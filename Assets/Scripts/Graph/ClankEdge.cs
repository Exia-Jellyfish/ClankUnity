using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClankEdge : Edge
{
    public GameObject startTile;
    public GameObject endTile;
    public int movementCost = 1;
    public int attackCost = 0;
    public bool isLocked = false;

    private void Start()
    {
        startNodeId = startTile.GetComponent<ClankNode>().id;
        endNodeId = endTile.GetComponent<ClankNode>().id;
        gameObject.GetComponent<FixedJoint>().connectedBody = gameObject.transform.root.transform.GetComponent<Rigidbody>();
    }
}
