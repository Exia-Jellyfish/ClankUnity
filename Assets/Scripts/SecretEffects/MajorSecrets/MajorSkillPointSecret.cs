using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorSkillPointSecret : SecretEffect
{
    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().AddSkillpointTo(player, 5);
    }
}