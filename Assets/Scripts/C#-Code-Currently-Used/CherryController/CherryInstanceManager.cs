using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryInstanceManager : MonoBehaviour
{
    // Private Member Fields
    Coroutine lerpCoroutine;
    bool coroutineActivated = true;

    private void Update()
    {

        if (lerpCoroutine == null && coroutineActivated)
        {
            lerpCoroutine = StartCoroutine(doLerp(gameObject));
            coroutineActivated = false;
        }
            
       
    
    }


    IEnumerator doLerp(GameObject newCherryInstance)
    {
        float eplasedTime = 0;

        Vector3 endPos = new Vector3(newCherryInstance.transform.position.x + 120.0f, newCherryInstance.transform.position.y);

        // yield return null;
        while (eplasedTime < 10000.0f)
        {
            newCherryInstance.transform.position = Vector3.Lerp(newCherryInstance.transform.position, endPos, eplasedTime / 10000.0f);
            eplasedTime += Time.deltaTime;
            if (newCherryInstance.transform.position.x >= 50.0f)
            {
                destroyCherry();
            }
            yield return null;
        }

        newCherryInstance.transform.position = endPos;
    }


    // destroyCherry method
    public void destroyCherry()
    {
        Debug.Log("Object is getting Destroyed!");
        Destroy(gameObject);
    }

}
