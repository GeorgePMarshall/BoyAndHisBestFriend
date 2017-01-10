using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TriggerScript : MonoBehaviour {

    public Text DialogBoxChris;
	public Text DialogBoxEto;
    public string characterText;
    public string dogText;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    //hits trigger
    void OnTriggerEnter(Collider a_collider)
    {
        //if player
        if (a_collider.tag == "Player")
        {

            DialogBoxChris.enabled = true;
            DialogBoxChris.text = characterText;

        }
        else if (a_collider.tag == "Dog")
        {
			Debug.Log ("test");
			DialogBoxEto.enabled = true;
            DialogBoxEto.text = dogText;
        }


    }

    void OnTriggerExit(Collider a_collider)
    {
        if (a_collider.tag == "Player")
        {

			DialogBoxChris.enabled = false;
			DialogBoxChris.text = characterText;

        }
        else if (a_collider.tag == "Dog")
        {
			DialogBoxEto.enabled = false;
            DialogBoxEto.text = dogText;
        }
    }
}
