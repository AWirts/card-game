using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ThisCard : MonoBehaviour
{
    private Card thisCard = new Card ();
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

    public bool cardBack;
    public bool canBeSummon;
    public bool summoned;
    public static bool staticCardBack;


    public GameObject Hand;
    public GameObject battleZone;
    public int numberOfCardsInDeck;


    // Start is called before the first frame update
    void Start()
    {
        thisCard = CardDatabase.cardList[thisId];
        numberOfCardsInDeck = PlayerDeck.deckSize;
        canBeSummon = false;
        summoned = false;
    }

    void Update()
    {
        id = thisCard.id;
        cardName = thisCard.cardName;
        cost=thisCard.cost;
        stamina=thisCard.stamina;
        attack=thisCard.attack;
        health=thisCard.health;
        cardDescription=thisCard.cardDescription;
        thisSprite=thisCard.thisImage;

        nameText.text=""+cardName;
        costText.text=""+cost;
        staminaText.text=""+stamina;
        attackText.text=""+attack;
        healthText.text=""+health;
        descriptionText.text=""+cardDescription;

        thatImage.sprite=thisSprite;
        staticCardBack = cardBack;

        if(this.tag == "Clone")
        {
            thisCard = PlayerDeck.staticDeck[numberOfCardsInDeck-1];
            numberOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";
        }
        if(TurnSystem.currentStamina >= cost && summoned == false)
        {
            canBeSummon = true;
            gameObject.GetComponent<Draggable>().enabled = true;
        }
        else 
        {
            canBeSummon = false;
            gameObject.GetComponent<Draggable>().enabled = false;
        }

        battleZone = GameObject.Find("Zone");

        if(summoned == false && this.transform.parent == battleZone.transform)
        {
            Summon();
        }
    }
    
    public void Summon()
    {
        TurnSystem.currentStamina -= cost;
        summoned = true;
    }
}