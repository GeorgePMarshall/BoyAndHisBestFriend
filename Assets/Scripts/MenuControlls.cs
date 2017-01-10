using UnityEngine;
using System.Collections;
using System;

public class MenuControlls : MonoBehaviour {




    bookState curState;
    GameObject menuController;


    [SerializeField]Transform frontCoverTransform;
    [SerializeField]Transform page0Transform;
    [SerializeField]Transform page1Transform;
    [SerializeField]Transform page2Transform;
    [SerializeField]Transform page3Transform;
    [SerializeField]Transform page4Transform;

    [SerializeField]Transform frontCoverClosedTrasform;
    [SerializeField]Transform frontCoverOpenTransform;
    [SerializeField]Transform page0OpenTransform;
    [SerializeField]Transform page0ClosedTransform;
    [SerializeField]Transform page1OpenTransform;
    [SerializeField]Transform page1ClosedTransform;
    [SerializeField]Transform page2OpenTransform;
    [SerializeField]Transform page2ClosedTransform;
    [SerializeField]Transform page3OpenTransform;
    [SerializeField]Transform page3ClosedTransform;
    [SerializeField]Transform page4OpenTransform;
    [SerializeField]Transform page4ClosedTransform;

    [SerializeField]GameObject[] closedObjects; 
    [SerializeField]GameObject[] page0Text; 
    [SerializeField]GameObject[] page1Text; 
    [SerializeField]GameObject[] page2Text; 
    [SerializeField]GameObject[] page3Text; 
    [SerializeField]GameObject[] page4Text;
    [SerializeField]GameObject[] page5Text;

    int enumSize;

	// Use this for initialization
	void Start ()
    {
        enumSize = Enum.GetNames(typeof(bookState)).Length;
        menuController = GameObject.Find("BookControlls");
    }
	
	// Update is called once per frame
	void Update ()
    {
        curState = menuController.GetComponent<BookContolls>().curState;

        //lerps the pages to their intended location based on their state
        switch (curState)
        {
            case bookState.closed:
                {
                    frontCoverTransform.rotation = Quaternion.RotateTowards(frontCoverTransform.rotation, frontCoverClosedTrasform.rotation, 1.0f);
                    page0Transform.rotation = Quaternion.RotateTowards(page0Transform.rotation, page0OpenTransform.rotation, 1.0f);
                    page1Transform.rotation = Quaternion.RotateTowards(page1Transform.rotation, page1OpenTransform.rotation, 1.0f);
                    page2Transform.rotation = Quaternion.RotateTowards(page2Transform.rotation, page2OpenTransform.rotation, 1.0f);
                    page3Transform.rotation = Quaternion.RotateTowards(page3Transform.rotation, page3OpenTransform.rotation, 1.0f);
                    page4Transform.rotation = Quaternion.RotateTowards(page4Transform.rotation, page4OpenTransform.rotation, 1.0f);

                    break;
                }
            case bookState.page0:
                {
                    frontCoverTransform.rotation = Quaternion.RotateTowards(frontCoverTransform.rotation, frontCoverOpenTransform.rotation, 1.0f);
                    page0Transform.rotation = Quaternion.RotateTowards(page0Transform.rotation, page0OpenTransform.rotation, 1.0f);
                    page1Transform.rotation = Quaternion.RotateTowards(page1Transform.rotation, page1OpenTransform.rotation, 1.0f);
                    page2Transform.rotation = Quaternion.RotateTowards(page2Transform.rotation, page2OpenTransform.rotation, 1.0f);
                    page3Transform.rotation = Quaternion.RotateTowards(page3Transform.rotation, page3OpenTransform.rotation, 1.0f);
                    page4Transform.rotation = Quaternion.RotateTowards(page4Transform.rotation, page4OpenTransform.rotation, 1.0f);

                    break;
                }
            case bookState.page1:
                {
                    frontCoverTransform.rotation = Quaternion.RotateTowards(frontCoverTransform.rotation, frontCoverOpenTransform.rotation, 1.0f);
                    page0Transform.rotation = Quaternion.RotateTowards(page0Transform.rotation, page0ClosedTransform.rotation, 1.0f);
                    page1Transform.rotation = Quaternion.RotateTowards(page1Transform.rotation, page1OpenTransform.rotation, 1.0f);
                    page2Transform.rotation = Quaternion.RotateTowards(page2Transform.rotation, page2OpenTransform.rotation, 1.0f);
                    page3Transform.rotation = Quaternion.RotateTowards(page3Transform.rotation, page3OpenTransform.rotation, 1.0f);
                    page4Transform.rotation = Quaternion.RotateTowards(page4Transform.rotation, page4OpenTransform.rotation, 1.0f);
                    break;
                }
            case bookState.page2:
                {
                    frontCoverTransform.rotation = Quaternion.RotateTowards(frontCoverTransform.rotation, frontCoverOpenTransform.rotation, 1.0f);
                    page0Transform.rotation = Quaternion.RotateTowards(page0Transform.rotation, page0ClosedTransform.rotation, 1.0f);
                    page1Transform.rotation = Quaternion.RotateTowards(page1Transform.rotation, page1ClosedTransform.rotation, 1.0f);
                    page2Transform.rotation = Quaternion.RotateTowards(page2Transform.rotation, page2OpenTransform.rotation, 1.0f);
                    page3Transform.rotation = Quaternion.RotateTowards(page3Transform.rotation, page3OpenTransform.rotation, 1.0f);
                    page4Transform.rotation = Quaternion.RotateTowards(page4Transform.rotation, page4OpenTransform.rotation, 1.0f);
                    break;
                }
            case bookState.page3:
                {
                    frontCoverTransform.rotation = Quaternion.RotateTowards(frontCoverTransform.rotation, frontCoverOpenTransform.rotation, 1.0f);
                    page0Transform.rotation = Quaternion.RotateTowards(page0Transform.rotation, page0ClosedTransform.rotation, 1.0f);
                    page1Transform.rotation = Quaternion.RotateTowards(page1Transform.rotation, page1ClosedTransform.rotation, 1.0f);
                    page2Transform.rotation = Quaternion.RotateTowards(page2Transform.rotation, page2ClosedTransform.rotation, 1.0f);
                    page3Transform.rotation = Quaternion.RotateTowards(page3Transform.rotation, page3OpenTransform.rotation, 1.0f);
                    page4Transform.rotation = Quaternion.RotateTowards(page4Transform.rotation, page4OpenTransform.rotation, 1.0f);
                    break;
                }
            case bookState.page4:
                {
                    frontCoverTransform.rotation = Quaternion.RotateTowards(frontCoverTransform.rotation, frontCoverOpenTransform.rotation, 1.0f);
                    page0Transform.rotation = Quaternion.RotateTowards(page0Transform.rotation, page0ClosedTransform.rotation, 1.0f);
                    page1Transform.rotation = Quaternion.RotateTowards(page1Transform.rotation, page1ClosedTransform.rotation, 1.0f);
                    page2Transform.rotation = Quaternion.RotateTowards(page2Transform.rotation, page2ClosedTransform.rotation, 1.0f);
                    page3Transform.rotation = Quaternion.RotateTowards(page3Transform.rotation, page3ClosedTransform.rotation, 1.0f);
                    page4Transform.rotation = Quaternion.RotateTowards(page4Transform.rotation, page4OpenTransform.rotation, 1.0f);
                    break;
                }
            case bookState.page5:
                {
                    frontCoverTransform.rotation = Quaternion.RotateTowards(frontCoverTransform.rotation, frontCoverOpenTransform.rotation, 1.0f);
                    page0Transform.rotation = Quaternion.RotateTowards(page0Transform.rotation, page0ClosedTransform.rotation, 1.0f);
                    page1Transform.rotation = Quaternion.RotateTowards(page1Transform.rotation, page1ClosedTransform.rotation, 1.0f);
                    page2Transform.rotation = Quaternion.RotateTowards(page2Transform.rotation, page2ClosedTransform.rotation, 1.0f);
                    page3Transform.rotation = Quaternion.RotateTowards(page3Transform.rotation, page3ClosedTransform.rotation, 1.0f);
                    page4Transform.rotation = Quaternion.RotateTowards(page4Transform.rotation, page4ClosedTransform.rotation, 1.0f);
                    break;
                }
        }

           


	}

    //ptint the text when the page is turned
    public void RewriteText(bookState state)
    {
        GameObject[] curPage = null;

        switch (state)
        {
            case bookState.page0:
                {
                    curPage = page0Text;
                    break;
                }
            case bookState.page1:
                {
                    curPage = page1Text;
                    break;
                }
            case bookState.page2:
                {
                    curPage = page2Text;
                    break;
                }
            case bookState.page3:
                {
                    curPage = page3Text;

                    break;
                }
            case bookState.page4:
                {
                    curPage = page4Text;
                    break;
                }
            case bookState.page5:
                {
                    curPage = page5Text;
                    break;
                }
            default:
                break;
        }

        if(curPage != null)
           foreach(GameObject g in curPage)
           {
               g.GetComponent<BookTextManager>().reWriteText();
           }
    }








}
