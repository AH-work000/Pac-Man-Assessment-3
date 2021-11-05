using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    // Public Member Fields
    public GameObject bonusScoreCherry;


    // Private Member Fields
    Coroutine spawnCoroutine;
    bool isSpawningNotHappening;



    // Start is called before the first frame update
    void Start()
    {
        // Initialize the isSpawningNotHappening bool
        isSpawningNotHappening = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (spawnCoroutine == null && isSpawningNotHappening)
        {
            spawnCoroutine = StartCoroutine(spawnBonusCherry());
            isSpawningNotHappening = false;
        }
        
    }

    // The spawnBonusCherry method
    IEnumerator spawnBonusCherry()
    {
        // Wait for 10 seconds
        yield return new WaitForSeconds(10.0f);

        // Calculate a random number
        int randYCoordinate = Random.Range(-25,25);

        // Instantiate the new object
        Instantiate(bonusScoreCherry, new Vector3(-60, randYCoordinate, 0), Quaternion.identity);
        isSpawningNotHappening = true;
        spawnCoroutine = null;
    }
}
