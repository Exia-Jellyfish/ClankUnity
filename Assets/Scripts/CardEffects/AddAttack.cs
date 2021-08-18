using System.Collections;
using System.Collections.Generic;

public class AddAttack : CardEffect
{
    public int number;

    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().AddAttackTo(player, number);
    }
}
