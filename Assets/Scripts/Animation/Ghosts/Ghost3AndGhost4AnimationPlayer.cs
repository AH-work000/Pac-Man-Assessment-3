using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost3AndGhost4AnimationPlayer : MonoBehaviour
{
    // Fields
    public Animator animController;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Below code to automatically play the animation

        // Play the Right-Movement Animation
        InvokeRepeating("playRightAnim", 0f, 35f);

        // Play the Down-Movement Animation
        InvokeRepeating("playDownAnim", 0f, 35f);

        // Play the Death Animation
        InvokeRepeating("playDeathAnim", 3f, 35f);

        // Exit out of the Animation Cycle
        InvokeRepeating("playExit", 6f, 35f);

        // Play the Right-Movement Animation
        InvokeRepeating("playRightAnim", 9f, 35f);

        // Play the Down-Movement Animation
        InvokeRepeating("playDownAnim", 12f, 35f);

        // Play the Upwards-Movement Animation
        InvokeRepeating("playUpAnim", 15f, 35f); // +3

        // Play the Left-Movement Animation
        InvokeRepeating("playLeftAnim", 18f, 35f); // +3

        // Play the Scared-State Animation
        InvokeRepeating("playScaredState", 20f, 35f); // + 2

        // Play the Recovering-State Animation
        InvokeRepeating("playRecoverState", 26f, 35f); // + 6

        // Play the Right-Movement Animation
        InvokeRepeating("playRightAnimAfterScared", 32f, 35f); // +6 
        /*
        // Play the Death Animation
        InvokeRepeating("playDeathAnim", 26f, 27f);
        
        // Exit out of the Animation Cycle
        InvokeRepeating("playExit", 27f, 29f);
        */

    }

    // Helper Methods -- 1st Level 
    private void playRightAnim()
    {
        animController.SetTrigger("SwitchRightAnim");
    }

    private void playRightAnimAfterScared()
    {
        animController.ResetTrigger("SwitchRecoveringAnim");
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

    private void playScaredState()
    {
        animController.ResetTrigger("SwitchLeftAnim");
        animController.SetTrigger("SwitchScaredAnim");
    }

    private void playDeathAnim()
    {
        animController.ResetTrigger("SwitchRightAnim");
        animController.SetTrigger("SwitchDeadAnim");
    }

    private void playExit()
    {
        animController.ResetTrigger("SwitchDeadAnim");
        animController.SetTrigger("Exit");
    }


    private void playRecoverState()
    {
        animController.ResetTrigger("SwitchScaredAnim");
        animController.SetTrigger("SwitchRecoveringAnim");
    }
}

