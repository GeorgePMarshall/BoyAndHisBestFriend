using UnityEngine;
using System.Collections;


[RequireComponent(typeof(OutlineShader))]
public class MouseOverOutLine : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}


    void OnMouseEnter()
    {
        GetComponent<OutlineShader>().outline = true;
    }

    void OnMouseExit()
    {
        GetComponent<OutlineShader>().outline = false;
    }


}
