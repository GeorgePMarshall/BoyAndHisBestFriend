using UnityEngine;
using System.Collections;



public class EnableAndDissableObjects : MonoBehaviour
{
    [SerializeField]GameObject[] objectsToEnable;
    [SerializeField]GameObject[] objectsToDisable;


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    protected void EnableAll()
    {
        foreach(GameObject g in objectsToEnable)
        {
            g.SetActive(true);
        }
    }

    protected void DisableAll()
    {
        foreach (GameObject g in objectsToDisable)
        {
            g.SetActive(false);
        }
    }



}
