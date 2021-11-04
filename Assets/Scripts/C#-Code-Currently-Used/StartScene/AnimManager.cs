using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    // Fields (Private Member Variables)
    GameObject cherryAnimGameObject;
    Canvas startScreenUICanvas;
    bool isCoroutineNotOn;
    Coroutine instantiatePrefabCoroutine;
    int cherryAnimCount;


    public void initialize(GameObject cherryAnimGameObject, Canvas startScreenUICanvas)
    {
        this.cherryAnimGameObject = cherryAnimGameObject;
        this.startScreenUICanvas = startScreenUICanvas;
    }


    // Start is called before the first frame update
    void Start()
    {
        isCoroutineNotOn = true;
        cherryAnimCount = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (instantiatePrefabCoroutine == null && isCoroutineNotOn && cherryAnimCount < 4)
        {
            instantiatePrefabCoroutine = StartCoroutine(addCherryAnimObject());
            isCoroutineNotOn = false;
        }

    }

    IEnumerator addCherryAnimObject()
    {
        yield return new WaitForSeconds(2.0f);
        Instantiate(cherryAnimGameObject, startScreenUICanvas.transform);
        instantiatePrefabCoroutine = null;
        isCoroutineNotOn = true;
        ++cherryAnimCount;
    }

}
