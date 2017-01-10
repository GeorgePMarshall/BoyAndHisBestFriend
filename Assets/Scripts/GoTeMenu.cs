using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GoTeMenu : MonoBehaviour {

    [SerializeField]float timetoWait = 5;
    float timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer > timetoWait)
        {
            SceneManager.LoadScene("PhotoAlbum");
        }
    }

}
