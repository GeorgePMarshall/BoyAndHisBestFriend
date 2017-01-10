using UnityEngine;
using System.Collections;

public class ClimbLadder : FunctionToRun {

    Transform topPoint;
    Transform bottomPoint;

    GameObject player;
    Transform playerTransform;

    bool goingUp;
    bool climable;

	// Use this for initialization
	void Start ()
    {
        bottomPoint = transform.FindChild("BottomPoint");
        topPoint = transform.FindChild("TopPoint");
        player = GameObject.Find("Player");
        climable = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(playerTransform != null)
            if (playerTransform.GetComponent<CharacterController>().curTarget != this.gameObject)
                goingUp = false;




        if (goingUp)
            ClimbToTop();
        else
            ClimbToBottom();
        
        


	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && climable)
        {
            GameObject.Find("Player").GetComponent<CharacterController>().SetTargetObject(this.gameObject);
        }
    }

    //when player arrives start them climbing
    void OnTriggerStay(Collider coll)
    {
        if (this != enabled)
            return;

        if (coll.name == "Player" && coll.GetComponent<CharacterController>().curTarget == this.gameObject && climable)
        {
            coll.GetComponent<NavMeshAgent>().enabled = false;
            if (!goingUp)
            {
                coll.transform.position = bottomPoint.position;
                coll.GetComponent<CharacterController>().SetAnim(AnimState.nullState, "LadderClimb");
            }
            goingUp = true;
            playerTransform = coll.transform;
        }
    }

    //moves toward top point
    void ClimbToTop()
    {
        playerTransform.position = Vector3.MoveTowards(playerTransform.position, topPoint.position, Time.deltaTime);
        playerTransform.forward = -transform.forward;
    }

    //move toward bottom point an releases player when at bottom
    void ClimbToBottom()
    {
        if (playerTransform != null)
        {
            if (playerTransform.position == bottomPoint.position)
            {
                playerTransform.GetComponent<NavMeshAgent>().enabled = true;
                playerTransform = null;
                return;
            }

            playerTransform.position = Vector3.MoveTowards(playerTransform.position, bottomPoint.position, Time.deltaTime);
            playerTransform.forward = -transform.forward;
        }
    }

    public override void RunFunction()
    {
        Debug.Log("polywantacracker");
        GetComponent<PickUpObject>().enabled = false;
        climable = true;
        player.GetComponent<CharacterController>().SetTargetPosition(bottomPoint.position);
    }
}

