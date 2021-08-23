using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private PlayerState[] playerStates;
    private int activePlayer = 0;
    public const int NUMBER_OF_PLAYERS = 4;
    private int[] clankCounters;
    private Bag bag;
    private BoardManager boardManager;
    private DeckManager deckManager;
    public GameObject deckPrefab;
    public GameObject discardPrefab;
    private InventoryManager inventoryManager;


    private PlayerController playerController;

    public int ActivePlayer { get => activePlayer; }
    public PlayerController PlayerController { get => playerController; }

    public PlayerState GetActivePlayerState()
    {
        return playerStates[activePlayer];
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(this);
        }
        Deck[] decks = new Deck[NUMBER_OF_PLAYERS];
        Deck[] discards = new Deck[NUMBER_OF_PLAYERS];
        playerStates = new PlayerState[NUMBER_OF_PLAYERS];
        for (int i = 0; i < NUMBER_OF_PLAYERS; i++)
        {
            playerStates[i] = new PlayerState();
            decks[i] = Instantiate(deckPrefab).GetComponent<Deck>();
            discards[i] = Instantiate(discardPrefab).GetComponent<Deck>();
            decks[i].gameObject.transform.position = new Vector3(-5.05629873f, 1.24331939f, 0.848258018f);
            discards[i].gameObject.transform.position = new Vector3(-4.11237621f, 1.24699998f, 0.794548154f);
        }

        deckManager = new DeckManager(decks, discards);
        clankCounters = new int[NUMBER_OF_PLAYERS];
        bag = new Bag();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        boardManager = new BoardManager();
        inventoryManager = new InventoryManager();


    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void Test()
    {
        /*        ClankGraph graph = new ClankGraph();

                graph.Debug();

                foreach (Node node in graph.FindAdjacentNodes(graph.GetNode(3)))
                {
                    Debug.Log(node.ToString());

                }
        boardManager.LightOnAdjacentTiles((ClankNode)boardManager.graph.GetNode(2));

        boardManager.MovePlayerToken(0, (ClankNode)boardManager.graph.GetNode(2));*/
        AddMovementTo(1, 10);
        AddMovementTo(activePlayer, 10);
        AddSkillpointTo(activePlayer, 10);

    }

    public void Test2()
    {
        Debug.Log("Movement points : " + playerStates[activePlayer].Movement);
        Debug.Log("Skill points : " + playerStates[activePlayer].Skillpoints);
        Debug.Log("Attack points : " + playerStates[activePlayer].Attack);
        Debug.Log("Gold : " + playerStates[activePlayer].Gold);
        
    }

    public void TestInventory()
    {
        Debug.Log("Inventory : " + inventoryManager.GetItem(ActivePlayer, 0));
    }

    public void TryToMovePlayerToken(int player, ClankNode clankNode)
    {
        boardManager.TryToMovePlayerToken(player, (ClankNode)boardManager.graph.GetNode(clankNode.id));
    }

    public PlayerState GetPlayerState(int player)
    {
        return playerStates[player];
    }

    public int GetActivePlayer()
    {
        return activePlayer;
    }

    // Main -> Terrain
    public void AddClankTo(int player, int number)
    {
        if (playerStates[player].ClankCubes >= number)
        {
            clankCounters[player] += number;
            playerStates[player].ClankCubes -= number;
        }
        else
        {
            clankCounters[player] += playerStates[player].ClankCubes;
            playerStates[player].ClankCubes = 0;
        }
    }

    // Terrain -> Main    
    public void RemoveClankFrom(int player, int number)
    {
        if (clankCounters[player] >= number)
        {
            clankCounters[player] -= number;
            playerStates[player].ClankCubes += number;
        }
        else
        {
            playerStates[player].ClankCubes += clankCounters[player];
            clankCounters[player] = 0;
        }
    }

    // Vie -> Main
    public void HealPlayer(int player, int number)
    {
        if (playerStates[player].HealthMeter > 0 && playerStates[player].HealthMeter >= number)
        {
            playerStates[player].ClankCubes += number;
            playerStates[player].HealthMeter -= number;
        }
        else
        {
            playerStates[player].ClankCubes += playerStates[player].HealthMeter;
            playerStates[player].HealthMeter = 0;
        }
    }

    // Terrain -> Sac
    public void TransferClankCubesToBag(int number) 
    {
        for (int i = 0; i < NUMBER_OF_PLAYERS; i++)
        {
            bag.PlayerCubes[i] += number;
            clankCounters[i] = 0;
        }
    }
    
    // Main -> Vie, Sac -> Vie
    public void DamagePlayer(int player, int number, DamageSource source)
    {
        //TODO : Update the healthMeter when taking damage.
        if (source == DamageSource.DRAGON)
        {
            Application.Quit();
        }
        else if (source == DamageSource.MONSTER)
        {
            if (playerStates[player].ClankCubes < number)
            {
                number = playerStates[player].ClankCubes;
                playerStates[player].ClankCubes = 0;
            }
            else
            {
                playerStates[player].ClankCubes -= number;
            }
        }
        playerStates[player].HealthMeter += number;
    }

    public void PlayCard(int player, GameObject card)
    {
        foreach (CardEffect effect in card.GetComponents<CardEffect>())
        {
            effect.Execute();
        }
        deckManager.Discard(player, card);
    }

    // Skillpoints

    public void AddSkillpointTo(int player, int number)
    {
        playerStates[player].Skillpoints += number;
    }

    // Movement
    public void AddMovementTo(int player, int number)
    {
        playerStates[player].Movement += number;
    }

    public void ReduceMovementOf(int player, int number)
    {
        playerStates[player].Movement -= number;
    }

    // SetUnstoppable
    public void SetUnstoppableTo(int player, bool value)
    {
        playerStates[player].IsUnstoppable = value;
    }

    //AddAttack to a player
    public void AddAttackTo(int player, int number)
    {
        playerStates[player].Attack += number;
    }

    public void ReduceAttackOf(int player, int number)
    {
        playerStates[player].Attack -= number;
    }

    //AddGold to a player
    public void AddGoldTo(int player, int number)
    {
        playerStates[player].Gold += number;
    }

    //Add a card to the discard pile of a player
    public void AddToPlayerDiscard (int player, GameObject card)
    {
        deckManager.Discard(player, card);
    }

    //Draw a card from the player deck
    public void Draw(int player, int number = 1)
    {
        deckManager.Draw(player, number);
    }

    //Pick up a cube in the bag on a dragon attack
    public void DragonAttack(int dragonRage)
    {
        bag.PickCubes(dragonRage);
    }

    public void AddToInventory(int player, IInventoryItem item)
    {
        inventoryManager.AddToInventory(player, item);
    }

    public int ScoreInventory(int player)
    {
        int score = 0;
        for (int i = 0; i< inventoryManager.GetInventorySize(player); i++)
        {
            if(inventoryManager.GetItem(player, i) is Artifact)
            {
                score += (inventoryManager.GetItem(player, i) as Artifact).victoryPoints;
            }
            /*else if (inventoryManager.GetItem(i) is Treasure)
            {
                score += (inventoryManager.GetItem(i) as Treasure).victoryPoints;
            }*/
            /*else if (inventoryManager.GetItem(i) is ShopItem)
            {
                score += (inventoryManager.GetItem(i) as ShopItem).victoryPoints;
            }*/
        }
        return score;
    }

    public int ScoreDeck(int player)
    {
        return deckManager.ScoreDeck(player);
    }

    public int ScoreDiscard(int player)
    {
        return deckManager.ScoreDiscard(player);
    }
}
