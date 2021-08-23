using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class CardEffect : MonoBehaviour
{
    protected int player;
    public static Action<int> playerUpdated;

    public virtual void Execute()
    {

    }

    private void OnDisable()
    {
        playerUpdated?.Invoke(player);
    }
}
