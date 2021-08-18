using System.Collections;
using System.Collections.Generic;

public class AddSkillpoint : CardEffect
{
    public int number;


    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().AddSkillpointTo(player, number);
    }
}
