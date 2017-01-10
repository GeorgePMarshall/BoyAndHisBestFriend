using UnityEngine;
using System.Collections;

public class ShowText : MonoBehaviour {

    [SerializeField]usrID ShowTextFor;
    public string TextToShow;
    GameObject playerTextBox;
    [SerializeField]GameObject dogTextBox;

    // Use this for initialization
    void Start ()
    {
        GameObject textRefs;
        textRefs = GameObject.Find("TextRefs");

        playerTextBox = textRefs.GetComponent<TextRefs>().playerText;
        dogTextBox = textRefs.GetComponent<TextRefs>().dogText;

        // playerTextBox = GameObject.Find("PlayerText");
        // dogTextBox = GameObject.Find("DogText");
    }
	
	// Update is called once per frame
	void Update ()
    {
	
    }

    //set player dialog when colliding
    void OnTriggerStay(Collider coll)
    {
        if (this.gameObject != enabled)
            return;


        if (ShowTextFor == usrID.Player && coll.CompareTag("Player"))
        {
            playerTextBox.GetComponent<FloatingText>().showTextThisFrame(TextToShow);
            playerTextBox.SetActive(true);
        }

        if (ShowTextFor == usrID.Dog && coll.CompareTag("Dog"))
        {
            //dogTextBox.GetComponent<TextMesh>().text = TextToShow;
            //dogTextBox.SetActive(true);
        }
    }

    //remove player dialog
    void OnTriggerExit(Collider coll)
    {
        if (this.gameObject != enabled)
            return;


        if (coll.CompareTag("Player"))
        {
            playerTextBox.GetComponent<TextMesh>().text = "";
            playerTextBox.SetActive(false);
        }

        if (coll.CompareTag("Dog"))
        {
            dogTextBox.GetComponent<TextMesh>().text = "";
            dogTextBox.SetActive(false);
        }
    }

}
