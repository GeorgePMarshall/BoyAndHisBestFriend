using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

    bool isPaused;
    [SerializeField]GameObject menu;
    [SerializeField]GameObject backDrop;
    [SerializeField]GameObject antiRayBarrier;
    [SerializeField]GameObject musicSource;
    [SerializeField]GameObject[] soundEffects;

	// Use this for initialization
	void Start ()
    {
        isPaused = false;

        musicSource.GetComponent<AudioSource>().volume = 0.3f;
        foreach (GameObject soundEffect in soundEffects)
        {
            soundEffect.GetComponent<AudioSource>().volume = 0.3f;
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
                Pause();
            else
                Play();

        }
    }

    public void Play()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        backDrop.SetActive(false);
        antiRayBarrier.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
        backDrop.SetActive(true);
        antiRayBarrier.SetActive(true);
    }

    public void MusicSliderChanged(float value)
    {
        musicSource.GetComponent<AudioSource>().volume = value;
    }

    public void SoundEffectSliderChanged(float value)
    {
        foreach(GameObject soundEffect in soundEffects)
        {
            soundEffect.GetComponent<AudioSource>().volume = value;
        }   
    }

    public void QuitGame()
    {
        Time.timeScale = 1;

        if (SceneManager.GetActiveScene().name == "PhotoAlbum")
            Application.Quit();
        else
            SceneManager.LoadScene("PhotoAlbum");
    }



}
