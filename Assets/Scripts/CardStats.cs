﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Mirror;

public class CardStats : NetworkBehaviour
{
    public PlayerManager playermanager;

    
    // this is where the variables are defined
    public int Id;
    public string CardName;
    public int CardHealth;
    public int CardPower;
    public GameObject card;
    public char suit;
    public bool InDeck;
    bool attached = false;

    public CardStats()//this showed up in the video I saw on how to do this, so I left it here
        {


        }

    public CardStats(int id, string name, int health, int power, GameObject Card, char Suit, bool inDeck)//this doesn't help here, but helps log all the cards in general
    {
        Id = id;
        CardName = name;
        CardHealth = health;
        CardPower = power;
        card = Card;
        suit = Suit;
        InDeck = inDeck;
    }

    public void EasySet(CardStats x)//this doesn't help here, but helps log all the cards in general
    {
        Id = x.getId();
        CardName = x.getName();
        CardHealth = x.getHealth();
        CardPower = x.getPower();
        card = x.getCard();
        suit = x.getSuit();
        InDeck = x.InDeck;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playermanager = networkIdentity.GetComponent<PlayerManager>();
      

           
                if (suit == 'w')
                {
                    CardPower = CardPower + 2;
                }
                if (suit == 'u')
                {
                    CardHealth = CardHealth + 2;
                }
                if (suit == 'l')
                {
                    CardHealth = CardHealth + 1;
                    CardPower = CardPower + 1;   
                }
                if (suit == 'o')
                {
                    int health = playermanager.EnemyHealth.gameObject.GetComponent<HealthScript>().getHealth();
                    health = health - 2;
                    playermanager.SetHealth(health, "EnemyHit");
                }
     
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playermanager = networkIdentity.GetComponent<PlayerManager>();

        if (suit == 'w')
        {
            CardPower = CardPower - 2;
        }
        if (suit == 'u')
        {
            CardHealth = CardHealth - 2;
        }
        if(suit == 'l')
        {
            CardHealth = CardHealth - 1;
            CardPower = CardPower - 1;
        }
        if (suit == 'o')
        {
            int health = playermanager.EnemyHealth.gameObject.GetComponent<HealthScript>().getHealth();
            health = health + 2;
            playermanager.SetHealth(health, "EnemyHit");
        }
    }



    public void setHealth(int NewHealth)
    {
        CardHealth = NewHealth;
    }

    public void setInDeck(bool StateChanger)
    {
        InDeck = StateChanger;
    }

    public bool getInDeck()
    {
        return InDeck;
    }

    public char getSuit()
    {
        return suit;
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
