using UnityEngine;
using System.Collections;

public class CursorHighlight : MonoBehaviour {

    public Texture2D cursorTexture;
    Vector3 offset;

	// Use this for initialization
	void Start ()
    {
        offset = new Vector3(38.5f, 38.5f, 1);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, offset, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, offset, CursorMode.Auto);
    }

}
