using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
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
    public bool triggered = false;// checks to see if the card has triggered its ability
    public bool enemyCard = false;
    public bool playerCard = false;

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

   void Update()
    {
        if (card.transform.IsChildOf(GameObject.Find("PlayerArea").transform) && !playerCard)
        {
            Debug.Log("im a player card my id is" + Id);
            playerCard = true;
        }
        else if (card.transform.IsChildOf(GameObject.Find("OpponentArea").transform) && !enemyCard)
        {
            Debug.Log("im a enemy card my id is" + Id);
            enemyCard = true;
        }
        if (triggered == false && GameObject.Find("TurnText").GetComponent<Text>().text == "ETB Triggers")//this triggers all of the abilities currently
        {
            Debug.Log("im using my ability my id is" + Id);
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            playermanager = networkIdentity.GetComponent<PlayerManager>();

            if (suit == 'o')
            {
                if (enemyCard)
                {
                    int health = playermanager.PlayerHealth.gameObject.GetComponent<HealthScript>().getHealth();
                    health = health - 2;
                    playermanager.PlayerHealth.gameObject.GetComponent<HealthScript>().setHealth(health);
                    playermanager.SetHealth(health, "PlayerHit");
                    triggered = true;
                }
                else if (playerCard)
                {
                    int health = playermanager.EnemyHealth.gameObject.GetComponent<HealthScript>().getHealth();
                    health = health - 2;
                    playermanager.EnemyHealth.gameObject.GetComponent<HealthScript>().setHealth(health);
                    playermanager.SetHealth(health, "EnemyHit");
                    triggered = true;
                }
            }

            else if (suit == 'u')
            {             
                CardHealth = CardHealth + 2;
                triggered = true;
            }
            else if (suit == 'w')
            {
                CardPower = CardPower + 2;
                triggered = true;
                
            }
            else if (suit == 'l')
            {
                CardHealth++;
                CardPower++;
                triggered = true;
            }
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
