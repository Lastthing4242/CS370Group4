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

    public static List<CardStats> CardList = new List<CardStats>();


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


        CardList.Add(new CardStats(1, "two of coins", 2, 2, Card1));//start of the 2 cards
        CardList.Add(new CardStats(2, "two of cups", 2, 2, Card2));
        CardList.Add(new CardStats(3, "two of swords", 2, 2, Card3));
        CardList.Add(new CardStats(4, "two of clubs", 2, 2, Card4));
        CardList.Add(new CardStats(5, "three of coins", 3, 3, Card5));//start of the 3 cards
        CardList.Add(new CardStats(6, "three of cups", 3, 3, Card6));
        CardList.Add(new CardStats(7, "three of swords", 3, 3, Card7));
        CardList.Add(new CardStats(8, "three of clubs", 3, 3, Card8));
        CardList.Add(new CardStats(9, "four of coins", 4, 4, Card9));//start of the 4 cards
        CardList.Add(new CardStats(10, "four of cups", 4, 4, Card10));
        CardList.Add(new CardStats(11, "four of swords", 4, 4, Card11));
        CardList.Add(new CardStats(12, "four of clubs", 4, 4, Card12));
        CardList.Add(new CardStats(13, "five of coins", 5, 5, Card13));//start of the 5 cards
        CardList.Add(new CardStats(14, "five of cups", 5, 5, Card14));
        CardList.Add(new CardStats(15, "five of swords", 5, 5, Card15));
        CardList.Add(new CardStats(16, "five of clubs", 5, 5, Card16));
        CardList.Add(new CardStats(17, "six of coins", 6, 6, Card17));//start of the 6 cards
        CardList.Add(new CardStats(18, "six of cups", 6, 6, Card18));
        CardList.Add(new CardStats(19, "six of swords", 6, 6, Card19));
        CardList.Add(new CardStats(20, "six of clubs", 6, 6, Card20));
        CardList.Add(new CardStats(21, "seven of coins", 7, 7, Card21));//start of the 7 cards
        CardList.Add(new CardStats(22, "seven of cups", 7, 7, Card22));
        CardList.Add(new CardStats(23, "seven of swords", 7, 7, Card23));
        CardList.Add(new CardStats(24, "seven of clubs", 7, 7, Card24));
        CardList.Add(new CardStats(25, "eight of coins", 8, 8, Card25));//start of the 8 cards
        CardList.Add(new CardStats(26, "eight of cups", 8, 8, Card26));
        CardList.Add(new CardStats(27, "eight of swords", 8, 8, Card27));
        CardList.Add(new CardStats(28, "eight of clubs", 8, 8, Card28));
        CardList.Add(new CardStats(29, "nine of coins", 9, 9, Card29));//start of the 9 cards
        CardList.Add(new CardStats(30, "nine of cups", 9, 9, Card30));
        CardList.Add(new CardStats(31, "nine of swords", 9, 9, Card31));
        CardList.Add(new CardStats(32, "nine of clubs", 9, 9, Card32));
        CardList.Add(new CardStats(33, "ten of coins", 10, 10, Card33));//start of the 10 cards
        CardList.Add(new CardStats(34, "ten of cups", 10, 10, Card34));
        CardList.Add(new CardStats(35, "ten of swords", 10, 10, Card35));
        CardList.Add(new CardStats(36, "ten of clubs", 10, 10, Card36));
        CardList.Add(new CardStats(37, "Jack of coins", 11, 11, Card37));//start of the J cards
        CardList.Add(new CardStats(38, "Jack of cups", 11, 11, Card38));
        CardList.Add(new CardStats(39, "Jack of swords", 11, 11, Card39));
        CardList.Add(new CardStats(40, "Jack of clubs", 11, 11, Card40));
        CardList.Add(new CardStats(41, "Queen of coins", 12, 12, Card41));//start of the Q cards
        CardList.Add(new CardStats(42, "Queen of cups", 12, 12, Card42));
        CardList.Add(new CardStats(43, "Queen of swords", 12, 12, Card43));
        CardList.Add(new CardStats(44, "Queen of clubs", 12, 12, Card44));
        CardList.Add(new CardStats(45, "King of coins", 13, 13, Card45));//start of the K cards
        CardList.Add(new CardStats(46, "King of cups", 13, 13, Card46));
        CardList.Add(new CardStats(47, "King of swords", 13, 13, Card47));
        CardList.Add(new CardStats(48, "King of clubs", 13, 13, Card48));
        CardList.Add(new CardStats(49, "Ace of coins", 14, 14, Card49));//start of the A cards
        CardList.Add(new CardStats(50, "Ace of cups", 14, 14, Card50));
        CardList.Add(new CardStats(51, "Ace of swords", 14, 14, Card51));
        CardList.Add(new CardStats(52, "Ace of clubs", 14, 14, Card52));
        CardList.Add(new CardStats(53, "Jesdter of Chaos", 15, 15, Card53));//start of the Jesters cards
        CardList.Add(new CardStats(54, "Jester of Order", 15, 15, Card54));

        //

        Card1.GetComponent<CardStats>().EasySet(CardList[0]);
        Card2.GetComponent<CardStats>().EasySet(CardList[1]);
        Card3.GetComponent<CardStats>().EasySet(CardList[2]);
        Card4.GetComponent<CardStats>().EasySet(CardList[3]);
        Card5.GetComponent<CardStats>().EasySet(CardList[4]);
        Card6.GetComponent<CardStats>().EasySet(CardList[5]);
        Card7.GetComponent<CardStats>().EasySet(CardList[6]);
        Card8.GetComponent<CardStats>().EasySet(CardList[7]);
        Card9.GetComponent<CardStats>().EasySet(CardList[8]);
        Card10.GetComponent<CardStats>().EasySet(CardList[9]);
        Card11.GetComponent<CardStats>().EasySet(CardList[10]);
        Card12.GetComponent<CardStats>().EasySet(CardList[11]);
        Card13.GetComponent<CardStats>().EasySet(CardList[12]);
        Card14.GetComponent<CardStats>().EasySet(CardList[13]);
        Card15.GetComponent<CardStats>().EasySet(CardList[14]);
        Card16.GetComponent<CardStats>().EasySet(CardList[15]);
        Card17.GetComponent<CardStats>().EasySet(CardList[16]);
        Card18.GetComponent<CardStats>().EasySet(CardList[17]);
        Card19.GetComponent<CardStats>().EasySet(CardList[18]);
        Card20.GetComponent<CardStats>().EasySet(CardList[19]);
        Card21.GetComponent<CardStats>().EasySet(CardList[20]);
        Card22.GetComponent<CardStats>().EasySet(CardList[21]);
        Card23.GetComponent<CardStats>().EasySet(CardList[22]);
        Card24.GetComponent<CardStats>().EasySet(CardList[23]);
        Card25.GetComponent<CardStats>().EasySet(CardList[24]);
        Card26.GetComponent<CardStats>().EasySet(CardList[25]);
        Card27.GetComponent<CardStats>().EasySet(CardList[26]);
        Card28.GetComponent<CardStats>().EasySet(CardList[27]);
        Card29.GetComponent<CardStats>().EasySet(CardList[28]);
        Card30.GetComponent<CardStats>().EasySet(CardList[29]);
        Card31.GetComponent<CardStats>().EasySet(CardList[30]);
        Card32.GetComponent<CardStats>().EasySet(CardList[31]);
        Card33.GetComponent<CardStats>().EasySet(CardList[32]);
        Card34.GetComponent<CardStats>().EasySet(CardList[33]);
        Card35.GetComponent<CardStats>().EasySet(CardList[34]);
        Card36.GetComponent<CardStats>().EasySet(CardList[35]);
        Card37.GetComponent<CardStats>().EasySet(CardList[36]);
        Card38.GetComponent<CardStats>().EasySet(CardList[37]);
        Card39.GetComponent<CardStats>().EasySet(CardList[38]);
        Card40.GetComponent<CardStats>().EasySet(CardList[39]);
        Card41.GetComponent<CardStats>().EasySet(CardList[40]);
        Card42.GetComponent<CardStats>().EasySet(CardList[41]);
        Card43.GetComponent<CardStats>().EasySet(CardList[42]);
        Card44.GetComponent<CardStats>().EasySet(CardList[43]);
        Card45.GetComponent<CardStats>().EasySet(CardList[44]);
        Card46.GetComponent<CardStats>().EasySet(CardList[45]);
        Card47.GetComponent<CardStats>().EasySet(CardList[46]);
        Card48.GetComponent<CardStats>().EasySet(CardList[47]);
        Card49.GetComponent<CardStats>().EasySet(CardList[48]);
        Card50.GetComponent<CardStats>().EasySet(CardList[49]);
        Card51.GetComponent<CardStats>().EasySet(CardList[50]);
        Card52.GetComponent<CardStats>().EasySet(CardList[51]);
        Card53.GetComponent<CardStats>().EasySet(CardList[52]);
        Card54.GetComponent<CardStats>().EasySet(CardList[53]);
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
