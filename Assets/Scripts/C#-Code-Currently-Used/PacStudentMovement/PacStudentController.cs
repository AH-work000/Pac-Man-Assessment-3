using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    // Public Member Variables
    public GameObject pacStudent;
    public Grid levelOneGrid;
    public Animator pacStudentAnimator;

    // Private Member Variables
    char lastInput;
    char currentInput;


    // Private Member Variables for Lerping
    Coroutine lerpCoroutine;
    bool isLerpOff;



    // Start is called before the first frame update
    void Start()
    {
        // Initialize both the isLerpOff and isWalkable bools
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

        // Check the last input from the player when the pacStudent have finished lerping
        if (isLerpOff)
        {
            currentInput = lastInput;
            decideLerpDirection(currentInput);
        }
    }

    private void decideLerpDirection(char currentInput)
    {
        // If the currentInput is 'W', then move 1.3f up (Go One Grid Above)
        if (currentInput == 'W')
        {
            isLerpOff = false;

            StartCoroutine(doLerp(new Vector3(pacStudent.transform.position.x, pacStudent.transform.position.y + 1.3f,
            pacStudent.transform.position.z), 0.3f, "Up"));

            isLerpOff = true;
        }
    }


    /* 
     * Function to do the Lerp movement for pacStudent
     * 
     * Note: I have researched how to do apply this Lerp to the grid movement of PacStudent. 
     * The link to the resource is down below:
     * https://gamedevbeginner.com/the-right-way-to-lerp-in-unity-with-examples/
     * 
     */

    IEnumerator doLerp(Vector3 endPos, float duration, string animParam)
    {
        float eplasedTime = 0;

        // Play the Up Anim of PacStudent -- "Up" keyword
        pacStudentAnimator.SetTrigger(animParam);

        while (eplasedTime < duration)
        {
            pacStudent.transform.position = Vector3.Lerp(pacStudent.transform.position, endPos, eplasedTime / duration);
            eplasedTime += Time.deltaTime;
            yield return null;
        }
        pacStudent.transform.position = endPos;
    }



    /*


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

        // Check the last input from the player when the pacStudent have finished lerping
        if (lerpCoroutine == null && isLerpOff)
        {
            currentInput = lastInput;

            lerpCoroutine = StartCoroutine(decideLerpDirection(currentInput));

            // Make the lerpCoroutine to be null
            lerpCoroutine = null;
        }


    }

    IEnumerator decideLerpDirection(char currentInput)
    {
        if (currentInput == 'W')
        {
            // Set the isLerpOff to be false as lerp movement is going to happen
            isLerpOff = false;

            // Change the anim of pacStudent to be up
            pacStudentAnimator.SetTrigger("Up");

            addTween(new Vector3(pacStudent.transform.position.x, pacStudent.transform.position.y + 1.0f, pacStudent.transform.position.z));

            yield return null; // new WaitForSeconds(3.0f);

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

            addTween(new Vector3(pacStudent.transform.position.x - 1.0f, pacStudent.transform.position.y));

            yield return null; // new WaitForSeconds(3.0f);

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

            addTween(new Vector3(pacStudent.transform.position.x, pacStudent.transform.position.y - 1.0f));

            yield return null; // WaitForSeconds(3.0f);

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

            addTween(new Vector3(pacStudent.transform.position.x + 1.0f, pacStudent.transform.position.y));

            yield return null; // WaitForSeconds(3.0f);

            // Set the isLerpOff to true as the lerp movement is done
            isLerpOff = true;

        }
    }


    // addTween Coroutine to addTween to the pacStudent GameObject
    private void addTween(Vector3 endPos)
    {
        // Add tweener for pacStudent
        tweenerManager.AddTween(pacStudent.transform, pacStudent.transform.position, endPos, 1.5f);
    } */
}