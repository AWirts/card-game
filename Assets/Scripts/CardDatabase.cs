using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card> ();

    void Awake ()
    {
        cardList.Add(new Card (0, "Dude", 1, 1, 1, 1, "He's a Dude",Resources.Load<Sprite>("Sprites/cards")));
        cardList.Add(new Card (1, "Dude", 2, 1, 1, 1, "He's a Dude",Resources.Load<Sprite>("Sprites/cards")));
        cardList.Add(new Card (2, "Dude", 3, 1, 1, 1, "He's a Dude",Resources.Load<Sprite>("Sprites/cards")));
        cardList.Add(new Card (3, "Dude", 4, 1, 1, 1, "He's a Dude",Resources.Load<Sprite>("Sprites/cards")));
        cardList.Add(new Card (4, "Dude", 5, 1, 1, 1, "He's a Dude",Resources.Load<Sprite>("Sprites/cards")));
    }
}
