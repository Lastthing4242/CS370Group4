/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public GameManager GameManager;
    public int Id;
    public string CardName;
    public int CardHealth;
    public int CardPower;
    public GameObject card;
    public GameObject MagicalMysteryCardObject;


    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 54; i++)
        {
            Debug.Log(gameObject);
            Debug.Log(GameManager.CardList[i].getCard());
            if (gameObject == GameManager.CardList[i].getCard())
            {
                card = gameObject;
                Id = GameManager.CardList[i].getId();
                CardHealth = GameManager.CardList[i].getHealth();
                CardPower = GameManager.CardList[i].getPower();
                CardName = GameManager.CardList[i].getName();
            }
        }
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
*/