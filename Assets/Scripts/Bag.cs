using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag
{
    private int dragonCubes = 24;
    private int[] playerCubes;
    public int TotalCubes
    {
        get
        {
            int totalCubes = dragonCubes;
            for (int i = 0; i < playerCubes.Length; i++)
            {
                totalCubes += playerCubes[i];
            }
            return totalCubes;
        }
        
    }

    public Bag()
    {
        playerCubes = new int[GameManager.NUMBER_OF_PLAYERS];
    }



    public void PickCubes(int number)
    {
        for (int i = 0; i < number; i++)
        {
            int[] cumulativeWeights = new int[GameManager.NUMBER_OF_PLAYERS+2];
            cumulativeWeights[0] = 0;
            cumulativeWeights[1] = dragonCubes;
            for (int h = 2; h < GameManager.NUMBER_OF_PLAYERS +2; h++)
            {
                cumulativeWeights[h] += cumulativeWeights[h - 1] + playerCubes[h - 2];
            }
            int rand = Random.Range(0, TotalCubes);
            int selectedPlayer = -1;

            for (int j = 0; j < GameManager.NUMBER_OF_PLAYERS+2; j++)
            {
                if (rand <= cumulativeWeights[j])
                {
                    selectedPlayer = j;
                    break;
                }
            }
            if(selectedPlayer == 1)
            {
                dragonCubes -= 1;
            }
            else
            {
                playerCubes[selectedPlayer-2] -= 1;
            }
        }
    }

    public int DragonCubes { get => dragonCubes; set => dragonCubes = value; }
    public int[] PlayerCubes { get => playerCubes; set => playerCubes = value; }
}
