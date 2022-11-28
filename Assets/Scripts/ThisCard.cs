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

    public GameObject attackBorder;
    public GameObject Target;
    public GameObject Enemy;

    public bool summoningSickness;
    public static bool staticTargeting;
    public static bool staticTargetingEnemy;

    public bool canAttack;
    public bool attackedThisTurn;
    public bool targeting;
    public bool targetingEnemy;
    public bool onlyThisCardAttack;

    // Start is called before the first frame update
    void Start()
    {
        thisCard = CardDatabase.cardList[thisId];
        numberOfCardsInDeck = PlayerDeck.deckSize;
        canBeSummon = false;
        summoned = false;

        canAttack = false;
        summoningSickness = true;
        Enemy = GameObject.Find("OpponentHP");
        targeting=false;
        targetingEnemy=false;
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

        if(canAttack==true)
        {
            attackBorder.SetActive(true);
        }else
        {
            attackBorder.SetActive(false);
        }

        if(TurnSystem.isYourTurn == false && summoned == true)
        {
            summoningSickness = false;
        }

        if(TurnSystem.isYourTurn == true && summoningSickness==false && attackedThisTurn == false)
        {
            canAttack=true;
        }
        else{
            canAttack=false;
        }

        targeting=staticTargeting;
        targetingEnemy=staticTargetingEnemy;

        if(targetingEnemy==true)
        {
            Target=Enemy;
        }
        else{
            Target=null;
        }
        if(targeting==true && targetingEnemy == true && onlyThisCardAttack == true)
        {
            Attack();
        }
    }
    
    public void Summon()
    {
        TurnSystem.currentStamina -= cost;
        summoned = true;
    }
    public void Attack()
    {
        if(canAttack)
        {
            if(Target != null)
            {
                if(Target==Enemy)
                {
                    OpponentHP.staticHP-=attack;
                    targeting=false;
                    canAttack=false;
                    attackedThisTurn=true;
                }
            }
        }
    }
    public void UntargetEnemy()
    {
        staticTargetingEnemy=false;
    }
    public void TargetEnemy()
    {
        staticTargetingEnemy=true;
    }
    public void StartAttack()
    {
        staticTargeting=true;
    }
    public void StopAttack()
    {
        staticTargeting=false;
    }
    public void OneCardAttackStart()
    {
        onlyThisCardAttack=true;
    }
    public void OneCardAttackStop()
    {
        onlyThisCardAttack=false;
    }
}