using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class CardEffect : MonoBehaviour
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
