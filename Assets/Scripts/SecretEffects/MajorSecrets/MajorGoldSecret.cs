using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorGoldSecret : SecretEffect
{
    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().AddGoldTo(player, 5);
    }
}
