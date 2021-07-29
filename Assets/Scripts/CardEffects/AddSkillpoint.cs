using System.Collections;
using System.Collections.Generic;

public class AddSkillpoint : CardEffect
{
    public int number;

    public AddSkillpoint(int player, int number) : base(player)
    {
        this.number = number;
    }

    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().AddSkillpointTo(player, number);
    }
}
