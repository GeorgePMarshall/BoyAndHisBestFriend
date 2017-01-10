using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

    [SerializeField]Transform target;
    [SerializeField]float speed;

    Vector3 originalPosition;

	// Use this for initialization
	void Start ()
    {
        originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if ((transform.position - target.position).magnitude < 1)
            transform.position = originalPosition;

	}
}
