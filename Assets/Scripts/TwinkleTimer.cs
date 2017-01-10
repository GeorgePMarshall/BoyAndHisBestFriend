using UnityEngine;
using System.Collections;

public class TwinkleTimer : MonoBehaviour {

    float timer;
    [SerializeField]float time;

    ParticleSystem emitter;

	// Use this for initialization
	void Start ()
    {
        emitter = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if(timer > time)
        {
            timer = 0;
            emitter.Emit( 10);

        }
	}
}
