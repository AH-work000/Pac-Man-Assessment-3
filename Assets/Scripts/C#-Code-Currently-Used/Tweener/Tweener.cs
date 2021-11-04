using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    // Private Member Variable: List of currentTweens
    private List<Tween> currentTweens;


    // Start is called before the first frame update
    void Start()
    {
        // Initialize the currentTweeens list
        currentTweens = new List<Tween>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Declare a new variable called selectedTween
        Tween selectedTween;


        // Loop through the currentTweens list
        for (int i = currentTweens.Count-1; i >= 0; i--)
        {
            // Designate the element of the tween that the loop is at as the selectedTween
            selectedTween = currentTweens[i];

            // Check if the Vector3 distance is less than 0.1f
            if (Vector3.Distance(selectedTween.objectTransform.position, selectedTween.endPos) > 0.0f)
            {
                // Calculate the main lerpMovement of the GameObject
                float timeFraction = (Time.time - selectedTween.startTime) / selectedTween.duration;
                selectedTween.objectTransform.position = Vector3.Lerp(selectedTween.startPos, selectedTween.endPos, timeFraction);
            }
            else
            {
            // Remove the selectedTween from the currentTweens list
            currentTweens.RemoveAt(i);
            }
        }

    }


    // Public Method for adding a new Tween
    public bool AddTween(Transform objectTransform, Vector3 startPos, Vector3 endPos, float duration)
    {
        // Check if the same tween already exists in the list
        if (!TweenExists(objectTransform))
        {
            // If the tween to be added doesn't match, then add that tween into the list
            currentTweens.Add(new Tween(objectTransform, startPos, endPos, Time.time, duration));
            return true;
        }

        // Otherwise, return false when there's a match found
        return false;
    }


    // TweenExists Method to check if there's already tween in the currentTweens list
    // Utilise the match pattern (function)
    public bool TweenExists(Transform targetTransform)
    {
        foreach (Tween selectedTween in currentTweens)
        {
            if (selectedTween.objectTransform.transform == targetTransform)
                return true;
        }

        // Otherwise return false when there's not match found
        return false;
    }
}
