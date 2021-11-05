using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // pacStudentArrayRefPos Private Member Variable
    public int currentRowRef { get; set; }
    public int currentColRef { get; set; }

    // Declare a new string private member variable called tilesRef
    string tilesRef;

    // TilesRefArray Private Member Variable
    string[] tilesRefArray = new string[8];
    string[] nonBlockingTilesRefArray = new string[3];


    // Private Member Variable -- 2D Array of every tiles in this Level
    int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1},  // row: 0
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},  // row: 1
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},  // row: 2
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},  // row: 3
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},  // row: 4
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},  // row: 5
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},  // row: 6
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},  // row: 7
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},  // row: 8
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},  // row: 9
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},  // row: 10
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},  // row: 11
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0,0,4,4,3,0,4,4,5,2,0,0,0,0,0},  // row: 12
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},  // row: 13
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0,0,0,0,4,0,0,0,5,0,0,0,0,0,0},  // row: 14
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},  // row: 15 (13)
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0,0,4,4,3,0,4,4,5,2,0,0,0,0,0},  // row: 16 (12)
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},  // row: 17 (11)
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},  // row: 18 (10)
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},  // row: 19 (9)
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},  // row: 20 (8)
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},  // row: 21 (7)
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},  // row: 22 (6)
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},  // row: 23 (5)
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},  // row: 24 (4)
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},  // row: 25 (3)
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},  // row: 26 (2)
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},  // row: 27 (1)
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1}   // row: 28 (0)
    };



    // Start is called before the first frame update
    void Start()
    {
        // Add all of these elements into the tilesRefArray
        tilesRefArray[0] = "Empty";
        tilesRefArray[1] = "Outside-Corner";
        tilesRefArray[2] = "Outside-Wall";
        tilesRefArray[3] = "Inside-Corner";
        tilesRefArray[4] = "Inside-Wall";
        tilesRefArray[5] = "Standard-pellet";
        tilesRefArray[6] = "Power-pellet";
        tilesRefArray[7] = "Junction-piece";



        // Add all of these elements into the nonBlockingTilesRefArray
        nonBlockingTilesRefArray[0] = "Empty";
        nonBlockingTilesRefArray[1] = "Standard-pellet";
        nonBlockingTilesRefArray[2] = "Power-pellet";
    }


    // Function to check if the adjacent grid is walkable
    public bool checkAdjacentGrid(char lastInputKey)
    {

        // When the lastInputKey equals 'W' key (Up) or the Up Arrow Key 
        if (lastInputKey == 'W')
        {
            tilesRef = getAboveTileRef(currentRowRef, currentColRef);
        }


        // When the lastInputKey equals 'A' key (Left) or the Left Arrow Key
        if (lastInputKey == 'A')
        {
            tilesRef = getLeftTileRef(currentRowRef, currentColRef);
        }


        // When the lastInputKey equals 'S' key (Down) or the Down Arrow Key
        if (lastInputKey == 'S')
        {
            tilesRef = getBelowTileRef(currentRowRef, currentColRef);
        }


        // When the lastInputKey equals the 'D' key (Right) or the Right Arrow Key
        if (lastInputKey == 'D')
        {
            tilesRef = getRightTileRef(currentRowRef, currentColRef);
        }

        for (int i = 0; i < nonBlockingTilesRefArray.Length; i++)
        {
            if (tilesRef == nonBlockingTilesRefArray[i])
                return true;
        }

        return false;
    }


    // Get the reference of the left-tile
    private string getLeftTileRef(int rowRef, int colRef)
    {
        int refNumber = levelMap[rowRef, colRef - 1];
        return tilesRefArray[refNumber];
    }


    // Get the reference of the right-tile
    private string getRightTileRef(int rowRef, int colRef)
    {
        int refNumber = levelMap[rowRef, colRef + 1];
        return tilesRefArray[refNumber];
    }


    // Get the reference of the above-tile
    private string getAboveTileRef(int rowRef, int colRef)
    {
        int refNumber = levelMap[rowRef - 1, colRef];
        return tilesRefArray[refNumber];
    }


    // Get the reference of the below-tile
    private string getBelowTileRef(int rowRef, int colRef)
    {
        int refNumber = levelMap[rowRef + 1, colRef];
        return tilesRefArray[refNumber];
    }


    // Check if the tileRef has a Pellet
    public bool doTileRefHavePellet()
    {
        int refNumber = levelMap[currentRowRef, currentColRef];
        string tileRefName = tilesRefArray[refNumber];

        Debug.Log("Tile Reference Name: " + tileRefName);

        if (tileRefName == "Standard-pellet" || tileRefName == "Power-pellet")
        {
            return true;
        }

    return false;
    }

}
