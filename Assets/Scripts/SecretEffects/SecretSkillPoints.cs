using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretSkillPoints : SecretEffect
{
    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().AddSkillpointTo(player, 2);
    }
}
