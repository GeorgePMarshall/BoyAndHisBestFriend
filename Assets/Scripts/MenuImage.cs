using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuImage : MonoBehaviour {

    Material defaultImage;
    [SerializeField]Material video;
    [SerializeField]string sceneToLoad;
    GameObject loadingSplash;
    GameObject loadingIcon;

	// Use this for initialization
	void Start ()
    {
        defaultImage = GetComponent<Renderer>().material;


        GameObject canvas;
        canvas = GameObject.Find("Canvas");
        loadingSplash = canvas.transform.GetChild(0).gameObject;
        loadingIcon = canvas.transform.GetChild(0).GetChild(1).gameObject;

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //plays vidoe on mouse over
    void OnMouseEnter()
    {
        Debug.Log("openthegates");
        GetComponent<Renderer>().material = video;
        ((MovieTexture)video.mainTexture).Play();
    }

    void OnMouseDown()
    {
        loadingSplash.SetActive(true);
        StartCoroutine(LoadScene());
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material = defaultImage;
        ((MovieTexture)video.mainTexture).Stop();
    }

    //loads sceen asyinc and starts loading icon
    IEnumerator LoadScene()
    {

        //yield return new WaitForSeconds(3);

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneToLoad);
        async.allowSceneActivation = false;

        while (async.progress < 0.9f)
        {
            loadingIcon.GetComponent<LoadingIcon>().loadingPercentage = async.progress + 0.1f;
            yield return null;
        }

        loadingIcon.GetComponent<LoadingIcon>().loadingPercentage = async.progress + 0.1f;

        while(loadingIcon.GetComponent<LoadingIcon>().fillAmount < 0.95f)
            yield return null;

        async.allowSceneActivation = true;
        yield return null;


    }
}
