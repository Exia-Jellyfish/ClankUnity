using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{

    private static GameManager instance;
    //private int activePlayer;

    private GameManager()
    {

    }

    public static GameManager GetInstance()
    {
        return instance ?? (instance = new GameManager());
    }

    public void Test(){
        CardData lmatData = new CardData();
        lmatData.cardEffects.AddRange(new List<CardEffect> {
            new AddClank(0, 2),
            new AddMovement(0, 2),
            new SetUnstoppable(0, true),
        });
        foreach (CardEffect effect in moucharderData.cardEffects)
        {
            effect.Execute();
        }
    

    public PlayerController GetActivePlayer()
    {
        return PlayerController player;
    }

    public void AddClankTo(PlayerController player, int number)
    {
        //players[id].clankCubes += number;
    }


}