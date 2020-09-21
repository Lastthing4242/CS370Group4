using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour
{
    public static List<CardStats> cardlist = new List<CardStats>();

    void Awake()//this is where the card's data goes
    {
        cardlist.Add(new CardStats(0, "two of coins",2, 2));//start of the 2 cards
        cardlist.Add(new CardStats(1, "two of cups", 2, 2));
        cardlist.Add(new CardStats(2, "two of swords", 2, 2));
        cardlist.Add(new CardStats(3, "two of clubs", 2, 2));
        cardlist.Add(new CardStats(4, "three of coins", 3, 3));//start of the 3 cards
        cardlist.Add(new CardStats(5,"three of cups", 3, 3));
        cardlist.Add(new CardStats(6, "three of swords", 3, 3));
        cardlist.Add(new CardStats(7, "three of clubs", 3, 3));
        cardlist.Add(new CardStats(8, "four of coins", 4, 4));//start of the 4 cards
        cardlist.Add(new CardStats(9, "four of cups", 4, 4));
        cardlist.Add(new CardStats(10, "four of swords", 4, 4));
        cardlist.Add(new CardStats(11, "four of clubs", 4, 4));
        cardlist.Add(new CardStats(12, "five of coins", 5, 5));//start of the 5 cards
        cardlist.Add(new CardStats(13, "five of cups", 5, 5));
        cardlist.Add(new CardStats(14, "five of swords", 5, 5));
        cardlist.Add(new CardStats(15, "five of clubs", 5, 5));

    }
}
