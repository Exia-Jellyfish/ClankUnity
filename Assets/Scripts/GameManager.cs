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
    private DeckManager deckManager;
    public GameObject deckPrefab;
    public GameObject discardPrefab;


    private PlayerController playerController;

    public int ActivePlayer { get => activePlayer; }
    public PlayerController PlayerController { get => playerController; }

    public PlayerState GetActivePlayerState()
    {
        return playerStates[activePlayer];
    }

    private void Awake()
    {
        Deck[] decks = new Deck[NUMBER_OF_PLAYERS];
        Deck[] discards = new Deck[NUMBER_OF_PLAYERS];
        playerStates = new PlayerState[NUMBER_OF_PLAYERS];
        for (int i = 0; i < NUMBER_OF_PLAYERS; i++)
        {
            playerStates[i] = new PlayerState();
            decks[i] = Instantiate(deckPrefab).GetComponent<Deck>();
            discards[i] = Instantiate(discardPrefab).GetComponent<Deck>();
        }
        deckManager = new DeckManager(decks, discards);
        clankCounters = new int[NUMBER_OF_PLAYERS];
        bag = new Bag();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        
        instance = this;

    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void Test()
    {
        GameObject mrmoustache = GameObject.Find("Lasagne");
        PlayCard(mrmoustache);
        
        Debug.Log("Skillpoints " + playerStates[activePlayer].Skillpoints);
        Debug.Log("Gold" + playerStates[activePlayer].Gold);
        Debug.Log("attack" + playerStates[activePlayer].Attack);
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

    public void PlayCard(GameObject card)
    {
        foreach (CardEffect effect in card.GetComponents<CardEffect>())
        {
            effect.Execute();
        }
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
}
