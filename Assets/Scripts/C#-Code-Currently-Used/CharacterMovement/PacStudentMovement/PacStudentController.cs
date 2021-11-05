using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    // Public Member Variables
    public GameObject pacStudent;
    public Grid levelOneGrid;
    public Animator pacStudentAnimator;

    // Private Member Variables Bools
    char lastInput;
    char currentInput;


    // Private Member Variables for Lerping
    Coroutine decideLerpDirectionCoroutine;
    bool isLerpOff;


    // Private member Variables for Controlling Anims
    string currentAnim;


    // Start is called before the first frame update
    void Start()
    {
        // Initialize the isLerpOff bool variable
        isLerpOff = true;


        // Initialize the currentAnim variable to be "Left"
        currentAnim = "Left";
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current cell Position of the PacStudent GameObject
        // currentCellPosition = levelOneGrid.WorldToCell(pacStudent.transform.position);

        // Check if the player had input the 'W' key (Up) or the Up Arrow Key
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            lastInput = 'W';

        // Check if the player had input the 'A' Key (Left) or the Left Arrow Key
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            lastInput = 'A';

        // Check if the player had input the 'S' Key (Down) or the Down Arrow Key
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            lastInput = 'S';

        // Check if the player had input the 'D' Key (Right) or the Right Arrow Key
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            lastInput = 'D';

        // Check the last input from the player when the pacStudent have finished lerping
        if (isLerpOff && decideLerpDirectionCoroutine == null)
        {
            currentInput = lastInput;
            decideLerpDirectionCoroutine = StartCoroutine(decideLerpDirection(currentInput));
            decideLerpDirectionCoroutine = null;
        }
    }

    IEnumerator decideLerpDirection(char currentInput)
    {
        // If the currentInput is 'W' or Up Arrow Key, then move 1.3f up (Go One Grid Above)
        if (currentInput == 'W')
        {
            isLerpOff = false;

            // Change the Animation depending on the direction of the movement
            changeAnim("Up");

            StartCoroutine(doLerp(new Vector3(pacStudent.transform.position.x, pacStudent.transform.position.y + 1.3f,
            pacStudent.transform.position.z), 0.4f));

            yield return new WaitForSeconds(0.4f);

            isLerpOff = true;
        }

        // If the currentInput is 'A' or Left Arrow Key, then move 1.3f left (Go One Grid Left)
        if (currentInput == 'A')
        {
            isLerpOff = false;

            // Change the Animation depending on the direction of the movement
            changeAnim("Left");

            StartCoroutine(doLerp(new Vector3(pacStudent.transform.position.x - 1.3f, pacStudent.transform.position.y,
            pacStudent.transform.position.z), 0.4f));

            yield return new WaitForSeconds(0.4f);

            isLerpOff = true;
        }


        // If the currentInput is 'S' or Down Arrow Key, then move 1.3f down (Go One Grid Down)
        if (currentInput == 'S')
        {
            isLerpOff = false;

            // Change the Animation depending on the direction of the movement
            changeAnim("Down");


            StartCoroutine(doLerp(new Vector3(pacStudent.transform.position.x, pacStudent.transform.position.y - 1.3f,
            pacStudent.transform.position.z), 0.4f));

            yield return new WaitForSeconds(0.4f);

            isLerpOff = true;
        }


        // If the currentInput is 'D' or Right Arrow Key, then move 1.3f right (Go One Grid Right)
        if (currentInput == 'D')
        {
            isLerpOff = false;

            // Change the Animation depending on the direction of the movement
            changeAnim("Right");


            StartCoroutine(doLerp(new Vector3(pacStudent.transform.position.x + 1.3f, pacStudent.transform.position.y,
            pacStudent.transform.position.z), 0.4f));

            yield return new WaitForSeconds(0.4f);

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

    IEnumerator doLerp(Vector3 endPos, float duration)
    {
        float eplasedTime = 0;

        // yield return null;
        while (eplasedTime < duration)
        {
            pacStudent.transform.position = Vector3.Lerp(pacStudent.transform.position, endPos, eplasedTime / duration);
            eplasedTime += Time.deltaTime;
            yield return null;
        }
        pacStudent.transform.position = endPos;
    }


    // Changes the states of the Anim in the pacStudentAnimator
    private void changeAnim(string newAnimParam)
    {
        // Reset the old animation 
        pacStudentAnimator.ResetTrigger(currentAnim);

        // Set the trigger for the new animation
        pacStudentAnimator.SetTrigger(newAnimParam);

        // Make the newAnimParam to be the currentAnim
        currentAnim = newAnimParam;
    }

}