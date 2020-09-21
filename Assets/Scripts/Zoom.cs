using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public GameObject Canvas;

    private GameObject bigCard;

    public void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }

    public void zoomOnHover()
    {
        bigCard = Instantiate(gameObject, new Vector2(Input.mousePosition.x, Input.mousePosition.y + 250), Quaternion.identity);
        bigCard.transform.SetParent(Canvas.transform, true);
        bigCard.layer = LayerMask.NameToLayer("Zoom");

        RectTransform rect = bigCard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(240, 344);
    }

    public void offHover()
    {
        Destroy(bigCard);
    }

}
