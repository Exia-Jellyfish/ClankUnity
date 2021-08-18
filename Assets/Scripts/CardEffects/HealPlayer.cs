using System.Collections;
using System.Collections.Generic;

public class HealPlayer : CardEffect
{
    public int number;

    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().HealPlayer(player, number);
    }

}
