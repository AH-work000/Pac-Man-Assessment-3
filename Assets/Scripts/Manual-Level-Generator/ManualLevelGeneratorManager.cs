using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualLevelGeneratorManager : MonoBehaviour
{
    // Private Members (Variables)
    private Sprite[] tilemaps;
    public Sprite oustideCorner;
    public Sprite outsideWall;
    public Sprite insideCorner;
    public Sprite insideWall;
    public Sprite emptySpace;
    public Sprite standardPellet;
    public Sprite powerPellet;
    public Sprite junctionPiece;


    // The 2D Array





    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel1();
    }


    private void GenerateLevel1()
    {

        tilemaps = new Sprite[9];










    }




    /* for loop (array-loop) pattern reference:
     *  for (int i = 0; i < <array>.length; i++) 
     *  {
     *      DO SOMETHING!!!!
     *  }
     * 
     */


    // Rows = 14 (Starting from 0)
    

}
