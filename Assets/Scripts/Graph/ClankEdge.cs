using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClankEdge : Edge
{
    public GameObject startTile;
    public GameObject endTile;

    private void Awake()
    {
        startNodeId = startTile.GetComponent<ClankNode>().id;
        endNodeId = endTile.GetComponent<ClankNode>().id;
        gameObject.GetComponent<FixedJoint>().connectedBody = gameObject.transform.root.transform.GetComponent<Rigidbody>();
    }


    private void Start()
    {
        //StartNode.Sheet();
        SaveJson();
    }

    public int movementCost = 1;
    public int attackCost = 0;
    public bool isLocked = false;

    public void SaveJson()
    {
        System.IO.File.WriteAllText("C:\\Users\\louka\\OneDrive\\Documents\\DocsExia\\Ann�e 4\\rattrapage de stage\\ClankUnity\\Assets\\Ressources\\map0.json", JsonUtility.ToJson(this));
    }
}
