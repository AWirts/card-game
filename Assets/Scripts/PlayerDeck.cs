using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card> ();
    private Card container = new Card ();
    public static List<Card> staticDeck = new List<Card> ();

    private int x;
    public static int deckSize;
    private bool handStart = false;

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;
   
    public GameObject CardToHand;
    public GameObject CardBack;
    public GameObject Deck;
    public GameObject Hand;

    IEnumerator StartGame()
    {
        for(int i=0;i<=4;i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand,transform.position,transform.rotation); 
        }
        handStart = true;
    }

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
        staticDeck = deck;
        StartCoroutine(StartGame());
    }

    void Update()
    {
        
        if(deckSize<30)
        {
            cardInDeck1.SetActive(false);
        }
        if(deckSize<20)
        {
            cardInDeck2.SetActive(false);
        }
        if(deckSize<2)
        {
            cardInDeck3.SetActive(false);
        }
        if(deckSize<1)
        {
            cardInDeck4.SetActive(false);
        }
        if(handStart)
        {
            if(Hand.transform.childCount == 0){
                handStart = false;
                StartCoroutine(StartGame());
            }
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