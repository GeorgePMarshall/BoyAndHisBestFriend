using UnityEngine;
using System.Collections;

public class PlaceObject : EnableAndDissableObjects {

    [SerializeField]Transform targetTransform;
    [SerializeField]GameObject objectToPlace;
    [SerializeField]GameObject objectToDisable;
    [SerializeField]GameObject functionToRun;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //set target
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Find("Player").GetComponent<CharacterController>().SetTargetObject(this.gameObject);
        }
    }

    //detatches object
    void OnTriggerStay(Collider coll)
    {
        if (coll.name == "Player" && coll.GetComponent<CharacterController>().curTarget == this.gameObject && coll.GetComponent<CharacterController>().heldObject == objectToPlace)
        {
            coll.GetComponent<CharacterController>().SetAnim(AnimState.idle, "Idle");
            GameObject temp = coll.GetComponent<CharacterController>().DetachObject();   
            temp.transform.position = targetTransform.position;
            temp.transform.rotation = targetTransform.rotation;
            base.EnableAll();
            base.DisableAll();
            if (functionToRun != null)
                functionToRun.GetComponent<FunctionToRun>().RunFunction();
            if (objectToDisable != null)
                objectToDisable.SetActive(false);
        }
    }

}
