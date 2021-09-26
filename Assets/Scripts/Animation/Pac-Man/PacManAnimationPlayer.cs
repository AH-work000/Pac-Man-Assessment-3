using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManAnimationPlayer : MonoBehaviour
{
    // Fields
    public Animator animController;
    private bool notAtRightPosition;
    private bool notAtDownPosition;
    private bool notAtUpPosition;
    private bool notAtLeftPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the position bools
        notAtRightPosition = true;
        notAtDownPosition = true;
        notAtUpPosition = true;
        notAtLeftPosition = true;

    }

    // Update is called once per frame
    void Update()
    {
        // If the "D" Key or the Right Arrow Key is pressed then Pac-Man shifts to its Right Animation. 
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (notAtRightPosition)
            {
                animController.SetTrigger("SwitchRightAmin");
                notAtRightPosition = false;
                notAtDownPosition = true;
                notAtUpPosition = true;
                notAtLeftPosition = true;
            }

        }

        // If the "S" Key or the Down Arrow Key is pressed then Pac-Man shifts to its Downwards Animation.
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(notAtDownPosition)
            {
                animController.SetTrigger("SwitchDownAmin");
                notAtDownPosition = false;
                notAtRightPosition = true;
                notAtUpPosition = true;
                notAtLeftPosition = true;
            }
        }

        // If the "W" Key or the Up Arrow Key is pressed then Pac-Man shifts to its Upward Animation.
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (notAtUpPosition)
            {
                animController.SetTrigger("SwitchUpAmin");
                notAtUpPosition = false;
                notAtRightPosition = true;
                notAtDownPosition = true;
                notAtLeftPosition = true;
            }
        }

        // If the "A" Key or the Left Arrow Key is pressed then Pac-Man shifts to its Left Animation.
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(notAtLeftPosition)
            {
                animController.SetTrigger("SwitchLeftAmin");
                notAtLeftPosition = false;
                notAtUpPosition = true;
                notAtRightPosition = true;
                notAtDownPosition = true;
            }
        }

        // If the "K" Key is pressed then Pac-Man shifts to play its death Animation.
        if (Input.GetKeyDown(KeyCode.K))
            animController.SetTrigger("SwitchDeadAmin");
    }
}
