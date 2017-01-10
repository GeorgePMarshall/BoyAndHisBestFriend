using UnityEngine;
using System.Collections;
//using UnityEditor;


public class DigHole : EnableAndDissableObjects {


    [SerializeField]GameObject particle;
    [SerializeField]float dugPercentage = 100;
    [SerializeField]float uncoverPercentage = 50;
    [SerializeField]GameObject pickupEnable;
    [SerializeField]float digDist = 0.3f;

    Vector3 topPoint;
    Vector3 bottomPoint;

    [SerializeField]float speed;

    [HideInInspector]public bool digging;

	// Use this for initialization
	void Start ()
    {
        topPoint = transform.position;
        bottomPoint = new Vector3(transform.position.x, transform.position.y - digDist, transform.position.z);
        //particle = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(digging)
            particle.GetComponent<ParticleSystem>().enableEmission = true;
        else
            particle.GetComponent<ParticleSystem>().enableEmission = false;


        if (dugPercentage < uncoverPercentage)
        {
            if(pickupEnable != null)
                pickupEnable.GetComponent<PickUpObject>().enabled = true;


            base.EnableAll();
            base.DisableAll();
        }
    }   

    void OnMouseOver()
    {
       if(Input.GetMouseButtonDown(1))
        {
            GameObject.Find("Dog").GetComponent<CharacterController>().SetTargetObject(this.gameObject);
        }
    }

    //dig the hole when the dog is colliding
    void OnTriggerStay(Collider coll)
    {
        if(coll.name == "Dog" )
        {

            if (dugPercentage > 0 && coll.GetComponent<NavMeshAgent>().remainingDistance == 0 && coll.GetComponent<CharacterController>().curTarget == this.gameObject)
            {
                dugPercentage -= Time.deltaTime * speed;
                coll.transform.forward = Vector3.RotateTowards(coll.transform.forward, transform.right, 1.0f, 1.0f);
                //coll.GetComponent<Animator>().SetInteger("animState", 3);
                coll.GetComponent<CharacterController>().SetDigAnim();
                digging = true;
            }
            else if(dugPercentage <= 0)
            {
                dugPercentage = 0;
                digging = false;
                //coll.GetComponent<Animator>().SetInteger("animState", 0);
                coll.GetComponent<CharacterController>().SetIdleAnim();
            }
            else
            {
                digging = false;
                //coll.GetComponent<Animator>().SetInteger("animState", 0);
                coll.GetComponent<CharacterController>().SetIdleAnim();
            }

            transform.position = Vector3.Lerp(bottomPoint, topPoint, dugPercentage/100);
        }
      
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.name == "Dog")
        {
            digging = false;
            coll.GetComponent<CharacterController>().SetIdleAnim();
        }
    }

}

