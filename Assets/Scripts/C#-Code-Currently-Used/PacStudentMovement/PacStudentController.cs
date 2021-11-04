using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    // Public Member Variables
    public GameObject pacStudent;
    public Grid levelOneGrid;
    public Animator pacStudentAnimator;
    public Tweener tweenerManager;

    // Private Member Variables
    char lastInput;
    char currentInput;
    bool isLerpOff;
    Vector3Int cellPosAfterLerp;
    Vector3Int cellPosBeforeLerp;
    Coroutine lerpCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        isLerpOff = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current cell Position of the PacStudent GameObject
        // currentCellPosition = levelOneGrid.WorldToCell(pacStudent.transform.position);

        // Check if the player had input the 'W' key (Up)
        if (Input.GetKeyDown(KeyCode.W))
            lastInput = 'W';

        // Check if the player had input the 'A' Key (Left)
        if (Input.GetKeyDown(KeyCode.A))
            lastInput = 'A';

        // Check if the player had input the 'S' Key (Down)
        if (Input.GetKeyDown(KeyCode.S))
            lastInput = 'S';

        // Check if the player had input the 'D' Key (Right)
        if (Input.GetKeyDown(KeyCode.D))
            lastInput = 'D';

        if (lerpCoroutine == null && isLerpOff)
        {
            currentInput = lastInput;

            lerpCoroutine = StartCoroutine(decideLerpDirection(currentInput));

            // Make the lerpCoroutine to be null
            lerpCoroutine = null;
        }


        /*
        // Check the last input from the player when the pacStudent have finished lerping
        if (lerpCoroutine == null && isLerpOff)
        {
            lerpCoroutine = StartCoroutine(doLerpMovement(lastInput));

            // Make the lerpCoroutine to be null 
            lerpCoroutine = null;
        }*/
            
    }

    IEnumerator decideLerpDirection(char currentInput)
    {
        if (currentInput == 'W')
        {
            // Set the isLerpOff to be false as lerp movement is going to happen
            isLerpOff = false;

            // Change the anim of pacStudent to be up
            pacStudentAnimator.SetTrigger("Up");

            addTween(new Vector3(pacStudent.transform.position.x, pacStudent.transform.position.y + 1.3f, pacStudent.transform.position.z));

            // Debug.Log("Final Location of Lerp: " + new Vector3(pacStudent.transform.position.x, pacStudent.transform.position.y + 1.3f, pacStudent.transform.position.z));

            yield return new WaitForSeconds(0.1f);

            // Set the isLerpOff to true as the lerp movement is done
            isLerpOff = true;
        }

    }



    // addTween Coroutine to addTween to the pacStudent GameObject
    private void addTween(Vector3 endPos)
    {
        // Add tweener for pacStudent
        tweenerManager.AddTween(pacStudent.transform, pacStudent.transform.position, endPos, 1.5f);
    }
   



    /*


    IEnumerator doLerpMovement(char currentInput)
    {
        // Wait for the game to warm-up
        yield return new WaitForSeconds(3.0f);

        // If the currentInput is 'W', then move 1.3f (One grid up) up
        if (currentInput == 'W')
        {
            // Set the isLerpOff to be false as lerp movement is going to happen
            isLerpOff = false;

            // Change the anim of pacStudent to be up
            pacStudentAnimator.SetTrigger("Up");

            yield return StartCoroutine(addTween(new Vector3(pacStudent.transform.position.x, pacStudent.transform.position.y + 1.3f)));

            // Set the isLerpOff to true as the lerp movement is done
            isLerpOff = true;
        }


        // If the currentInput is 'A', then move 1.3f (One grid left) left
        if (currentInput == 'A')
        {
            // Set the isLerpOff to be false as lerp movement is going to happen
            isLerpOff = false;

            // Change the anim of pacStudent to be up
            pacStudentAnimator.SetTrigger("Left");

            yield return StartCoroutine(addTween(new Vector3(pacStudent.transform.position.x - 1.3f, pacStudent.transform.position.y)));

            // Set the isLerpOff to true as the lerp movement is done
            isLerpOff = true;
        }

        // If the currentInput is 'S', then move 1.3f (One grid down) down
        if (currentInput == 'S')
        {
            // Set the isLerpOff to be false as lerp movement is going to happen
            isLerpOff = false;

            // Change the anim of pacStudent to be up
            pacStudentAnimator.SetTrigger("Down");

            yield return StartCoroutine(addTween(new Vector3(pacStudent.transform.position.x, pacStudent.transform.position.y - 1.3f)));

            // Set the isLerpOff to true as the lerp movement is done
            isLerpOff = true;
        }


        // If the currentInput is 'D', then move 1.3f (One grid right) right
        if (currentInput == 'D')
        {
            // Set the isLerpOff to be false as lerp movement is going to happen
            isLerpOff = false;

            // Change the anim of pacStudent to be up
            pacStudentAnimator.SetTrigger("Right");

            yield return StartCoroutine(addTween(new Vector3(pacStudent.transform.position.x + 1.3f, pacStudent.transform.position.y)));

            // Set the isLerpOff to true as the lerp movement is done
            isLerpOff = true;
        }

    }


    // addTween Coroutine to addTween to the pacStudent GameObject
    IEnumerator addTween(Vector3 endPos)
    {
        // Add tweener for pacStudent
        tweenerManager.AddTween(pacStudent.transform, pacStudent.transform.position, endPos, 4.0f);
        yield return new WaitForSeconds(4.0f);
    }
    */


}
