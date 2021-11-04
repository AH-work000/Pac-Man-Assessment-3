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
    bool isLerpNotHappening;
    Vector3Int cellPosAfterLerp;
    Vector3Int cellPosBeforeLerp;
    Coroutine lerpCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        isLerpNotHappening = true;
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

        // Print out the lastInput
        Debug.Log("Player Input: " + lastInput);

        // Check the last input from the player when the pacStudent have finished lerping
        if (lerpCoroutine == null && isLerpNotHappening)
        {
            currentInput = lastInput;
            // Store the currentCellPosition of pacStudent into the previousCellPositon variable
            cellPosBeforeLerp = levelOneGrid.WorldToCell(pacStudent.transform.position);
            Debug.Log("The Previous Cell Position of PacStudent is: " + cellPosBeforeLerp);

            lerpCoroutine = StartCoroutine(doLerpMovement(currentInput));
        }
            
    }


    // Check the lastInput of the pacStudent to determine whether the movement is permissible or not
    IEnumerator doLerpMovement(char currentInput)
    {
        // Make the lerpCoroutine to be null 
        lerpCoroutine = null;


        // If the lastInput is 'W', then move 1.3f (One grid up) up
        if (currentInput == 'W')
        {
            isLerpNotHappening = false;

            // Change the anim of pacStudent to be up
            pacStudentAnimator.SetTrigger("Up");

            yield return null;

            // Add tweener for pacStudent
            tweenerManager.AddTween(pacStudent.transform, pacStudent.transform.position, new Vector3(pacStudent.transform.position.x, pacStudent.transform.position.y + 1.3f), 1.5f);

            // Check the currentCellPosition of pacStudent
            cellPosAfterLerp = levelOneGrid.WorldToCell(pacStudent.transform.position);
            Debug.Log("The Current Cell Position of PacStudent is: " + cellPosAfterLerp);

            // Set isLerpNotHappening to true as the movement process has been completed
            isLerpNotHappening = true;
        }


    } 
}
