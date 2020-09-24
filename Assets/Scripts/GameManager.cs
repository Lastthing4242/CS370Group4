using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Mirror;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerLibraryText;
    public GameObject OpponentLibraryText;
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject Card5;
    public GameObject Card6;
    public GameObject Card7;
    public GameObject Card8;
    public GameObject Card9;
    public GameObject Card10;
    public GameObject Card11;
    public GameObject Card12;
    public GameObject Card13;
    public GameObject Card14;
    public GameObject Card15;
    public GameObject Card16;
    public GameObject Card17;
    public GameObject Card18;
    public GameObject Card19;
    public GameObject Card20;
    public GameObject Card21;
    public GameObject Card22;
    public GameObject Card23;
    public GameObject Card24;
    public GameObject Card25;
    public GameObject Card26;
    public GameObject Card27;
    public GameObject Card28;
    public GameObject Card29;
    public GameObject Card30;
    public GameObject Card31;
    public GameObject Card32;
    public GameObject Card33;
    public GameObject Card34;
    public GameObject Card35;
    public GameObject Card36;
    public GameObject Card37;
    public GameObject Card38;
    public GameObject Card39;
    public GameObject Card40;
    public GameObject Card41;
    public GameObject Card42;
    public GameObject Card43;
    public GameObject Card44;
    public GameObject Card45;
    public GameObject Card46;
    public GameObject Card47;
    public GameObject Card48;
    public GameObject Card49;
    public GameObject Card50;
    public GameObject Card51;
    public GameObject Card52;
    public GameObject Card53;
    public GameObject Card54;
    public int NameCheck = 10;

    public static List<GameObject> cards = new List<GameObject>();

    public static List<GameObject> BobCards = new List<GameObject>();
    public static List<GameObject> KarenCards = new List<GameObject>();


    public void Awake()
    {
        cards.Add(Card1);
        cards.Add(Card2);
        cards.Add(Card3);
        cards.Add(Card4);
        cards.Add(Card5);
        cards.Add(Card6);
        cards.Add(Card7);
        cards.Add(Card8);
        cards.Add(Card9);
        cards.Add(Card10);
        cards.Add(Card11);
        cards.Add(Card12);
        cards.Add(Card13);
        cards.Add(Card14);
        cards.Add(Card15);
        cards.Add(Card16);
        cards.Add(Card17);
        cards.Add(Card18);
        cards.Add(Card19);
        cards.Add(Card20);
        cards.Add(Card21);
        cards.Add(Card22);
        cards.Add(Card23);
        cards.Add(Card24);
        cards.Add(Card25);
        cards.Add(Card26);
        cards.Add(Card27);
        cards.Add(Card28);
        cards.Add(Card29);
        cards.Add(Card30);
        cards.Add(Card31);
        cards.Add(Card32);
        cards.Add(Card33);
        cards.Add(Card34);
        cards.Add(Card35);
        cards.Add(Card36);
        cards.Add(Card37);
        cards.Add(Card38);
        cards.Add(Card39);
        cards.Add(Card40);
        cards.Add(Card41);
        cards.Add(Card42);
        cards.Add(Card43);
        cards.Add(Card44);
        cards.Add(Card45);
        cards.Add(Card46);
        cards.Add(Card47);
        cards.Add(Card48);
        cards.Add(Card49);
        cards.Add(Card50);
        cards.Add(Card51);
        cards.Add(Card52);
        cards.Add(Card53);
        cards.Add(Card54);

        BobCards.Add(Card1);
        BobCards.Add(Card2);
        BobCards.Add(Card3);
        BobCards.Add(Card4);
        BobCards.Add(Card5);
        BobCards.Add(Card6);
        BobCards.Add(Card7);
        BobCards.Add(Card8);
        BobCards.Add(Card9);
        BobCards.Add(Card10);
        BobCards.Add(Card11);
        BobCards.Add(Card12);
        BobCards.Add(Card13);
        BobCards.Add(Card14);
        BobCards.Add(Card15);
        BobCards.Add(Card16);
        BobCards.Add(Card17);
        BobCards.Add(Card18);
        BobCards.Add(Card19);
        BobCards.Add(Card20);
        BobCards.Add(Card21);
        BobCards.Add(Card22);
        BobCards.Add(Card23);
        BobCards.Add(Card24);
        BobCards.Add(Card25);
        BobCards.Add(Card26);
        BobCards.Add(Card27);

        KarenCards.Add(Card28);
        KarenCards.Add(Card29);
        KarenCards.Add(Card30);
        KarenCards.Add(Card31);
        KarenCards.Add(Card32);
        KarenCards.Add(Card33);
        KarenCards.Add(Card34);
        KarenCards.Add(Card35);
        KarenCards.Add(Card36);
        KarenCards.Add(Card37);
        KarenCards.Add(Card38);
        KarenCards.Add(Card39);
        KarenCards.Add(Card40);
        KarenCards.Add(Card41);
        KarenCards.Add(Card42);
        KarenCards.Add(Card43);
        KarenCards.Add(Card44);
        KarenCards.Add(Card45);
        KarenCards.Add(Card46);
        KarenCards.Add(Card47);
        KarenCards.Add(Card48);
        KarenCards.Add(Card49);
        KarenCards.Add(Card50);
        KarenCards.Add(Card51);
        KarenCards.Add(Card52);
        KarenCards.Add(Card53);
        KarenCards.Add(Card54);


    }

    public string NameGenerator()
    {
        if(NameCheck == 10)
        {
            NameCheck--;
            return "Bob";
        }
        else
        {
            NameCheck++;
            return "Karen";
        }
    }

    public void UpdatePlayerText(int CardCount, string Name)
    {
        if (Name == "Bob")
        {
            PlayerLibraryText.GetComponent<Text>().text = "Cards left: " + CardCount;
        }
        else if (Name == "Karen")
        {
            OpponentLibraryText.GetComponent<Text>().text = "Cards left: " + CardCount;
        }
    }

    public void Shuffler<GameObject>()
    {
        System.Random random = new System.Random();
        int n = cards.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            UnityEngine.GameObject temp = cards[k];
            cards[k] = cards[n];
            cards[n] = temp;
        }
        for (int i = 0; i < cards.Count; i++)
        {
            if (i < 27)
            {
                BobCards[i] = cards[i];
            }
            else
            {
                KarenCards[i - 27] = cards[i];
            }
        }
    }

}
