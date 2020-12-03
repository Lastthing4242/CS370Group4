using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
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
    public char suit;
    public bool InDeck;
    public bool triggered = false;// checks to see if the card has triggered its ability
    public bool enemyCard = false;
    public bool playerCard = false;

	public GameObject OnCardHealth;
	public GameObject OnCardAttack;
	
	public Sprite AttackImage;
	public Sprite FullHealth;
	public Sprite HalfHealth;
	public Sprite QuarterHealth;
	public Sprite ThreeQuarterHealth;
	public Sprite EmptyHealth;
	
	bool attached = false;
	int fullHealth;
	
	// Add variables to hold current enhancements
	int healthBoost = 0;
	int powerBoost = 0;
	
	// Add variables to hold current totals
	int currentHealth;
	int currentPower;

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
		if(playermanager == null)
		{
			NetworkIdentity networkIdentity = NetworkClient.connection.identity;
			playermanager = networkIdentity.GetComponent<PlayerManager>();
		}			
		
        if (card.transform.IsChildOf(GameObject.Find("PlayerArea").transform) && !playerCard)
        {
            //Debug.Log("im a player card my id is" + Id);
            playerCard = true;
        }
        else if (card.transform.IsChildOf(GameObject.Find("OpponentArea").transform) && !enemyCard)
        {
            //Debug.Log("im a enemy card my id is" + Id);
            enemyCard = true;
        }
		
		// This code seems to be broken, since re-implementation of the trun order.
		// Player health does not decrement approptiately.
		// Set to false && ...
		// to deactivate
        if (false && triggered == false && GameObject.Find("TurnText").GetComponent<Text>().text == "Waiting")//this triggers all of the abilities currently
        {
            //Debug.Log("im using my ability my id is" + Id);
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            playermanager = networkIdentity.GetComponent<PlayerManager>();

            if (suit == 'o')
            {
                if (enemyCard)
                {
                    int health = playermanager.PlayerHealth.gameObject.GetComponent<HealthScript>().getHealth();
                    health = health - 2;
                    //playermanager.PlayerHealth.gameObject.GetComponent<HealthScript>().setHealth(health);
                    playermanager.SetHealth(health, "PlayerHit");
                    triggered = true;
                }
                else if (playerCard)
                {
                    int health = playermanager.EnemyHealth.gameObject.GetComponent<HealthScript>().getHealth();
                    health = health - 2;
                    //playermanager.EnemyHealth.gameObject.GetComponent<HealthScript>().setHealth(health);
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
		
		// -------------------------------------5 CARD ABILITY---------------------------------------------------------
		// This is the 5 cards ability to enhance attack power by 1 for each friendly face card
		//  These variables need to be used during battle - they are not currently now
		if(Id >= 13 && Id <= 16)
		{
			int boost = 0;
			if(playerCard)
			{
				for(int j = 0; j < playermanager.PlayerSockets.Count; j++)
				{
					if(playermanager.PlayerSockets[j].gameObject.tag == "FullSlot")
					{
						int otherCard = playermanager.PlayerSockets[j].transform.GetChild(0).gameObject.GetComponent<CardStats>().Id;
						if(otherCard >= 37 && otherCard <= 48)
						{
							boost++;
						}
					}
				}
			}
			if(enemyCard)
			{
				for(int j = 0; j < playermanager.EnemySockets.Count; j++)
				{
					if(playermanager.EnemySockets[j].gameObject.tag == "FullSlot")
					{
						int otherCard = playermanager.EnemySockets[j].transform.GetChild(0).gameObject.GetComponent<CardStats>().Id;
						if(otherCard >= 37 && otherCard <= 48)
						{
							boost++;
						}
					}
				}
			}
			
			
			// Set the boost value
			// this must be the cumulative boost for all enhancements
			healthBoost = boost;
		}
		
		if(card.transform.childCount != 0)
		{
			SetOnCardStats();
		}
     }
    

	// There's got to be a better way to set this, but I can't figuer it out without setting on each prefab (being lazy)
	// It doesn't seem like the easySet() and CardStats() methods are doing anything??
	// Is everything set on the prefabs themselves and not here??
	public void SetFullHealth()
	{
		//card.gameObject.GetComponent<CardStats>().fullHealth = CardHealth;
		fullHealth = CardHealth;
		//currentHealth = CardHealth;
		//currentPower = CardPower;
	}
	
	//sets the OnCardStats to above variables
	// Call this method, anytime changes are made to card stats (i.e. attacked, enhanced, ect)
	public void SetOnCardStats()
	{
		
		card.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + (CardHealth + healthBoost);
		card.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + (CardPower + powerBoost);
		
		float pH = (float)(CardHealth + healthBoost) / (float)fullHealth;
		int percentHealth = (int)(100 * pH);
		
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
			if(percentHealth > 0)
			{
				card.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = QuarterHealth;
				break;
			}
			// Just in case of negative value
			else
			{
				card.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = EmptyHealth;
				break;
			}
		}
	}
	
	
	// Just wondering why we have setter/getter methods for public variables??
	
	// Include call to update OnCardStats here
    public void setHealth(int NewHealth)
    {
        CardHealth = NewHealth;
		SetOnCardStats();	
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
