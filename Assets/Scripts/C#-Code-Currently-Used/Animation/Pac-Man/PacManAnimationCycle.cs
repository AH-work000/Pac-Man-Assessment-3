using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManAnimationCycle : MonoBehaviour
{
    // Fields -- Normal
    public Animator playerAnimator;
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

        playerAnimator.SetTrigger("Left");
        yield return new WaitForSeconds(3.0f);
        playerAnimator.ResetTrigger("Left");
        playerAnimator.SetTrigger("Right");
        yield return new WaitForSeconds(3.0f);
        playerAnimator.ResetTrigger("Right");
        playerAnimator.SetTrigger("Up");
        yield return new WaitForSeconds(3.0f);
        playerAnimator.ResetTrigger("Up");
        playerAnimator.SetTrigger("Down");
        yield return new WaitForSeconds(3.0f);
        playerAnimator.ResetTrigger("Down");
        playerAnimator.SetTrigger("Death");
        yield return new WaitForSeconds(8.0f);
        playerAnimator.ResetTrigger("Death");
        playerAnimator.SetTrigger("endDeath");

        // Set isAnimCycleEnabled to be true at the end of the cycle
        isAnimCycleNotEnabled = true; 
    }


}
