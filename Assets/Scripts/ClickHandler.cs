using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private GameObject card;
    private CardData data;

    public void Awake()
    {
        card = gameObject;
        data = card.GetComponent<CardData>();
    }

    public void OnMouseDown()
    {
        // If it's not player turn, return
        if (GameManager.GetInstance().PlayerController.Id != GameManager.GetInstance().ActivePlayer) return;

        PlayerState player = GameManager.GetInstance().GetActivePlayerState();

        // If player has the amount to buy a card
        if (player.Skillpoints >= data.skillPointCost && player.Attack >= data.attackCost && data.isInShop == true)
        {
            player.Skillpoints -= data.skillPointCost;
            player.Attack -= data.attackCost;
            GameManager.GetInstance().AddToPlayerDiscard(card);
            data.isInShop = false;
            Debug.Log("Carte achetée et ajoutée à la défausse !");
            return;
        }
        Debug.Log("carte non achetée");
    }
}
