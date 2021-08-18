using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveClank : CardEffect
{
    public int number;

    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().RemoveClankFrom(player, number);
    }

}
