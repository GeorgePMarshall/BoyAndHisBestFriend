using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToMenuScene : FunctionToRun {

    [SerializeField]bool frisbeeInTree = false;
    [SerializeField]GameObject fadingImage;
    [SerializeField]bookState newLimit;
    GameObject bookController;

    public bool shouldEnd = false;
    float opacity = 0;

	// Use this for initialization
	void Start ()
    {
        bookController = GameObject.Find("BookControlls");
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(shouldEnd)
        {
            opacity += Time.deltaTime;
            fadingImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, opacity);
            bookController.GetComponent<BookContolls>().pageLimit = newLimit;

            if(opacity > 1)
            {
                SceneManager.LoadScene("PhotoAlbum");
            }

        }
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.name == "Player" && frisbeeInTree)
        {
            shouldEnd = true;
        }
    }


    public override void RunFunction()
    {
        frisbeeInTree = true;
    }
}
