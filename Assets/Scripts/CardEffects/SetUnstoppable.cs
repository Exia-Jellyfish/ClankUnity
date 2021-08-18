using System.Collections;
using System.Collections.Generic;

public class SetUnstoppable : CardEffect
{

    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().SetUnstoppableTo(player, true);
    }
}
