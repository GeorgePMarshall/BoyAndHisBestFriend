using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

    [SerializeField]Vector3 offset;
    [SerializeField]float cameraSpeed;
    //[SerializeField]GameObject[] objectsToContain;
    [SerializeField]List<GameObject> objectsToContain = new List<GameObject>();
    [SerializeField]bool useLegacyMovement = false;
    Vector3 min;
    Vector3 max;
    Vector3 average;
    Vector3 targetPosition;
    Vector3 targetForward;
    Vector3 initialLookDirection;
    bool overridden = false;


	// Use this for initialization
	void Start ()
    {
        average = Vector3.zero;
        initialLookDirection = transform.forward;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //trys to keep all objects in view
        if (!overridden)
        {
            average = Vector3.zero;

            foreach (GameObject obj in objectsToContain)
            {
                average += obj.transform.position;
            }

            average /= objectsToContain.Count;

            targetPosition = new Vector3(average.x + offset.x, average.y + offset.y, average.z + offset.z);
            targetForward = initialLookDirection;
        }






        //move towards location
        if(useLegacyMovement)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * cameraSpeed);
            transform.forward = Vector3.MoveTowards(transform.forward, targetForward, Time.deltaTime * cameraSpeed);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraSpeed);
            transform.forward = Vector3.Lerp(transform.forward, targetForward, Time.deltaTime * cameraSpeed);
        }
    }

    
    public void AddGameobject(GameObject obj)
    {
        objectsToContain.Add(obj);
    }

    public void RemoveGameobject(GameObject obj)
    {
        Debug.Log("removed" + obj.name);
        objectsToContain.Remove(obj);
    }

    //sets new position
    public void OveridePosition(Transform newTransform)
    {
        if(newTransform == null)
        {
            overridden = false;
            return;
        }

        overridden = true;
        targetPosition = newTransform.position;
        targetForward = newTransform.forward;
        //transform.position = newTransform.position;
        //transform.forward = newTransform.forward;

    }


}
