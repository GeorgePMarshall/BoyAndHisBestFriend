using UnityEngine;
using System.Collections;

public enum frisbeeState
{
    playerPickup,
    dogPickup,
    playerThrow
}

public class Frisbee : FunctionToRun {


    public Transform FrisbeeTarget;
    [SerializeField]float speed;
    [SerializeField]Texture2D playerCursor;
    [SerializeField]Texture2D doggoCursor;
    [SerializeField]GameObject objectToDisable;
    public bool shouldMove;
    public frisbeeState nextFrisbeeAction;

    GameObject dog;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(shouldMove)
        {
            moveToDestination();
        }
	}

    //set targer for the player to collect
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && nextFrisbeeAction == frisbeeState.playerThrow)
        {
            GameObject.Find("Player").GetComponent<CharacterController>().SetTargetObject(this.gameObject);
        }

        dog = GameObject.Find("Dog");
    }

    //piickup and trow the frisbee to the next intended location and update its state
    void OnTriggerStay(Collider coll)
    {
        if (coll.name == "Player" && coll.GetComponent<CharacterController>().curTarget == this.gameObject)
        {
            if (dog.GetComponent<CharacterController>().heldObject == this.gameObject)
                dog.GetComponent<CharacterController>().DetachObject();
            if (objectToDisable != null)
                objectToDisable.SetActive(false);
            Camera.main.GetComponent<CameraController>().AddGameobject(this.gameObject);
            transform.position = coll.GetComponent<CharacterController>().handObject.transform.position;
            coll.GetComponent<CharacterController>().AttachObject(this.gameObject);

            coll.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            coll.GetComponent<NavMeshAgent>().enabled = false;
            coll.transform.LookAt(new Vector3(FrisbeeTarget.position.x, transform.position.y, FrisbeeTarget.position.z));
            coll.GetComponent<CharacterController>().curTarget = null;
            coll.GetComponent<CharacterController>().SetAnim(AnimState.nullState, "FrisbeeThrow");

        }

        if (coll.name == "Dog" && coll.GetComponent<CharacterController>().curTarget == this.gameObject && nextFrisbeeAction == frisbeeState.dogPickup)
        {
            nextFrisbeeAction = frisbeeState.playerThrow;
            RunFunction();
        }
    }

    //moves toward target
    void moveToDestination()
    {
        transform.position = Vector3.MoveTowards(transform.position, FrisbeeTarget.position, Time.deltaTime * speed);
        transform.up = new Vector3(0, 1, 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, FrisbeeTarget.rotation, Time.deltaTime * speed);

    }

    public override void RunFunction()
    {
        if (nextFrisbeeAction == frisbeeState.dogPickup)
        {
            GetComponent<CursorHighlight>().cursorTexture = doggoCursor;
        }
        else
        {
            GetComponent<CursorHighlight>().cursorTexture = playerCursor;
        }

    }

}

