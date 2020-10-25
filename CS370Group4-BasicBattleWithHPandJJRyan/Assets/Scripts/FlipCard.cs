using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipCard : MonoBehaviour
{

    public Sprite CardFace;
    public Sprite CardRear;

    public void Flip()
    {
        Sprite currentSprite = gameObject.GetComponent<Image>().sprite;

        if (currentSprite == CardFace)
        {
            gameObject.GetComponent<Image>().sprite = CardRear;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = CardFace;
        }
    }

}
