using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManAnimation : MonoBehaviour
{
    // Fields
    public Animator animationController;
    private bool notAtRightPosition;
    private bool notAtDownPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the position bools
        notAtRightPosition = true;
        notAtDownPosition = true;

    }

    // Update is called once per frame
    void Update()
    {
        // If the "D" Key or the Right Arrow Key is pressed then Pac-Man shifts to its Right Animation. 
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (notAtRightPosition)
            {
                animationController.SetTrigger("SwitchRightAmin");
                notAtDownPosition = true;
                notAtRightPosition = false;
            }

        }

        // If the "S" Key or the Downm Arrow Key is pressed then Pac-Man shifts to its Downwards Animation.
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(notAtDownPosition)
            {
                animationController.SetTrigger("SwitchDownwardsAmin");
                notAtRightPosition = true;
                notAtDownPosition = false;
            }
        }

    }
}
