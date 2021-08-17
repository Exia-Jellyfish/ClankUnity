using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager
{
    public ClankGraph graph;
    private GameObject[] playerTokens;
    public const float pawnOffset = 0.05f;
    public BoardManager()
    {
        graph = new ClankGraph();
        playerTokens = new GameObject[GameManager.NUMBER_OF_PLAYERS];
        PlayerToken[] tokens = GameObject.FindObjectsOfType<PlayerToken>();
        for (int i = 0; i < tokens.Length; i++)
        {
            playerTokens[i] = tokens[i].gameObject;
        }
    }

    public void LightOnAdjacentTiles(ClankNode clankNode)
    {
        List<Node> adjacentNodes = graph.FindDirectedAdjacentNodes(clankNode);
        foreach(Node node in adjacentNodes)
        {
            node.GetComponent<ClickTile>().LightOn();
        }
    }

    public void MovePlayerToken(int player, ClankNode node)
    {
        playerTokens[player].transform.position = node.transform.position + new Vector3(0, pawnOffset, 0);
    }
}
