using UnityEngine;
using System.Collections;

public enum buttonState
{
    left,
    right
}

public class TurnPageButton : MonoBehaviour {

    [SerializeField]buttonState curButtonState;
    GameObject bookController;



	// Use this for initialization
	void Start ()
    {
        bookController = GameObject.Find("BookControlls");
	}
	
	// Update is called once per frame
	void Update ()
    {
       if(bookController.GetComponent<BookContolls>().canTurn(curButtonState))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
       else
        {
            GetComponent<MeshRenderer>().material.color = Color.gray;
        } 
    }

    void OnMouseDown()
    {
        if(curButtonState == buttonState.left)
        {
            bookController.GetComponent<BookContolls>().TurnPageDec();
        }
        else
        {
            bookController.GetComponent<BookContolls>().TurnPageInc();
        }


    }
}
