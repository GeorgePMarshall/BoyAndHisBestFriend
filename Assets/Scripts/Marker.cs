using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour
{
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider a_other)
    {
        if (a_other.name == "Player")
        {
            GetComponent<MeshRenderer>().enabled = false;
        }


        if (a_other.name == "Dog")
        {
            GetComponent<MeshRenderer>().enabled = false;
        }

    }
}
