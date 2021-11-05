using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Public Member Variables
    public AudioClip pacManMovementSound;
    public AudioClip pacManEatPelletSound;
    public AudioSource pacManAudioSource;


    // Function to play the pacManMovementSound when it is called
    public void playMovementSound()
    {
        pacManAudioSource.clip = pacManMovementSound;
        pacManAudioSource.volume = 1.25f;
        pacManAudioSource.Play();
    }


    // Function to play the pacManEatPelletSound when it is called
    public void playEatPelletSound()
    {
        pacManAudioSource.clip = null;
        pacManAudioSource.clip = pacManEatPelletSound;
        pacManAudioSource.volume = 1.25f;
        pacManAudioSource.Play();
    }






}
