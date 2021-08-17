using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    private bool CheckTile(int player, ClankNode clankNode)
    {
        PlayerState playerState = GameManager.GetInstance().GetPlayerState(player);
        ClankEdge travelEdge = (ClankEdge)graph.FindConnectingEdge(playerActualNodes[player], clankNode);
        //TODO : change the isLocked verification;
        return travelEdge != null && travelEdge.movementCost <= playerState.Movement && !travelEdge.isLocked;
    }

    public void LightOnCheckedAdjacentTiles(int player)
    {
        List<Node> adjacentNodes = graph.FindDirectedAdjacentNodes(playerActualNodes[player]);
        foreach(ClankNode node in adjacentNodes)
        {
            if (CheckTile(player, node))
            {
                node.GetComponent<ClickTile>().LightOn();
            }
        }
    }

    public void LightsOff()
    {
        foreach (Node node in graph.nodes.Values)
        {
            node.GetComponent<ClickTile>().LightOff();
        }
    }

    private void PayMoveCost(int player, ClankEdge travelEdge)
    {
        PlayerState playerState = GameManager.GetInstance().GetPlayerState(player);
        GameManager.GetInstance().ReduceMovementOf(player, travelEdge.movementCost);
        int value = Mathf.Min(travelEdge.attackCost, playerState.Attack);
        int damage = Mathf.Max(0, travelEdge.attackCost - playerState.Attack);
        GameManager.GetInstance().DamagePlayer(player, damage, DamageSource.MONSTER);
        GameManager.GetInstance().ReduceAttackOf(player, value);
    }

    private List<Node> FindValidTiles(int player)
    {
        return graph.FindDirectedAdjacentNodes(playerActualNodes[player]).Where(node => CheckTile(player, (ClankNode)node)).ToList();
    }

    public void TryToMovePlayerToken(int player, ClankNode clickedNode)
    {
        List<Node> validNodes = FindValidTiles(player);
        if (validNodes.Contains(clickedNode))
        {
            ClankEdge travelEdge = (ClankEdge)graph.FindConnectingEdge(playerActualNodes[player], clickedNode);
            LightsOff();
            PayMoveCost(player, travelEdge);
            MovePlayerToken(player, clickedNode);
            LightOnCheckedAdjacentTiles(player);
        }
        else
        {
            Debug.Log("Impossible de se déplacer sur cette case.");
        }
    }

    private void MovePlayerToken(int player, ClankNode clickedNode)
    {
        playerTokens[player].transform.position = clickedNode.transform.position + new Vector3(0, pawnOffset, 0);
        playerActualNodes[player] = clickedNode;
    }
}
