using UnityEngine;
using System.Collections;

public class getCamFocus : MonoBehaviour {


    [SerializeField]GameObject objectToFocus;
    GameObject player;
    GameObject dog;


	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
        dog = GameObject.Find("Dog");
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if(coll.name == "Player")
        {
            Debug.Log("Going in dry");
            //Camera.main.GetComponent<CameraController>().RemoveGameobject(player);
            //Camera.main.GetComponent<CameraController>().RemoveGameobject(dog);
            if(objectToFocus == null)
                Camera.main.GetComponent<CameraController>().AddGameobject(this.gameObject);
            else
                Camera.main.GetComponent<CameraController>().AddGameobject(objectToFocus);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.name == "Player")
        {
            if (objectToFocus == null)
                Camera.main.GetComponent<CameraController>().RemoveGameobject(this.gameObject);
            else
                Camera.main.GetComponent<CameraController>().RemoveGameobject(objectToFocus);
            //Camera.main.GetComponent<CameraController>().AddGameobject(dog);
            //Camera.main.GetComponent<CameraController>().AddGameobject(player);
        }
    }
}
