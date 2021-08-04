using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<GameObject> cards = new List<GameObject>();

    public int Count { get => cards.Count; }

    public void AddCard(GameObject card)
    {
        cards.Add(card);
    }

    public GameObject RemoveCard()
    {
        if (cards.Count == 0) return null;
        GameObject temp = cards[cards.Count - 1];
        cards.RemoveAt(cards.Count - 1);
        return temp;
    }

    public void Shuffle()
    {
        for (int i = cards.Count - 1; i > 1; --i)
        {
            int randomIndex = Random.Range(0, i + 1);
            GameObject go = cards[randomIndex];
            cards[randomIndex] = cards[i];
            cards[i] = go;
        }

    }

    public void Clear()
    {
        cards.Clear();
    }


    public void Load(Deck deck)
    {
        foreach(GameObject card in deck.cards)
        {
            cards.Add(card);
        }
    }

    public void DebugLog()
    {
        foreach(GameObject go in cards)
        {
            Debug.Log(go);
        }
    }
}
