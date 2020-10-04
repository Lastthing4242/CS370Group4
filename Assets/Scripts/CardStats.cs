using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Mirror;

public class CardStats : MonoBehaviour
{
    // this is where the variables are defined
    public int Id;
    public string CardName;
    public int CardHealth;
    public int CardPower;
    public GameObject card;

    public CardStats()//this showed up in the video I saw on how to do this, so I left it here
        {


        }

    public CardStats(int id, string name, int health, int power, GameObject Card)//this doesn't help here, but helps log all the cards in general
    {
        Id = id;
        CardName = name;
        CardHealth = health;
        CardPower = power;
        card = Card;
    }

    public void EasySet(CardStats x)//this doesn't help here, but helps log all the cards in general
    {
        Id = x.getId();
        CardName = x.getName();
        CardHealth = x.getHealth();
        CardPower = x.getPower();
        card = x.getCard();
    }

    public GameObject getCard()
    {
        return card;
    }

    public int getId()
    {
        return Id;
    }

    public int getHealth()
    {
        return CardHealth;
    }

    public int getPower()
    {
        return CardPower;
    }

    public string getName()
    {
        return CardName;
    }
}
