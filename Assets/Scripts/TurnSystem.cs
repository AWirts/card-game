using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnSystem : MonoBehaviour
{
    public bool isYourTurn;
    public int yourTurn;
    public int yourOpponentTurn;

    public TextMeshProUGUI turnText;

    public int maxStamina;
    public static int currentStamina;
    public TextMeshProUGUI staminaText;


    // Start is called before the first frame update
    void Start()
    {
        isYourTurn = true;
        yourTurn = -1;
        yourOpponentTurn = 0;
        maxStamina = 1;
        currentStamina = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if(isYourTurn == true)
        {
            turnText.text = "Your Turn";
        }
        else
        {
            turnText.text = "Opponent Turn";
        }
        staminaText.text = currentStamina + "/" + maxStamina;
    }

    public void EndYourTurn()
    {
        if(isYourTurn){
            isYourTurn = false;
        yourOpponentTurn += 1;
        }
    }

    public void EndYourOpponentTurn()
    {
        if(!isYourTurn)
        {
            isYourTurn = true;
            yourTurn += 1;

            maxStamina += 1;
            currentStamina = maxStamina;
        }
    }
}

