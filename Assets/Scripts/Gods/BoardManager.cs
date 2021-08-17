using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager
{
    public ClankGraph graph;
    private GameObject[] playerTokens;
    public const float pawnOffset = 0.05f;
    private ClankNode[] playerActualNodes;
    public BoardManager()
    {
        graph = new ClankGraph();
        playerTokens = new GameObject[GameManager.NUMBER_OF_PLAYERS];
        PlayerToken[] tokens = GameObject.FindObjectsOfType<PlayerToken>();
        for (int i = 0; i < tokens.Length; i++)
        {
            playerTokens[i] = tokens[i].gameObject;
        }
        playerActualNodes = new ClankNode[GameManager.NUMBER_OF_PLAYERS];
        for (int i = 0; i < playerActualNodes.Length; i++)
        {
            playerActualNodes[i] = (ClankNode)graph.nodes[0];
        }
        LightOnAdjacentTiles(playerActualNodes[0]);
    }

    public void LightOnAdjacentTiles(ClankNode clankNode)
    {
        List<Node> adjacentNodes = graph.FindDirectedAdjacentNodes(clankNode);
        foreach(Node node in adjacentNodes)
        {
            node.GetComponent<ClickTile>().LightOn();
        }
    }

    public void LightsOff()
    {
        foreach (Node node in graph.nodes.Values)
        {
            node.GetComponent<ClickTile>().LightOff();
        }
    }

    public void MovePlayerToken(int player, ClankNode clickedNode)
    {
        List<Node> aroundNodes = graph.FindDirectedAdjacentNodes(playerActualNodes[player]);
        if (aroundNodes.Contains(clickedNode))
        {
            LightsOff();
            playerTokens[player].transform.position = clickedNode.transform.position + new Vector3(0, pawnOffset, 0);
            LightOnAdjacentTiles(clickedNode);
            playerActualNodes[player] = clickedNode;
        }
        else
        {
            Debug.Log("Impossible de se déplacer sur cette case.");
        }
    }
}
