using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DragDrop : NetworkBehaviour
{
    public GameObject Canvas;
    //public GameObject DropZone;
    public PlayerManager PlayerManager;
	
	//Probably dont need
	public GameObject PlayerSlot1;
	public GameObject PlayerSlot2;
	public GameObject PlayerSlot3;
	public GameObject PlayerSlot4;
	public GameObject PlayerSlot5;
	public GameObject EnemySlot1;
	public GameObject EnemySlot2;
	public GameObject EnemySlot3;
	public GameObject EnemySlot4;
	public GameObject EnemySlot5;
	// until here

    private bool isDragging = false;
    private bool isOverDropZone = false;
    private bool isDraggable = true;
    private GameObject dropZone;
    private GameObject StartParent;
    private Vector2 startPosition;

    public void Start()
    {
        Canvas = GameObject.Find("Main Canvas");
        //DropZone = GameObject.Find("DropZone");
        if (!hasAuthority)
        {
            isDraggable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }

	// Added conditional on tag of slot
    private void OnCollisionEnter2D(Collision2D collision)
    {
		if(collision.gameObject.tag == "EmptySlot")
		{
			isOverDropZone = true;
			dropZone = collision.gameObject;
		}  
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {
        if (!isDraggable) return;
        StartParent = transform.parent.gameObject;
        startPosition = transform.position;
        isDragging = true;
    }

    public void EndDrag()
    {
        if (!isDraggable) return;
        isDragging = false;
        if (isOverDropZone)
        {
            transform.SetParent(dropZone.transform, false);
			// move to PlayerManager RpCShowCard()
			//dropZone.tag = "FullSlot";
            isDraggable = false;
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            PlayerManager = networkIdentity.GetComponent<PlayerManager>();
			//Changed call to include dropzone
            PlayerManager.PlayCard(gameObject, dropZone);
            PlayerManager.CmdDealCards();
			
        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(StartParent.transform, false);
        }
    }
}

