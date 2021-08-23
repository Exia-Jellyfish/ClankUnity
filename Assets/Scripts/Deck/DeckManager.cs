using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager
{
    private Deck[] playerDecks = new Deck[GameManager.NUMBER_OF_PLAYERS];
    private Deck[] playerDiscards = new Deck[GameManager.NUMBER_OF_PLAYERS];

    public DeckManager(Deck[] decks, Deck[] discards)
    {
        decks.CopyTo(playerDecks, 0);
        discards.CopyTo(playerDiscards, 0);
    }

    public void Draw(int player, int number = 1)
    {
        Deck discard = playerDiscards[player];
        Deck deck = playerDecks[player];
        for (int i = 0; i < number; i++)
        {
            if (deck.Count == 0)
            {
                if (discard.Count == 0)
                {
                    return;
                }
                discard.Shuffle();
                deck.Load(discard);
                discard.Clear();
            }
            GameObject card = deck.RemoveCard();
            card.SetActive(true);
        }
    }

    public void Discard(int player, GameObject card)
    {
        playerDiscards[player].AddCard(card);
        card.SetActive(false);
    }

    public int GetCardInDeckVictoryPoints(int player, int card)
    {
        return playerDecks[player].cards[card].GetComponent<CardData>().victoryPoints;
    }

    public int GetCardInDiscardVictoryPoints(int player, int card)
    {
        return playerDiscards[player].cards[card].GetComponent<CardData>().victoryPoints;
    }

    public int ScoreDeck(int player)
    {
        int score = 0;
        for (int i = 0; i < playerDecks[player].Count; i++)
        {
            score += GetCardInDeckVictoryPoints(player, i);
        }
        return score;
    }

    public int ScoreDiscard(int player)
    {
        int score = 0;
        for (int i = 0; i < playerDiscards[player].Count; i++)
        {
            score += GetCardInDiscardVictoryPoints(player, i);
        }
        return score;
    }
}
