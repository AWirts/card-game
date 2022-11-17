using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ThisCard : MonoBehaviour
{
    private List<Card> thisCard = new List<Card> ();
    public int thisId;

    public int id;
    public string cardName;
    public string cardDescription;
    public int cost;
    public int stamina;
    public int attack;
    public int health;

    public Sprite thisSprite;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI staminaText;
    public TextMeshProUGUI attackText; 
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI descriptionText; 

    public Image thatImage;

    // Start is called before the first frame update
    void Start()
    {
        thisCard.Add(CardDatabase.cardList[thisId]);
       
    }

    void Update()
    {
        if (id != thisId)
        {
            thisCard [0] = CardDatabase.cardList[thisId];
        }
        
        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cost=thisCard[0].cost;
        stamina=thisCard[0].stamina;
        attack=thisCard[0].attack;
        health=thisCard[0].health;
        cardDescription=thisCard[0].cardDescription;
        thisSprite=thisCard[0].thisImage;

        nameText.text=""+cardName;
        costText.text=""+cost;
        staminaText.text=""+stamina;
        attackText.text=""+attack;
        healthText.text=""+health;
        descriptionText.text=""+cardDescription;

        thatImage.sprite=thisSprite;
    }
}
