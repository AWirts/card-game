using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card> ();
    public Card container = new Card ();

    public int x;
    public int deckSize;

    // Start is called before the first frame update
    void Start()
    {
        x=0;
        deckSize = 40;

        for(int i=0; i<deckSize; i++)
        {
            x= Random.Range(1, 4);
            deck.Add(CardDatabase.cardList[x]);
        }
    }

    public void Shuffle()
    {
        for(int i=0;i<deckSize;i++)
        {
            container=deck[i];
            int randomIndex = Random.Range(0,deckSize);
            deck[i]=deck[randomIndex];
            deck[randomIndex]=container;
        }

    }
}
