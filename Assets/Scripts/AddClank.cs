using System.Collections;
using System.Collections.Generic;


public class AddClank : CardEffect
{
    private int number;
    private PlayerController player;

    public AddClank(PlayerController player, int number)
    {
        this.number = number;
        this.player = player;
    }

    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().AddClankTo(player, number);
    }

}
