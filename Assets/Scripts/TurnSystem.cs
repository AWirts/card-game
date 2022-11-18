using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public bool isYourTurn;
    public int yourTurn;
    public int yourOpponentTurn;
    public Text turnText;

    public int maxMana;
    public static int currentMana;
    public Text manaText;

    // Start is called before the first frame update
    void Start()
    {
        isYourTurn = true;
        yourTurn = -1;
        yourOpponentTurn = 0;

        maxMana = 1;
        currentMana = 1;
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

        manaText.text = currentMana + "/" + maxMana;
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

            maxMana += 1;
            currentMana = maxMana;
        }
    }
}
