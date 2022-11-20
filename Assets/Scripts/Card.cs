using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Card
{
    public int id;
    public string cardName;
    public string cardDescription;
    public int cost;
    public int stamina;
    public int attack;
    public int health;
    public Sprite thisImage;

    public Card ()
    {
        
    }
    public Card(int Id, string CardName, int Cost, int Stamina, int Attack, int Health, string CardDescription, Sprite ThisImage)
    {
        id=Id;
        cardName=CardName;
        cost=Cost;
        stamina=Stamina;
        attack=Attack;
        health=Health;
        cardDescription=CardDescription;

        thisImage = ThisImage;
    }
   
}
