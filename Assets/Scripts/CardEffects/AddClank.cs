using System.Collections;
using System.Collections.Generic;


public class AddClank : CardEffect
{
    public int number;

    public AddClank(int player, int number) : base(player)
    {
        this.number = number;
    }

    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().AddClankTo(player, number);
    }

}
