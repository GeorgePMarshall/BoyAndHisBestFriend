using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public enum bookState
{
    closed,
    page0,
    page1,
    page2,
    page3,
    page4,
    page5
};


public class BookContolls : MonoBehaviour {

    static bool isCreated;

    public bookState curState;
    public bookState pageLimit;

    GameObject book;
    AudioSource pageWriteSound;
    bool visitedHouse;

    GameObject housePageRefs;

    // Use this for initialization
    void Start ()
    {
        pageWriteSound = GameObject.Find("PageWritingAudio").GetComponent<AudioSource>();
        GameObject.DontDestroyOnLoad(this.gameObject);
        if(isCreated)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            isCreated = true;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        //changes what parts of the book are active
        if(visitedHouse == false)
            if(SceneManager.GetActiveScene().name == "HouseScene")
            {
                visitedHouse = true;
            }

        if (housePageRefs == null)
        {
            housePageRefs =  GameObject.Find("Page1");
        }




        if(visitedHouse)
        {
            housePageRefs.GetComponent<HousePageRefs>().housePic.SetActive(true);
            housePageRefs.GetComponent<HousePageRefs>().houseText.SetActive(true);
        }


        if(book == null)
        {
            book = GameObject.Find("Book");
        }
	}

    public void TurnToPage(bookState setState)
    {
        curState = setState;
    }

    public void TurnPageInc()
    {
        if (curState == pageLimit)
            return;

        curState++;
        //pageWriteSound.Stop();
        book.GetComponent<MenuControlls>().RewriteText(curState);
    }

    public void TurnPageDec()
    {
        if (curState == bookState.closed)
            return;

        curState--;
        //pageWriteSound.Stop();
        book.GetComponent<MenuControlls>().RewriteText(curState);
    }

    public bool canTurn(buttonState state)
    {
        if (state == buttonState.left && curState == bookState.closed)
        {
            return false;
        }

        if (state == buttonState.right && curState == pageLimit)
        {
            return false;
        }

        return true;
    }


}
