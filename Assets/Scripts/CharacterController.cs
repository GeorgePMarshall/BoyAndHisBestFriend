using UnityEngine;
using System.Collections;



public enum AnimState
{
    nullState = -1,
    idle,
    walking,
    running,
    digging,
    pickupObject,
    holdingIdle,
    holdingWalk,
    holdingRun,
    putDown,
    turn
};


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(BoxCollider))]





public class CharacterController : MonoBehaviour
{

    AnimState curAnim;

    public int PlayerID;
    public GameObject Marker;
    //public GameObject OtherMarker;
    //public string PlayerTag = "Player";

    [SerializeField]float walkSpeed;
    [SerializeField]float runDistance;
    [SerializeField]float runSpeed;
    [SerializeField]float turnSpeed;
    [SerializeField]float acceleration = 2f;
    [SerializeField]float deceleration = 60f;
    [SerializeField]float timeToRepath = 0.4f;
    [SerializeField]float audioReplayTime = 1f;

    public GameObject handObject;
    public GameObject rootObject;
    public GameObject curTarget;
    public GameObject heldObject;
    public GameObject doguSan;

    [SerializeField]AudioClip movmentSound;

    AudioSource characterAudio;
    Animator anim;

    private NavMeshAgent Nav;

    bool hasTarget;
    bool heldObjectNoParent;
    bool canMove = true;
    Vector3 targetPosition;

    bool isTurning;

    int layerMask;

    float repathTimer;
    float soundTimer;

    // Use this for initialization
    void Start()
    {
        curTarget = null;
        Marker.GetComponent<MeshRenderer>().enabled = false;
        Time.timeScale = 1;
        //OtherMarker.GetComponent<MeshRenderer>().enabled = false;
        //tag = PlayerTag;
        anim = GetComponent<Animator>();
        characterAudio = GetComponent<AudioSource>();
        Nav = GetComponent<NavMeshAgent>();

        doguSan = GameObject.Find("Dog");

        if(PlayerID == 0)
        {
            layerMask = LayerMask.GetMask("Default", "Dog");
        }

        if (PlayerID == 1)
        {
            layerMask = LayerMask.GetMask("Default");
        }

    }

    // Update is called once per frame
    void Update()
    {
        //move held object to hand
        if(heldObject != null && heldObjectNoParent)
        {
            heldObject.transform.position = handObject.transform.position;
            heldObject.transform.rotation = handObject.transform.rotation;
        }

        if(repathTimer <= timeToRepath)
            repathTimer += Time.deltaTime;

        if (soundTimer <= audioReplayTime)
            soundTimer += Time.deltaTime;


        if (Input.GetMouseButton(PlayerID))
        {
            SetMarkerRaycast();
        }

        if(Input.GetMouseButtonUp(PlayerID))
        {
            SetTargetRaycast();
        }


        if (Input.GetMouseButton(PlayerID) && repathTimer > timeToRepath)
        {
            SetTargetRaycast();

            if(movmentSound != null && soundTimer > audioReplayTime)
            {
                Debug.Log("bork");
                PlayAudio(movmentSound);
                soundTimer = 0;
            }

            repathTimer = 0;
        }

        UpdateAnimator();

        //face target then walk towards
        if(hasTarget)
        {
            if(TurnToFace(targetPosition))
            {
                Debug.Log("Going");
                SetNavDestination(targetPosition);
                hasTarget = false;
                isTurning = false;
            }
        }

        if(Nav.enabled == true)
        {
            if (Nav.remainingDistance > runDistance)
                Nav.speed = runSpeed;
            else
                Nav.speed = walkSpeed;

            if (Nav.hasPath)
            {
                Nav.acceleration = (Nav.remainingDistance < 1) ? deceleration : acceleration;
            }
            else
            {
                Nav.acceleration = deceleration;
            }
        }

    }


    //finds point in world and attempts to walk towards
    Vector3 SetTargetRaycast()
    {
        if(canMove != true)
            return Vector3.zero;


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            if (hit.transform.tag == "Ground")
            {
                SetTargetObject(null);
                Marker.transform.position = new Vector3(hit.point.x, (hit.point.y + 0.2f), hit.point.z);
                SetTargetPosition(hit.point);
                Marker.GetComponent<MeshRenderer>().enabled = true;
                return hit.point;
            }
        }

        return Vector3.zero;
    }

    //moves marker to point in world
    Vector3 SetMarkerRaycast()
    {
        if (canMove != true)
            return Vector3.zero;


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            if (hit.transform.tag == "Ground")
            {
                Marker.transform.position = new Vector3(hit.point.x, (hit.point.y + 0.2f), hit.point.z);
                return hit.point;
            }
        }

        return Vector3.zero;
    }

    //set position to path towards
    public void SetTargetPosition(Vector3 pos)
    {
        if (canMove != true)
            return;


        Marker.transform.position = new Vector3(pos.x, (pos.y + 0.2f), pos.z);
        //isTurning = true;
        targetPosition = pos;
        hasTarget = true;
        if(TurnToFace(pos) == false && Nav.enabled)
        {
            //curAnim = AnimState.turn;
            Nav.Stop();
            //Nav.velocity = Vector3.zero;
        }
    }

    //update navAgent
    void SetNavDestination(Vector3 pos)
    {
        if (canMove != true)
            return;


        Nav.Resume();
        Nav.destination = pos;
        Marker.GetComponent<MeshRenderer>().enabled = true;

    }

    /// <summary>
    /// Turns towards target. Returns true if facing target
    /// </summary>
    bool TurnToFace(Vector3 target)
    {
        if (canMove != true)
            return false;


        Vector3 targetDir = new Vector3(target.x, transform.position.y, target.z) - transform.position;

        targetDir.Normalize();

        if (Vector3.Dot(transform.forward, targetDir) > 0.99f)
            return true;

        transform.forward = Vector3.RotateTowards(transform.forward, targetDir, Time.deltaTime * turnSpeed, Time.deltaTime * turnSpeed);

        return false;
    }

    /// <summary>
    /// Set GameObject as current target to path towards and interact
    /// </summary>
    public void SetTargetObject(GameObject target)
    {
        if (canMove != true)
            return;


        if (curTarget != target)
        {
            if (curTarget != null)
            {
                if(curTarget.GetComponent<OutlineShader>() != null)
                {
                    curTarget.GetComponent<OutlineShader>().outline = false;
                }
            }
               

            if (target != null)
            {
                if (target.GetComponent<OutlineShader>() != null)
                {
                    target.GetComponent<OutlineShader>().outline = true;
                }
                SetTargetPosition(target.transform.position);
            }

            curTarget = target;
        }
    }

    //plays selected audio from player
    public void PlayAudio(AudioClip audioToPlay)
    {
        characterAudio.clip = audioToPlay;
        characterAudio.Play();
    }


    /// <summary>
    /// parents object to hand bone if not other object currently held
    /// </summary>
    public bool AttachObject(GameObject objectToAttach)
    {
        if (heldObject != null)
            return false;

        objectToAttach.transform.parent = handObject.transform;
        heldObject = objectToAttach;

        return true;
    }

    /// <summary>
    /// attaches object to hand bone regardless of other objects
    /// </summary>
    public bool AttachObjectNonExclusive(GameObject objectToAttach)
    {
        objectToAttach.transform.parent = handObject.transform;
        return true;
    }

    /// <summary>
    /// attaches object to hand bone without parenting
    /// </summary>
    public bool AttachObjectNoParent(GameObject objectToAttach)
    {
        if (heldObject != null)
            return false;

        //objectToAttach.transform.parent = handObject.transform;
        heldObject = objectToAttach;
        heldObjectNoParent = true;

        return true;
    }

    /// <summary>
    /// attaches object to root bone
    /// </summary>
    public bool AttachObjectToRoot(GameObject objectToAttach)
    {
        if (heldObject != null)
            return false;

        objectToAttach.transform.parent = rootObject.transform;
        heldObject = objectToAttach;

        return true;
    }

    /// <summary>
    /// unparents the currently held object and returns a reference to it
    /// </summary>
    public GameObject DetachObject()
    {
        if (heldObject == null)
            return null;

        heldObject.transform.parent = null;

        anim.Play("PlankPutdown");

        GameObject tempHeld = heldObject;
        heldObject = null;
        heldObjectNoParent = false;

        return tempHeld;
    }

    /// <summary>
    /// unparents the currently held object and returns a reference to it without an animation playing
    /// </summary>
    public GameObject DetachObjectNoAnim()
    {
        if (heldObject == null)
            return null;

        heldObject.transform.parent = null;
        GameObject tempHeld = heldObject;
        heldObject = null;

        return tempHeld;
    }

    //player can move
    public void enableMovement()
    {
        GetComponent<NavMeshAgent>().enabled = true;
        canMove = true;

    }

    //player cant move
    public void disableMovement()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        canMove = false;

    }

    //sets the animator to the correct state
    void UpdateAnimator()
    {

        Vector3 navHorVelocity = Nav.velocity;
        navHorVelocity.y = 0;
        float navHorMagnitude = navHorVelocity.magnitude;

        if (!isTurning)
        {
            if (navHorMagnitude > 6f)
            {
                if (heldObject == null)
                {
                    curAnim = AnimState.running;
                }
                else
                {
                    curAnim = AnimState.holdingRun;
                }

            }
            else if (navHorMagnitude > 0.5f)
            {
                if (heldObject == null)
                {
                    curAnim = AnimState.walking;
                }
                else
                {
                    curAnim = AnimState.holdingWalk;
                }
            }
            else if (curAnim != AnimState.digging)
            {
                if (heldObject == null)
                {
                    curAnim = AnimState.idle;
                }
                else
                {
                    curAnim = AnimState.holdingIdle;
                }
            }
        }
       


        anim.SetInteger("animState", (int)curAnim);

        
        Debug.Log(gameObject.name +" "+ curAnim);
    }


    //sets dig
    public void SetDigAnim()
    {
       curAnim = AnimState.digging;
    }

    //sets idle
    public void SetIdleAnim()
    {
        curAnim = AnimState.idle;
    }

    //set the animation state
    public void SetAnim(AnimState animSetState, string animation)
    {
        if(curAnim != AnimState.nullState)
            curAnim = animSetState;

        if (animation != null)
            anim.Play(animation);
    }

    //releases the frisbee called from an animation
    public void FrissbeeThrowPoint()
    {
        GetComponent<NavMeshAgent>().enabled = true;
        DetachObjectNoAnim();
        GameObject.Find("Frisbee").GetComponent<Frisbee>().shouldMove = true;
    }


}