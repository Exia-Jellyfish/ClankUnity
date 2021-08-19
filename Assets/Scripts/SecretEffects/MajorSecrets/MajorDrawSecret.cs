using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorDrawSecret : SecretEffect
{
    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().Draw(player, 3);
    }
}
