using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Mirror;

using UnityEngine.UI;
using System;

public class CardStats : NetworkBehaviour
{
    public PlayerManager playermanager;

    
    // this is where the variables are defined
    public int Id;
    public string CardName;
    public int CardHealth;
    public int CardPower;
    public GameObject card;
    public GameObject PlayerArea;
    public GameObject OpponentArea;
    public char suit;
    public bool InDeck;
    public bool triggered = false;// checks to see if the card has triggered its ability
    public bool enemyCard = false;//checks if its in the enmy hand
    public bool playerCard = false;//checks if its in host hand

    public GameObject OnCardHealth;
	public GameObject OnCardAttack;
	public Sprite AttackImage;
	public Sprite FullHealth;
	public Sprite HalfHealth;
	public Sprite QuarterHealth;
	public Sprite ThreeQuarterHealth;
	
	
	bool attached = false;
	int fullHealth;
	

    void Start()
    {
        PlayerArea = GameObject.Find("PlayerArea");
        OpponentArea = GameObject.Find("OpponentArea");
    }

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
		
		//Assign FullHealth for % calculation
		fullHealth = health;
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
        

        //Assign FullHealth for % calculation
        fullHealth = CardHealth;
        
    }

    void Update()
    {
        if (card != null)
        {
            if (card.gameObject.transform.parent==PlayerArea.transform && !playerCard)
            {
                Debug.Log("im a player card my id is" + Id);
                playerCard = true;
            }
            else if (card.gameObject.transform.parent==OpponentArea.transform && !enemyCard)
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
            SetOnCardStats(card);
        }

        
    }

    // There's got to be a better way to set this, but I can't figuer it out without setting on each prefab (being lazy)
    // It doesn't seem like the easySet() and CardStats() methods are doing anything??
    // Is everything set on the prefabs themselves and not here??
    public void SetFullHealth(GameObject card)
	{
		card.gameObject.GetComponent<CardStats>().fullHealth = CardHealth;
	}

   
	
	//sets the OnCardStats to above variables
	// Call this method, passing the card you want updated anytime changes are made to card stats (i.e. attacked, enhanced, ect)
	public void SetOnCardStats(GameObject card)
	{
		
		card.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + CardHealth;
		card.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + CardPower;
		//gameObject.GetComponent<Text>().text = "" + CardHealth;
		//gameObject.GetComponent<Text>().text = "" + CardPower;
		
		
		float pH = (float)CardHealth / (float)fullHealth;
		int percentHealth = (int)(100 * pH);
		Debug.Log("CARD HEALTH = " + CardHealth);
		Debug.Log("FULL HEALTH = " + fullHealth);
		Debug.Log("FLOAT pH = " + pH);
		Debug.Log("PERCENT HEALTH = " + percentHealth);
		
		while(true)
		{
			if(percentHealth > 75)
			{
				card.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = FullHealth;
				break;
			}
			if(percentHealth > 50)
			{
				card.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = ThreeQuarterHealth;
				break;
			}
			if(percentHealth > 25)
			{
				card.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = HalfHealth;
				break;
			}
			if(percentHealth >= 0)
			{
				card.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = QuarterHealth;
				break;
			}
		}
	}

   


    // Just wondering why we have setter/getter methods for public variables??
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
