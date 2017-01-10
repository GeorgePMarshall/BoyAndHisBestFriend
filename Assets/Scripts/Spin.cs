using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{
	[SerializeField]float speed = 10f;
    [SerializeField]Vector3 axis;

	void Update ()
	{
		transform.Rotate(axis , speed * Time.deltaTime);
	}
}