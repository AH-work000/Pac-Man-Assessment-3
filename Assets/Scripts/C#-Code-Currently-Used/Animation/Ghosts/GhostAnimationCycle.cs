using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnimationCycle : MonoBehaviour
{
    // Fields -- Normal
    public Animator ghost1Animator;
    public Animator ghost2Animator;
    public Animator ghost3Animator;
    public Animator ghost4Animator;
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
            currentCoroutine = StartCoroutine(StartAnimationCycle());
            isAnimCycleNotEnabled = false;
        }
        else
        {
            currentCoroutine = null;
        }

    }

    IEnumerator StartAnimationCycle()
    {
        // Do the Left Movement Cycle First
        StartCoroutine(doLeftMovementCycle(ghost1Animator));
        StartCoroutine(doLeftMovementCycle(ghost2Animator));
        StartCoroutine(doLeftMovementCycle(ghost3Animator));
        StartCoroutine(doLeftMovementCycle(ghost4Animator));

        yield return new WaitForSeconds(15.0f);

        // Then the Right Movement Cycle ...
        StartCoroutine(doRightMovementCycle(ghost1Animator));
        StartCoroutine(doRightMovementCycle(ghost2Animator));
        StartCoroutine(doRightMovementCycle(ghost3Animator));
        StartCoroutine(doRightMovementCycle(ghost4Animator));

        yield return new WaitForSeconds(15.0f);

        // Then the Up Movement Cycle ...
        StartCoroutine(doUpMovementCycle(ghost1Animator));
        StartCoroutine(doUpMovementCycle(ghost2Animator));
        StartCoroutine(doUpMovementCycle(ghost3Animator));
        StartCoroutine(doUpMovementCycle(ghost4Animator));

        yield return new WaitForSeconds(15.0f);

        // And finally the Down Movement Cycle ...
        StartCoroutine(doDownMovementCycle(ghost1Animator));
        StartCoroutine(doDownMovementCycle(ghost2Animator));
        StartCoroutine(doDownMovementCycle(ghost3Animator));
        StartCoroutine(doDownMovementCycle(ghost4Animator));

        yield return new WaitForSeconds(15.0f);

        // The Death Animation Cycle
        StartCoroutine(doDeathAnimCycle(ghost1Animator));
        StartCoroutine(doDeathAnimCycle(ghost2Animator));
        StartCoroutine(doDeathAnimCycle(ghost3Animator));
        StartCoroutine(doDeathAnimCycle(ghost4Animator));

        yield return new WaitForSeconds(15.0f);


        // Set isAnimCycleEnabled to be true at the end of the cycle
        isAnimCycleNotEnabled = true;
        }

    // Supplementary Methods

    IEnumerator doLeftMovementCycle(Animator animator)
    {
        // Do the Left Movement Cycle First
        animator.SetTrigger("Left");
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("Left");
        animator.SetTrigger("ScaredLeft");
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("ScaredLeft");
        animator.SetTrigger("RecoveringLeft");
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("RecoveringLeft");
        animator.SetTrigger("Left");
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("Left");
        animator.SetTrigger("Right");
    }


    IEnumerator doRightMovementCycle(Animator animator)
    {
        // Then the Right Movement Cycle ...
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("Right");
        animator.SetTrigger("ScaredRight");
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("ScaredRight");
        animator.SetTrigger("RecoveringRight");
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("RecoveringRight");
        animator.SetTrigger("Right");
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("Right");
        animator.SetTrigger("Up");
    }


    IEnumerator doUpMovementCycle(Animator animator)
    {
        // Then the Up Movement Cycle ...
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("Up");
        animator.SetTrigger("ScaredUp");
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("ScaredUp");
        animator.SetTrigger("RecoveringUp");
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("RecoveringUp");
        animator.SetTrigger("Up");
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("Up");
        animator.SetTrigger("Down");
    }

    IEnumerator doDownMovementCycle(Animator animator)
    {
        // And finally the Down Movement Cycle ...
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("Down");
        animator.SetTrigger("ScaredDown");
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("ScaredDown");
        animator.SetTrigger("RecoveringDown");
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("RecoveringDown");
        animator.SetTrigger("Down");
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("Down");
        animator.SetTrigger("Left");
    }

    IEnumerator doDeathAnimCycle(Animator animator)
    {
        // The Death Animation Cycle
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("Left");
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(3.0f);
        animator.ResetTrigger("Death");
        animator.SetTrigger("endDeath");
    }

}

