using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    // Member Variables

    // Audio Managers Member Variables
    public AudioClip introBackgroundMusic;
    public AudioSource audioSource;
    public GameObject audioManagerGameObject;
    private StartScreenAudioManager startScreenAudioManager;

    // Animation Manager Member Variables
    public GameObject cherryAnimGameObject;
    public Canvas canvas;
    public GameObject animationManagerGameObject;
    private AnimManager animManager;
    

    
    void Awake()
    {
       // Get the StartScreenAudioManager Component of the audioManagerGameObject
       startScreenAudioManager = audioManagerGameObject.GetComponent<StartScreenAudioManager>();

        // Get the AnimManager Component of the  animationManagerGameObject
        animManager = animationManagerGameObject.GetComponent<AnimManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        // Initialize the startScreenAudioManager
        startScreenAudioManager.initialize(introBackgroundMusic, audioSource);

        // Initialize the animManager
        animManager.initialize(cherryAnimGameObject, canvas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadFirstLevel()
    {
        Debug.Log("Level 1 Button is Click!");
        Destroy(startScreenAudioManager);
        Destroy(animationManagerGameObject);
        SceneManager.LoadSceneAsync(1);
    }

}
