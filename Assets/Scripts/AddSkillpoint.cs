using System.Collections;
using System.Collections.Generic;

public class AddSkillPoint : CardEffect
{
    private int number;

    public AddSkillPoint(int player, int number) : base(player)
    {
        this.number = number;
    }

    public override void Execute()
    {
        base.Execute();
        GameManager.GetInstance().AddSkillPointTo(player, number);
    }
}
