using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    // Private Member Variables
    char lastInput;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player had input the 'W' key (Up)
        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = 'W';
        }

        // Check if the player had input the 'A' Key (Left)
        if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = 'A';
        }

        // Check if the player had input the 'S' Key (Down)
        if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = 'S';
        }

        // Check if the player had input the 'D' Key (Right)
        if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = 'D';
        }


        
    }
}
