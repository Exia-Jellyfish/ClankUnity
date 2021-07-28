using System.Collections;
using System.Collections.Generic;

public class Bag
{
    private int dragonCubes = 24;
    private int[] playerCubes;

    public Bag()
    {
        playerCubes = new int[GameManager.NUMBER_OF_PLAYERS];
    }

    public int DragonCubes { get => dragonCubes; set => dragonCubes = value; }
    public int[] PlayerCubes { get => playerCubes; set => playerCubes = value; }
}
