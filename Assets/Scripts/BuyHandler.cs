using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHandler : MonoBehaviour
{
    private GameObject card;
    private CardData data;

    public void Awake()
    {
        card = transform.root.gameObject;
        data = card.GetComponent<CardData>();
    }

    public void OnMouseDown()
    {
        // If it's not player turn, return
        if (GameManager.GetInstance().PlayerController.Id != GameManager.GetInstance().ActivePlayer) return;

        PlayerState player = GameManager.GetInstance().GetActivePlayerState();

        // If player has the amount to buy a card
        if (player.Skillpoints >= data.skillPointCost && player.Attack >= data.attackCost)
        {
            player.Skillpoints -= data.skillPointCost;
            player.Attack -= data.attackCost;

            // TODO : Add the card to the discard pile
            GameManager.GetInstance().PlayCard(card);
            Debug.Log("Carte gandalf jouée");
            return;
        }
        Debug.Log("carte non jouée");
    }
}
