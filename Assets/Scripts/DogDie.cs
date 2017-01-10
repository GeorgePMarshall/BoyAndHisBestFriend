using UnityEngine;
using System.Collections;

public class DogDie : EnableAndDissableObjects {

    GameObject player;
    bool hasHappened = false;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //lie dog down and dissable movement
    void OnTriggerEnter(Collider coll)
    {

        if(coll.name == "Dog" && !hasHappened)
        {            
            coll.GetComponent<CharacterController>().enabled = false;
            coll.GetComponent<NavMeshAgent>().enabled = false;
            coll.GetComponent<PickUpObject>().enabled = true;
            player.GetComponent<PetDog>().enabled = false;
            StartCoroutine(EnableWithDelay());
            //coll.transform.forward = Vector3.forward;
            coll.GetComponent<CharacterController>().SetAnim(AnimState.nullState, "LieDown");
            hasHappened = true;
        }



    }

    IEnumerator EnableWithDelay()
    {
        yield return new WaitForSeconds(3);

        base.EnableAll();
        base.DisableAll();

        yield return null;
    }



}
