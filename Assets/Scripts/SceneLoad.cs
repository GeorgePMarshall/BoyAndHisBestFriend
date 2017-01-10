using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoad : FunctionToRun {


    [SerializeField]bool loadInstant = true;
    [SerializeField]string sceneToLoad;



	// Use this for initialization
	void Start ()
    {
        if(loadInstant)
            SceneManager.LoadScene(sceneToLoad);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void RunFunction()
    {
        //SceneManager.LoadScene(sceneToLoad);
        GetComponent<GoToMenuScene>().shouldEnd = true;
    }
}
