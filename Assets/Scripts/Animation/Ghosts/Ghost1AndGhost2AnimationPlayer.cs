using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost1AndGhost2AnimationPlayer : MonoBehaviour
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
        InvokeRepeating("playRightAnim", 0f, 33f);

        // Play the Down-Movement Animation
        InvokeRepeating("playDownAnim", 0f, 33f);

        // Play the Upwards-Movement Animation
        InvokeRepeating("playUpAnim", 3f, 33f);
        
        // Play the Left-Movement Animation
        InvokeRepeating("playLeftAnim", 6f, 33f);
        
        // Play the Scared-State Animation
        InvokeRepeating("playScaredState", 8f, 33f);
        
        // Play the Recovering-State Animation
        InvokeRepeating("playRecoverState", 14f, 33f);
        
        // Play the Right-Movement Animation
        InvokeRepeating("playRightAnimAfterScared", 20f, 33f);
        
        // Play the Death Animation
        InvokeRepeating("playDeathAnim", 26f, 33f);
       
        // Exit out of the Animation Cycle
        InvokeRepeating("playExit", 30.5f, 33f);
       
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
