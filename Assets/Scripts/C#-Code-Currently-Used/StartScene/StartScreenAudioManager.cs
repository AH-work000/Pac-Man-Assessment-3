using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenAudioManager : MonoBehaviour
{
    // Fields (Member Variables)
    AudioClip introBackgroundMusic;
    AudioSource startScreenAudioSource;
    bool isNotPlayed;

    public void initialize(AudioClip introBackgroundMusic, AudioSource startScreenAudioSource)
    {
        this.introBackgroundMusic = introBackgroundMusic;
        this.startScreenAudioSource = startScreenAudioSource;
    }


    // Start is called before the first frame update
    void Start()
    {
        isNotPlayed = true;

    }

    // Update is called once per frame
    void Update()
    {

   
        if (isNotPlayed)
        {
            playIntroMusic();
        } 

    }

    
    private void playIntroMusic()
    {
        startScreenAudioSource.clip = introBackgroundMusic;
        // Make the audiosource to have the introBackground Music Audio Clip
        startScreenAudioSource.volume = 0.5f;
        startScreenAudioSource.loop = true;
        startScreenAudioSource.Play(0);
        isNotPlayed = false;
    } 
}
