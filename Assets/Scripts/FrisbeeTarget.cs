using UnityEngine;
using System.Collections;

public class FrisbeeTarget : MonoBehaviour {

    [SerializeField]Transform nextTarget;
    [SerializeField]frisbeeState nextFrisbeeState;
    [SerializeField]GameObject objectToEnable;
    [SerializeField]GameObject[] functionsToRun;
    [SerializeField]GameObject ladder;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //changes the frisbees state when it arives
    void OnTriggerEnter(Collider coll)
    {
        if(coll.name == "Frisbee")
        {
            coll.GetComponent<Frisbee>().shouldMove = false;
            if (nextTarget != null)
                coll.GetComponent<Frisbee>().FrisbeeTarget = nextTarget;
            coll.transform.position = transform.position;
            coll.transform.rotation = transform.rotation;
            Camera.main.GetComponent<CameraController>().RemoveGameobject(coll.gameObject);
            coll.GetComponent<Frisbee>().nextFrisbeeAction = nextFrisbeeState;
            GameObject.Find("Dog").GetComponent<CharacterController>().SetTargetObject(null);

            if (objectToEnable != null)
            {
                objectToEnable.SetActive(true);
            } 

            if (ladder != null)
            {
                ladder.GetComponent<PickUpObject>().enabled = true;
            }

            if (nextFrisbeeState == frisbeeState.playerPickup)
            {
                coll.GetComponent<PickUpObject>().enabled = true;
                coll.GetComponent<PickUpObject>().playerId = usrID.Player;
            }
            else if(nextFrisbeeState == frisbeeState.dogPickup)
            {
                coll.GetComponent<PickUpObject>().enabled = true;
                coll.GetComponent<PickUpObject>().playerId = usrID.Dog;
            }
            else
            {
                coll.GetComponent<PickUpObject>().enabled = false;
            }

            foreach (GameObject function in functionsToRun)
            {
                if (function != null)
                    function.GetComponent<FunctionToRun>().RunFunction();
            }

            this.gameObject.SetActive(false);


        }
    }
}
