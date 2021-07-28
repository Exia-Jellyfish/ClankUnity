using System.Collections;
using System.Collections.Generic;

public class HealPlayer : CardEffect
{
    private int number;

    public HealPlayer(int player, int number) : base(player)
    {
        this.number = number;
    }

    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().HealPlayer(player, number);
    }

}
