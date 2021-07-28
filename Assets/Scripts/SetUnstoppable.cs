using System.Collections;
using System.Collections.Generic;

public class SetUnstoppable : CardEffect
{

    public SetUnstoppable(int player) : base(player)
    {
        
    }

    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().SetUnstoppableTo(player, true);
    }
}
