using System.Collections;
using System.Collections.Generic;

public class AddMovement : CardEffect
{
    public int number;

    public AddMovement(int player, int number) : base(player)
    {
        this.number = number;
    }

    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().AddMovementTo(player, number);
    }
}
