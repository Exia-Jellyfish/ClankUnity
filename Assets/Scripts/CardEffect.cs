using System.Collections;
using System.Collections.Generic;
public abstract class CardEffect
{
    protected int player;

    protected CardEffect(int player)
    {
        this.player = player;
    }

    public virtual void Execute()
    {

    }

}
