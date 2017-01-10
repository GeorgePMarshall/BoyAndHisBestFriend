using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoviePlay : MonoBehaviour
{
    MovieTexture movie;
    [SerializeField]string sceneToLoad;
    [SerializeField]GameObject pic;
    GameObject canvas;

    bool shouldLoad;
    // Use this for initialization

    void Start ()
    {
        canvas = GameObject.Find("Canvas");
        Renderer r = GetComponent<Renderer>();
        movie = (MovieTexture)r.material.mainTexture;
        movie.Stop();
	}
	
	// Update is called once per frame
	void Update ()
    {


    }
    void OnMouseEnter()
    {
        pic.GetComponent<SpriteRenderer>().enabled = false;
        movie.Play();
		Debug.Log ("test1");
    }

    void OnMouseExit()
    {
        pic.GetComponent<SpriteRenderer>().enabled = true;
        movie.Pause();
		Debug.Log ("test2");
    }

    void OnMouseDown()
    {
        canvas.transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine(LoadScene());
    }


    IEnumerator LoadScene()
    {

        //yield return new WaitForSeconds(3);

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneToLoad);
        async.allowSceneActivation = false;

        while(async.progress < 0.9f)
        {
            Debug.Log("Loading: " + async.progress + "%");
            yield return null;
        }

        Debug.Log("Loading: " + async.progress + "%");
        async.allowSceneActivation = true;
        yield return null;
        

    }
}
