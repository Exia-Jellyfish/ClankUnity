using System.Collections;
using System.Collections.Generic;

public class AddGold : CardEffect
{
    public int number;

    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().AddGoldTo(player, number);
    }
}
