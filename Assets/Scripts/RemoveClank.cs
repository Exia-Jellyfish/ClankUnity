using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveClank : CardEffect
{
    private int number;

    public RemoveClank(int player, int number) : base(player)
    {
        this.number = number;
    }

    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().RemoveClankFrom(player, number);
    }

}
