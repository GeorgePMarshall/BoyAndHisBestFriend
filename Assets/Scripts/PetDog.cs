using UnityEngine;
using System.Collections;

public class PetDog : MonoBehaviour
{ 
    //[SerializeField]float distToPet;
    Vector3 travelLoc;
    Vector3 lookingAt;
    bool playAnim;
    [SerializeField]float distFromPlayer = 0.1f;
    Transform doguSan;
    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (GetComponent<CharacterController>().heldObject != null)
            return;

        //walks to dog
	    if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "Dog")
                {
                    Debug.Log("Gonna Pet");
                    //dog pos + foward * distance
                    travelLoc = hit.transform.position + (hit.transform.forward * distFromPlayer);
                    doguSan = hit.transform;
                    GetComponent<CharacterController>().SetTargetPosition(travelLoc);

                    lookingAt = new Vector3(hit.transform.position.x, transform.position.y, hit.transform.position.z);

                    playAnim = true;

                }
            }
        }

        if (doguSan == null)
            return;

        //plays petting anim
        if ((transform.position - (doguSan.position + (doguSan.forward * distFromPlayer))).magnitude < 0.1 && playAnim == true)
        {
            Debug.Log("petting");
            transform.LookAt(lookingAt);
            GetComponent<CharacterController>().SetAnim(AnimState.idle, "PetDog");
            GetComponent<CharacterController>().disableMovement();
            doguSan.GetComponent<CharacterController>().disableMovement();
            playAnim = false;
        }
	}
}




