using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManAnimationPlayer : MonoBehaviour
{
    // Fields
    public Animator animController;

    /* Input testing code IGNORE:
            private bool notAtRightPosition;
            private bool notAtDownPosition;
            private bool notAtUpPosition;
            private bool notAtLeftPosition;
    */

    // Start is called before the first frame update
    void Start()
    {
        /* Input testing code IGNORE:
                // Initialize the position bools
                notAtRightPosition = true;
                notAtDownPosition = true;
                notAtUpPosition = true;
                notAtLeftPosition = true;
        */

    }

    // Update is called once per frame
    void Update()
    {
        /* Input testing code IGNORE: 
                // If the "D" Key or the Right Arrow Key is pressed then Pac-Man shifts to its Right Animation. 
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (notAtRightPosition)
                    {
                        animController.SetTrigger("SwitchRightAnim");
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
                        animController.SetTrigger("SwitchDownAnim");
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
                        animController.SetTrigger("SwitchUpAnim");
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
                        animController.SetTrigger("SwitchLeftAnim");
                        notAtLeftPosition = false;
                        notAtUpPosition = true;
                        notAtRightPosition = true;
                        notAtDownPosition = true;
                    }
                }

                // If the "K" Key is pressed then Pac-Man shifts to play its death Animation.
                if (Input.GetKeyDown(KeyCode.K))
                    animController.SetTrigger("SwitchDeadAmin");

        */


        // Below code to automatically play the animation

            // Play the Right-Movement Animation
            InvokeRepeating("playRightAnim", 0f, 29f);

            // Play the Down-Movement Animation
            InvokeRepeating("playDownAnim", 6f, 29f);

            // Play the Upwards-Movement Animation
            InvokeRepeating("playUpAnim", 12f, 29f);

            // Play the Left-Movement Animation
            InvokeRepeating("playLeftAnim", 18f, 29f);

            // Play the Death Animation
            InvokeRepeating("playDeathAnim", 24f, 29f);

            // Exit out of the Animation Cycle
            InvokeRepeating("playExit", 26f, 29f);
    }

    // Helper Methods
    private void playRightAnim()
    {
        animController.SetTrigger("SwitchRightAnim");
    }


    private void playDownAnim()
    {
        animController.ResetTrigger("SwitchRightAnim");
        animController.SetTrigger("SwitchDownAnim");
    }

    private void playUpAnim()
    {
        animController.ResetTrigger("SwitchDownAnim");
        animController.SetTrigger("SwitchUpAnim");
    }

    private void playLeftAnim()
    {
        animController.ResetTrigger("SwitchUpAnim");
        animController.SetTrigger("SwitchLeftAnim");
    }

    private void playDeathAnim()
    {
        animController.ResetTrigger("SwitchLeftAnim");
        animController.SetTrigger("SwitchDeadAnim");
    }

    private void playExit()
    {
        animController.ResetTrigger("SwitchDeadAnim");
        animController.SetTrigger("Exit");
    }
}
