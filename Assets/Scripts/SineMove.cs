using UnityEngine;
using System.Collections;

public class SineMove : MonoBehaviour {

    [SerializeField]Vector3 axis;
    Vector3 startingPoint;

	// Use this for initialization
	void Start ()
    {
        startingPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = startingPoint + new Vector3(Mathf.Sin(Time.time) * axis.x, Mathf.Sin(Time.time) * axis.y, Mathf.Sin(Time.time) * axis.z);
	}
}
