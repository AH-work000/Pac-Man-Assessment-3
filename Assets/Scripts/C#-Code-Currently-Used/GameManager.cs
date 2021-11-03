using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{

    void Awake()
    {

    }


    // Start is called before the first frame update
    void Start()
    {

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadFirstLevel()
    {
        Debug.Log("Level 1 Button is Click!");
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
    }

}
