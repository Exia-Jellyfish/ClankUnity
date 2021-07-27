using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private PlayerState[] playerStates;
    private int activePlayer = 0;
    private const int NUMBER_OF_PLAYERS = 4;
    private int[] clankCounters;
    public Bag bag;

    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;
    }

    private GameManager()
    {
        playerStates = new PlayerState[NUMBER_OF_PLAYERS];
        for (int i = 0; i < NUMBER_OF_PLAYERS; i++)
        {
            playerStates[i] = new PlayerState();
        }
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public void Test() {
        CardData fauxpas = new CardData();
        fauxpas.cardEffects.AddRange(new List<CardEffect> {
            new AddClank(activePlayer, 5),
            new AddClank(activePlayer, -7),
        });
        foreach (CardEffect effect in fauxpas.cardEffects)
        {
            effect.Execute();
        }
        Debug.Log(playerStates[activePlayer].ClankCubes);
    }

    public void Test2()
    {
        CardData fauxpas = new CardData();
        fauxpas.cardEffects.AddRange(new List<CardEffect> {
            new AddClank(activePlayer, 9),
            new RemoveClank(activePlayer, 7),
        });
        foreach (CardEffect effect in fauxpas.cardEffects)
        {
            effect.Execute();
        }
        Debug.Log("ClankCubes " + playerStates[activePlayer].ClankCubes);
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
    public void DealDamageTo(int player, int number, DamageSource source)
    {
        if (source == DamageSource.DRAGON)
        {
            bag.PlayerCubes[player] -= number;
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


}
