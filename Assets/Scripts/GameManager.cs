using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{

    private static GameManager instance;
    private PlayerState[] playerStates;
    private int activePlayer = 0;
    private const int NUMBER_OF_PLAYERS = 4;

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
        Debug.Log(playerStates[activePlayer].ClankCounter);
        Debug.Log(playerStates[activePlayer].ClankCubes);
    }

    public void Test2()
    {
        CardData fauxpas = new CardData();
        fauxpas.cardEffects.AddRange(new List<CardEffect> {
            new AddClank(activePlayer, 9),
            new AddClank(activePlayer, -7),
        });
        foreach (CardEffect effect in fauxpas.cardEffects)
        {
            effect.Execute();
        }
        Debug.Log("ClankCounter " + playerStates[activePlayer].ClankCounter);
        Debug.Log("ClankCubes " + playerStates[activePlayer].ClankCubes);
    }
    public int GetActivePlayer()
    {
        return activePlayer;
    }

    public void AddClankTo(int player, int number)
    {
        Debug.Log(number);
        playerStates[player].AddToClankCounter(number);
    }

    public void AddHealthTo(int player, int number)
    {
        Debug.Log(number);
        playerStates[player].AddToHealthBar(number);
    }
}
