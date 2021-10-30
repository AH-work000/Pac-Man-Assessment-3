using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnimationCycle : MonoBehaviour
{
    // Fields -- Normal
    public Animator ghostAnimator;
    bool isAnimCycleNotEnabled;

    // Fields -- Coroutine
    Coroutine currentCoroutine; 

    // Start is called before the first frame update
    void Start()
    {
        isAnimCycleNotEnabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCoroutine == null && isAnimCycleNotEnabled)
        {
            currentCoroutine = StartCoroutine(AnimationCycle());
            isAnimCycleNotEnabled = false;
        }
        else
        {
            currentCoroutine = null;
        }

    }

    IEnumerator AnimationCycle()
    {
        // Do the Left Movement Cycle First
        ghostAnimator.SetTrigger("Left");
        yield return new WaitForSeconds(1.0f);
        ghostAnimator.ResetTrigger("Left");
        ghostAnimator.SetTrigger("ScaredLeft");
        yield return new WaitForSeconds(0.5f);
        ghostAnimator.ResetTrigger("ScaredLeft");
        ghostAnimator.SetTrigger("RecoveringLeft");
        yield return new WaitForSeconds(1.0f);
        ghostAnimator.ResetTrigger("RecoveringLeft");
        ghostAnimator.SetTrigger("Left");
        yield return new WaitForSeconds(0.5f);
        ghostAnimator.ResetTrigger("Left");
        ghostAnimator.SetTrigger("Right");

        // Then the Right Movement Cycle ...
        yield return new WaitForSeconds(1.0f);
        ghostAnimator.ResetTrigger("Right");
        ghostAnimator.SetTrigger("ScaredRight");
        yield return new WaitForSeconds(1.0f);
        ghostAnimator.ResetTrigger("ScaredRight");
        ghostAnimator.SetTrigger("RecoveringRight");
        yield return new WaitForSeconds(1.0f);
        ghostAnimator.ResetTrigger("RecoveringRight");
        ghostAnimator.SetTrigger("Right");
        yield return new WaitForSeconds(1.0f);
        ghostAnimator.ResetTrigger("Right");
        ghostAnimator.SetTrigger("Up");


        // Then the Up Movement Cycle ...
        yield return new WaitForSeconds(3.0f);
        ghostAnimator.ResetTrigger("Up");
        ghostAnimator.SetTrigger("ScaredUp");
        yield return new WaitForSeconds(3.0f);
        ghostAnimator.ResetTrigger("ScaredUp");
        ghostAnimator.SetTrigger("RecoveringUp");
        yield return new WaitForSeconds(3.0f);
        ghostAnimator.ResetTrigger("RecoveringUp");
        ghostAnimator.SetTrigger("Up");
        yield return new WaitForSeconds(3.0f);
        ghostAnimator.ResetTrigger("Up");
        ghostAnimator.SetTrigger("Down");


        // And finally the Down Movement Cycle ...
        yield return new WaitForSeconds(3.0f);
        ghostAnimator.ResetTrigger("Down");
        ghostAnimator.SetTrigger("ScaredDown");
        yield return new WaitForSeconds(3.0f);
        ghostAnimator.ResetTrigger("ScaredDown");
        ghostAnimator.SetTrigger("RecoveringDown");
        yield return new WaitForSeconds(3.0f);
        ghostAnimator.ResetTrigger("RecoveringDown");
        ghostAnimator.SetTrigger("Down");
        yield return new WaitForSeconds(3.0f);
        ghostAnimator.ResetTrigger("Down");
        ghostAnimator.SetTrigger("Left");

        // The Death Animation Cycle
        yield return new WaitForSeconds(3.0f);
        ghostAnimator.ResetTrigger("Left");
        ghostAnimator.SetTrigger("Death");
        yield return new WaitForSeconds(3.0f);
        ghostAnimator.ResetTrigger("Death");
        ghostAnimator.SetTrigger("endDeath");

        // Set isAnimCycleEnabled to be true at the end of the cycle
        isAnimCycleNotEnabled = true;
        }
    }
