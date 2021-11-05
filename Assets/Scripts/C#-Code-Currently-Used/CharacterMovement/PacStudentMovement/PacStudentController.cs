using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    // Public Member Variables
    public GameObject pacStudent;
    public Animator pacStudentAnimator;

    // Private Member Variables Bools
    private char lastInput;
    private char currentInput;
    private MapManager mapManager;
    private AudioManager audioManager;


    // Private Member Variables for Lerping
    Coroutine decideLerpDirectionCoroutine;
    bool isLerpOff;


    // Private member Variables for Controlling Anims
    string currentAnim;

    // Called before start()
    void Awake()
    {
        // Get the level1GameManager
        Level1GameManager level1GameManager = gameObject.GetComponentInParent<Level1GameManager>();

        // Get the mapManager and initialize it
        mapManager = level1GameManager.getMapManager();

        // Get the audioManager and initialize it
        audioManager = level1GameManager.getAudioManager();
    }



    // Start is called before the first frame update
    void Start()
    {
        // Initialize the isLerpOff bool variable
        isLerpOff = true;


        // Initialize the currentAnim variable to be "Left"
        currentAnim = "Left";

        // Set the currentRow and the currentCol to the default position that the pacStudent is in the Map Array
        mapManager.currentRowRef = 11;
        mapManager.currentColRef = 10;
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

            // Check if the adjacent Grid Position from the player's lastInput is walkable
            if (mapManager.checkAdjacentGrid(lastInput))
            {
                currentInput = lastInput;
                decideLerpDirectionCoroutine = StartCoroutine(decideLerpDirection(currentInput));

                    // Check if the current tileRef that the pacStudent is on right now is a pellet
                    if (mapManager.doTileRefHavePellet())
                    {
                        Debug.Log("Playing the Eat Pellet Sound");

                        // Play the eat pellet sound
                        audioManager.playEatPelletSound();
                    }    
                    else
                    {
                        // Play the Pac-Man Movement Sound
                        audioManager.playMovementSound();

                    }

                decideLerpDirectionCoroutine = null;
            }
            else
            {
                // Check if the adjacent Grid Position from the player's currentInput is walkable
                if (mapManager.checkAdjacentGrid(currentInput))
                {
                    // Then use the currentInput pos to lerp
                    decideLerpDirectionCoroutine = StartCoroutine(decideLerpDirection(currentInput));

                    // Check if the current tileRef that the pacStudent is on right now is a pellet
                    if (mapManager.doTileRefHavePellet())
                    {
                        Debug.Log("Playing the Eat Pellet Sound");

                        // Play the eat pellet sound
                        audioManager.playEatPelletSound();
                    }
                    else
                    {
                        // Play the Pac-Man Movement Sound
                        audioManager.playMovementSound();

                    }

                    decideLerpDirectionCoroutine = null;
                }
                else
                {
                    pacStudentAnimator.ResetTrigger(currentAnim);
                }
            }

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

            // Set the currentRowRef of pacStudent in the map array
            mapManager.currentRowRef -= 1;

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


            // Set the currentColRef of pacStudent in the map array
            mapManager.currentColRef -= 1;

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

            // Set the currentRowRef of pacStudent in the map array
            mapManager.currentRowRef += 1;

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

            // Set the currentColRef of pacStudent in the map array
            mapManager.currentColRef += 1;

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