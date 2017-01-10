using UnityEngine;
using System.Collections;

public class CullObjects : MonoBehaviour {

    [SerializeField]float cullLimit;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if((hit.point - transform.position).magnitude < cullLimit)
            {
                hit.transform.GetComponent<Renderer>().enabled = false;
            }
        }
    }
}
