using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualLevelGeneratorManager : MonoBehaviour
{
    // Members Variables (The Fields)
    private Sprite[] tilemaps;
    public Sprite empty; 
    public Sprite outsideCorner;
    public Sprite outsideWall;
    public Sprite insideCorner;
    public Sprite insideWall;
    public Sprite emptySpace;
    public Sprite standardPellet;
    public Sprite powerPellet;
    public Sprite junctionPiece;
    public int levelMapPos;


    // The 2D Array Layout Map for Level 2
    int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
    };

    // Private Variables on the total x and y values of the entire levelMap
    private float yPos = 15.0f;
    private float xPos = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel1();
    }


    private void GenerateLevel1()
    {
        // Declare the Length of the array
        tilemaps = new Sprite[8];


        // Assign the Sprites public memebers to the tilemaps array
        tilemaps[0] = empty; 
        tilemaps[1] = outsideCorner;
        tilemaps[2] = outsideWall;
        tilemaps[3] = insideCorner;
        tilemaps[4] = insideWall;
        tilemaps[5] = emptySpace;
        tilemaps[6] = emptySpace;
        tilemaps[7] = junctionPiece;


        // Loop the 2D array by its rows value
        for (int r = 0; r < 14; r++)
        {
            // Loop through each of the individual values in the row by column
            for (int col = 0; col < 14; col++) {

                // Loop through each of the elements in the tilesmap array
                for (int i = 0; i < tilemaps.GetLength(0); i++)
                {
                    levelMapPos = levelMap[r, col];

                    // When the elements of the tilesmap matches the 
                    if (i == levelMapPos)
                    {
                        CreateNewTile(tilemaps[i], xPos, yPos, levelMap[r,0]);


                        if (xPos <= 12.0)
                        {
                            // Increment the x value
                            xPos++;
                        }
                        else
                        {
                            xPos = 0.0f;
                        }
                    }

                }
             
            }
                // Decrement the y value
                yPos--;
        }


    }


    private void CreateNewTile(Sprite selectSprite, float xPos, float yPos, int leftEdgePos)
    {
        GameObject gameObject = new GameObject("X-Position: " + xPos + "Y-Position" + yPos);
        Debug.Log("New GameObject created at: " + xPos + " , " + yPos); 
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        gameObject.transform.position = new Vector3(xPos, yPos);

        // Check if tile is on a edge position of an array 
        if (levelMapPos == leftEdgePos)
        {
           gameObject.transform.Rotate(new Vector3(0, 0, 90f));
        }

        SpriteRenderer newSpriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        newSpriteRenderer.sprite = selectSprite;
    }




    /* for loop (array-loop) pattern reference:
     * 
     * JAVA 
     *  for (int i = 0; i < <array>.length; i++) 
     *  {
     *      DO SOMETHING!!!!
     *  }
     *  
     *  
     *  C#
     *  for (int i = 0; i < <array>.GetLength(n); i++) 
     *  {
     *      DO SOMETHING!!!
     *  } 
     * 
     * 
     */


    
}
