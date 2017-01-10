using UnityEngine;
using System.Collections;

public enum usrID
{
    Player,
    Dog
}

public class PickUpObject : EnableAndDissableObjects {




    public usrID playerId;
    [SerializeField]Transform desiredTransform;
    [SerializeField]bool playPickupAnim = true;
    [SerializeField]bool parentObject = true;
    [SerializeField]bool itemIsExclusive = true;
    [SerializeField]bool setDogAnimOnPickup = false;
    [SerializeField]bool parentToRoot = false;
    [SerializeField]float attachDelay = 0;
    [SerializeField]string customAnim;
    GameObject player;

    bool curRunning;

    // Use this for initialization
    void Start ()
    {
	
	}

    //sets target when clicked
    void OnMouseOver()
    {
        if (this != enabled)
            return;

        if(playerId == usrID.Player)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject.Find("Player").GetComponent<CharacterController>().SetTargetObject(this.gameObject);
                Debug.Log("target set");
            }
        }

        else
        {
            if (Input.GetMouseButtonDown(1))
            {
                GameObject.Find("Dog").GetComponent<CharacterController>().SetTargetObject(this.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && !curRunning)
        {
            //when hand inside the object attach the object
            if(player.GetComponent<CharacterController>().handObject.transform.position.y < transform.position.y + 0.6f || playPickupAnim == false)
            {
                curRunning = true;
                Debug.Log("wanna pcikup");
                StartCoroutine(PickupTheObject());



            }
        }
    }

    //plays pick animation
    void OnTriggerStay(Collider coll)
    {
        if (this != enabled)
            return;

        if (playerId == usrID.Player)
        {
            if (coll.name == "Player" && coll.GetComponent<CharacterController>().curTarget == this.gameObject)
            {

                coll.GetComponent<CharacterController>().disableMovement();

                if (playPickupAnim)
                    coll.GetComponent<CharacterController>().SetAnim(AnimState.pickupObject, "PlankPickup");
                else if (customAnim.Length > 0)
                    coll.GetComponent<CharacterController>().SetAnim(AnimState.holdingIdle, customAnim);


                if (setDogAnimOnPickup)
                {
                    GetComponent<Animator>().SetInteger("animState", (int)AnimState.idle);
                    GetComponent<Animator>().Play("Idle");
                }
                player = coll.gameObject;
            }
        }
        else
        {
            if (coll.name == "Dog" && coll.GetComponent<CharacterController>().curTarget == this.gameObject)
            {
                //coll.GetComponent<CharacterController>().SetPickupAnim();
                player = coll.gameObject;
            }

        }
    }

    //attach the object to the player
    IEnumerator PickupTheObject()
    {
        yield return new WaitForSeconds(attachDelay);

        base.EnableAll();
        base.DisableAll();

        if (desiredTransform != null)
        {
            transform.position = desiredTransform.position;
            transform.rotation = desiredTransform.rotation;
        }

        if (parentObject)
        {
            if (itemIsExclusive)
            {
                Debug.Log("attaching");
                if (parentToRoot)
                    player.GetComponent<CharacterController>().AttachObjectToRoot(this.gameObject);
                else
                    player.GetComponent<CharacterController>().AttachObject(this.gameObject);
            }
            else
            {
                player.GetComponent<CharacterController>().AttachObjectNonExclusive(this.gameObject);
            }
        }
        else
        {
            player.GetComponent<CharacterController>().AttachObjectNoParent(this.gameObject);
        }

        player.GetComponent<CharacterController>().enableMovement();

        player = null;
        this.enabled = false;
        curRunning = false;

        yield return null;
    }


}
