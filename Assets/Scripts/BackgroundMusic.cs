using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour
{

    [SerializeField]AudioClip musicLoop;
    AudioSource music;

    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


        if(!music.isPlaying)
        {
            music.clip = musicLoop;
            music.loop = true;
            music.Play();
        }



    }
}
