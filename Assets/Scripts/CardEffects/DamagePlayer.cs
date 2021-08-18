using System.Collections;
using System.Collections.Generic;

public class DamagePlayer : CardEffect
{
    public int number;
    public DamageSource source;

    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().DamagePlayer(player, number, source);
    }

}
