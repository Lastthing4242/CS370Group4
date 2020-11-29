using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
	// commented out because second card was throwing errors
	
	/*
    public GameManager GameManager;
    public CardStats CardStats;
    public GameObject Canvas;
    public bool foundCard = false;

    private GameObject bigCard;

    public void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }

    public void zoomOnHover()
    {
        int i = 0;
        foundCard = false;
        while (!foundCard)
        {
            if (gameObject.GetComponent<CardStats>().getId() == GameManager.CardList[i].getId())
            {
                bigCard = Instantiate(GameManager.CardList[i].getCard(), new Vector2(Input.mousePosition.x, Input.mousePosition.y + 250), Quaternion.identity);
                bigCard.transform.SetParent(Canvas.transform, true);
                bigCard.layer = LayerMask.NameToLayer("Zoom");

                RectTransform rect = bigCard.GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(240, 344);
                foundCard = true;
            }
            else
            {
                if (i == 53)
                {
                    i = 0;
                    foundCard = true;//this is a lie. I should really throw an error, but I don't think that's a good idea.
                }
                else
                {
                    i++;
                }
            }
        }
    }

    public void offHover()
    {
        Destroy(bigCard);
    }
*/
}
