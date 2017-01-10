using UnityEngine;
using System.Collections;

public class Highlight : MonoBehaviour {

    Renderer curRenderer;
    Material defaultMaterial;
    Material highlightMaterial;

	// Use this for initialization
	void Start ()
    {
        curRenderer = GetComponent<Renderer>();
        defaultMaterial = curRenderer.material;
        highlightMaterial = new Material(defaultMaterial);
        highlightMaterial.color = highlightMaterial.color + new Color(0.2f, 0.2f, 0.2f, 1);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnMouseEnter()
    {
        curRenderer.material = highlightMaterial;
    }

    void OnMouseExit()
    {
        curRenderer.material = defaultMaterial;
    }


}
