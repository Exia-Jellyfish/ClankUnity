using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClankEdge : Edge
{
    public GameObject startTile;
    public GameObject endTile;

    private void Awake()
    {
        startNode = startTile.GetComponent<ClankNode>();
        endNode = endTile.GetComponent<ClankNode>();
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
        System.IO.File.WriteAllText("C:\\Users\\louka\\OneDrive\\Documents\\DocsExia\\Année 4\\rattrapage de stage\\ClankUnity\\Assets\\Ressources\\map0.json", JsonUtility.ToJson(this));
    }
}
