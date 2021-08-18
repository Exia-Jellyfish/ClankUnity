using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSecret : SecretEffect
{
    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().AddGoldTo(player, 2);
    }
}
