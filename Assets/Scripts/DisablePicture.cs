using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisablePicture : MonoBehaviour {

	public GameObject picture;
	// Use this for initialization

	void Start()
	{
		picture.GetComponent<SpriteRenderer> ().enabled = true;
	}

	void OnMouseOver()
	{
		picture.GetComponent<SpriteRenderer> ().enabled = false;
	}

	void OnMouseExit()
	{
		picture.GetComponent<SpriteRenderer> ().enabled = true;
	}
}