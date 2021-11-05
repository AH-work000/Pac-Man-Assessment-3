using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void loadStartScreen()
    {
        SceneManager.LoadScene(0);
    }

    // Function to return the mapManager
    public MapManager getMapManager()
    {
        MapManager mapManager = gameObject.GetComponentInChildren<MapManager>();
        return mapManager;
    }


    // Function to return the audioManager
    public AudioManager getAudioManager()
    {
        AudioManager audioManager = gameObject.GetComponentInChildren<AudioManager>();
        return audioManager;
    }
}
