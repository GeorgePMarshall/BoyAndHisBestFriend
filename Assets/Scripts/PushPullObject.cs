using UnityEngine;
using System.Collections;

public class PushPullObject : MonoBehaviour {

    bool attachedToPlayer;
    Transform playerTransform;
    float startingHeight;

	// Use this for initialization
	void Start ()
    {
        startingHeight = transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(attachedToPlayer)
        {
            transform.position = new Vector3(transform.position.x, startingHeight, transform.position.z);
        }
	}


    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Find("Player").GetComponent<CharacterController>().SetTargetObject(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.name == "Player" && coll.GetComponent<CharacterController>().curTarget == this.gameObject)
        {
            attachedToPlayer = true;
            playerTransform = coll.transform;
            transform.parent = coll.transform;
        }
    }
}
