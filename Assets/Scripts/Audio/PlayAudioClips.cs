using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioClips : MonoBehaviour
{
    // Member Variables (Fields)
    public AudioClip introBackgroundMusic;
    private float introBackgroundMusicLength;
    public AudioClip backgroundMusicGhostNormalState;
    public AudioSource audioSource;
    public bool isPlayed;




    // Start is called before the first frame update
    void Start()
    {
        // Start off by plaing the intro music first
        audioSource.clip = introBackgroundMusic;
        introBackgroundMusicLength = introBackgroundMusic.length;
        audioSource.Play(0);


        // Initialize the isPlayed bool
        isPlayed = true;


    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > introBackgroundMusicLength && isPlayed)
        {
            // Method to playGhostNormalStateSound
            PlayGhostNormalStateSound();
            isPlayed = false;
        }


    }

    private void PlayGhostNormalStateSound()
    {
        audioSource.clip = backgroundMusicGhostNormalState;
        audioSource.loop = true;
        audioSource.volume = 0.5f;
        audioSource.Play();
    }

}
