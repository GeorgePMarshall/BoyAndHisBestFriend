using UnityEngine;
using System.Collections;

public class ScrollTexture : MonoBehaviour {

    [SerializeField]Vector2 direction;
    Material material;

	// Use this for initialization
	void Start ()
    {
        material = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update ()
    {
        material.mainTextureOffset = material.mainTextureOffset += direction * Time.deltaTime;





    }
}
