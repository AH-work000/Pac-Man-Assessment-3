using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    // Member Variables
    public AudioClip introBackgroundMusic;
    public AudioSource audioSource;
    public GameObject audioControllerGameObject;
    private StartScreenAudioController startScreenAudioController; 

    


    void Awake()
    {
       // Get the StartScreenAudioController Component of the audioControllerGameObject
       startScreenAudioController = audioControllerGameObject.GetComponent<StartScreenAudioController>();


    }


    // Start is called before the first frame update
    void Start()
    {
        // Initialize the startScreenAudioController
        startScreenAudioController.initialize(introBackgroundMusic, audioSource);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadFirstLevel()
    {
        Debug.Log("Level 1 Button is Click!");
        Destroy(audioSource);
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }

}
