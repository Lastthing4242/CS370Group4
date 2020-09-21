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

    public CardStats()//this showed up in the video I saw on how to do this, so I left it here
        {


        }

    public CardStats(int id, string name, int health, int power)//this doesn't help here, but helps log all the cards in general
    {
        Id = id;
        CardName = name;
        CardHealth = health;
        CardPower = power;



    }
}
