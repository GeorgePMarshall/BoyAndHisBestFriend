using UnityEngine;
using System.Collections;

public class SetCamPosition : MonoBehaviour {

    
    [SerializeField]Transform desiredTransform;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.name == "Player")
        {
            if (desiredTransform != null)
                Camera.main.GetComponent<CameraController>().OveridePosition(desiredTransform);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.name == "Player")
        {
            if (desiredTransform != null)
                Camera.main.GetComponent<CameraController>().OveridePosition(null);

        }
    }
}
