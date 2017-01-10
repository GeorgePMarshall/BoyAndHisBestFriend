using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshObstacle))]
public class CheckForPlank : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.name == "Plank" )
        {
            GetComponent<NavMeshObstacle>().enabled = false;
        }
    }
}
