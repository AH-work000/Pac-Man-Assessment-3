using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManAnimation : MonoBehaviour
{
    // Fields
    public Animator animationController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            animationController.SetTrigger("RotateRightParam");
        }
    }
}
