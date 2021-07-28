using System.Collections;
using System.Collections.Generic;

public class DamagePlayer : CardEffect
{
    private int number;
    private DamageSource source;

    public DamagePlayer(int player, int number, DamageSource source) : base(player)
    {
        this.number = number;
        this.source = source;
    }

    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().DamagePlayer(player, number, source);
    }

}
