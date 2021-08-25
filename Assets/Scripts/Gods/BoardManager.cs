using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoardManager
{
    public ClankGraph graph;
    private GameObject[] playerTokens;
    private const float pawnOffset = 0.2f;
    private ClankNode[] playerCurrentNodes;
    public SpawnManager spawnManager;
    public BoardManager()
    {
        graph = new ClankGraph();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerTokens = new GameObject[GameManager.NUMBER_OF_PLAYERS];
        PlayerToken[] tokens = GameObject.FindObjectsOfType<PlayerToken>();
        for (int i = 0; i < tokens.Length; i++)
        {
            playerTokens[i] = tokens[i].gameObject;
        }
        playerCurrentNodes = new ClankNode[GameManager.NUMBER_OF_PLAYERS];
        for (int i = 0; i < playerCurrentNodes.Length; i++)
        {
            playerCurrentNodes[i] = (ClankNode)graph.GetNode(0);
        }
        CardEffect.playerUpdated += LightOnValidTiles;
        
        LightOnAdjacentTiles(playerCurrentNodes[0]);

        SetupSecrets();
        SetupArtifacts();
    }

    public void SetupSecrets()
    {
        foreach (ClankNode clankNode in graph.GetNodes())
        {
            TileState secretState = clankNode.state;
            if (secretState == TileState.MINOR_SECRET)
            {
                GameObject go = spawnManager.SpawnRandomMinorSecret(clankNode.transform.position);
                clankNode.secrets.Add(go.GetComponent<SecretToken>());
                go = spawnManager.SpawnRandomMinorSecret(clankNode.transform.position);
                clankNode.secrets.Add(go.GetComponent<SecretToken>());
            }

            else if (secretState == TileState.MAJOR_SECRET)
            {
                GameObject go = spawnManager.SpawnRandomMajorSecret(clankNode.transform.position);
                clankNode.secrets.Add(go.GetComponent<SecretToken>());
            }
        }
    }

    public void SetupArtifacts()
    {
        foreach (ClankNode clankNode in graph.GetNodes())
        {
            TileState secretState = clankNode.state;
            if (secretState == TileState.ARTIFACT)
            {
                spawnManager.SpawnArtifact(clankNode.transform.position, clankNode.artifact.gameObject);
            }
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

    private bool CheckTile(int player, ClankNode clankNode)
    {
        PlayerState playerState = GameManager.GetInstance().GetPlayerState(player);
        ClankEdge travelEdge = (ClankEdge)graph.FindConnectingEdge(playerCurrentNodes[player], clankNode);
        //TODO : change the isLocked verification;
        return travelEdge != null && travelEdge.movementCost <= playerState.Movement && !travelEdge.isLocked && !playerState.IsStuck && (playerCurrentNodes[player].type != TileType.CRYSTAL_CAVERNS || playerState.IsUnstoppable);
    }

    public void LightOnTiles(List<Node> nodes)
    {
        foreach (ClankNode node in nodes)
        {
            node.GetComponent<ClickTile>().LightOn();
        }
    }

    public void LightOnValidTiles(int player)
    {
        LightOnTiles(FindValidTiles(player));
    }

    public void LightsOff()
    {
        foreach (Node node in graph.GetNodes())
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
        return graph.FindDirectedAdjacentNodes(playerCurrentNodes[player]).Where(node => CheckTile(player, (ClankNode)node)).ToList();
    }

    public void TryToMovePlayerToken(int player, ClankNode clickedNode)
    {
        List<Node> validNodes = FindValidTiles(player);
        if (validNodes.Contains(clickedNode))
        {
            ClankEdge travelEdge = (ClankEdge)graph.FindConnectingEdge(playerCurrentNodes[player], clickedNode);
            LightsOff();
            PayMoveCost(player, travelEdge);
            MovePlayerToken(player, clickedNode);
            DoTileTypeEffects(player);
            DoTileStateEffects(player);
            LightOnTiles(FindValidTiles(player));
        }
        else
        {
            Debug.Log("Impossible de se déplacer sur cette case.");
        }
    }

    private void MovePlayerToken(int player, ClankNode clickedNode)
    {
        playerTokens[player].transform.position = clickedNode.transform.position + new Vector3(0, pawnOffset, 0);
        playerCurrentNodes[player] = clickedNode;
    }

    public void DoTileStateEffects(int player)
    {
        switch (playerCurrentNodes[player].state)
        {
            case TileState.MINOR_SECRET:
            case TileState.MAJOR_SECRET:
                EnterSecretNode(player);
                break;

            case TileState.HEAL:
                GameManager.GetInstance().HealPlayer(player, 1);
                break;

            case TileState.MONKEY:
                Debug.Log("Got a monkey treasure");
                break;

            case TileState.ARTIFACT:
                EnterArtifactNode(player);
                Debug.Log("Do you want this artifact ?");

                break;
        }
    }

    public void DoTileTypeEffects(int player)
    {
        switch (playerCurrentNodes[player].type)
        {
            case TileType.CRYSTAL_CAVERNS:
                Debug.Log("You can't move anymore this turn.");
                break;


            case TileType.SHOP:
                Debug.Log("Let's do some shopping !");
                break;

            case TileType.END_TILE:
                if (GameManager.GetInstance().GetPlayerState(player).HasArtifact)
                {
                    EndGame(player);
                }
                break;
        }
    }

    public void EnterSecretNode(int player)
    {
        List<SecretToken> secrets = playerCurrentNodes[player].secrets;
        secrets[0].GetComponent<SecretEffect>().Execute();
        Object.Destroy(secrets[0].gameObject);
        secrets.RemoveAt(0);
        if (secrets.Count == 0)
        {
            playerCurrentNodes[player].state = TileState.NONE;
        }
    }

    public void EnterArtifactNode(int player)
    {
        bool option = UnityEditor.EditorUtility.DisplayDialog("Artifact", "Do you want this Artifact ?", "Yes", "No thanks");
        if (option == true)
        {
            AddArtifactToInventory(player);
        }
    }

    public void AddArtifactToInventory(int player)
    {
        Artifact artifact = playerCurrentNodes[player].artifact;
        GameManager.GetInstance().AddToInventory(player, artifact);
        PlayerState playerState = GameManager.GetInstance().GetPlayerState(player);
        playerState.HasArtifact = true;
        artifact.gameObject.SetActive(false);

    }

    public void EndGame(int player)
    {
        PlayerState playerState = GameManager.GetInstance().GetPlayerState(player);
        playerState.VictoryPoints = GameManager.GetInstance().ScoreInventory(player) + playerState.Gold + GameManager.GetInstance().ScoreDeck(player) + GameManager.GetInstance().ScoreDiscard(player);
        Debug.Log("Your victory points : " + playerState.VictoryPoints);
    }
    
    public void AddBoardClankTo(int player, int number)
    {
        for (int i = 0; i < number; i++)
        {
            
        }
    }


    public void RemoveBoardClankFrom(int player, int number)
    {

    }

}
