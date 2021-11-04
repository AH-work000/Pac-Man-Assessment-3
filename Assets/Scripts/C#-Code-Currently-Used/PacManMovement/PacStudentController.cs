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
    bool isLerpNotHappening;
    Vector3Int currentCellPosition;
    Vector3Int previousCellPosition;


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

        // Check the last input from the player when the pacStudent have finished lerping
        if (isLerpNotHappening)
        {
            checkLastInput(lastInput);
            Debug.Log("The current Cell Position of PacStudent is: " + currentCellPosition);
        }
            
    }

    // Method for doing the lerpMovement between each grid
    private void lerpMovement(Transform pacStudentTransform, Vector3 startPos, Vector3 endPos, float startTime, float duration)
    {
        // Main Lerp Movement
        float timeFraction = (Time.time - startTime) / duration;
        Debug.Log("The timeFraction is: "+ timeFraction);
        pacStudentTransform.position = Vector3.Lerp(startPos, endPos, timeFraction);


        // Convert the position of pacStudent to its currentCellPosition counterpart
        currentCellPosition = levelOneGrid.WorldToCell(pacStudentTransform.position);

        // If currentCellPosition does not equal to the previousCellPosition, then lerp ends 
        if (previousCellPosition == currentCellPosition)
        {
            isLerpNotHappening = true;
        }
    }

    // Check the lastInput of the pacStudent to determine whether the movement is permissible or not
    private void checkLastInput(char lastInput)
    {
        Vector3 pacStudentPosition = pacStudent.transform.position;

        // If the lastInput is 'W', then move 1.3f (One grid up) up
        if (lastInput == 'W')
        {
            // Store the currentCellPosition of pacStudent into the previousCellPositon variable
            previousCellPosition = levelOneGrid.WorldToCell(pacStudentPosition);
            Debug.Log("The Previous Cell Position of PacStudent is: " + previousCellPosition);
            lerpMovement(pacStudent.transform, pacStudentPosition, new Vector3(pacStudentPosition.x, pacStudentPosition.y + 1.3f, pacStudentPosition.z), Time.time, 1.5f);
            pacStudentAnimator.SetTrigger("Up");
            isLerpNotHappening = false;
        } 
    }

}
