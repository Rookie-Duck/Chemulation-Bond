using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public GameObject targetObject; // Assign your target object here
    public float rotationSpeed = 50f; // Degrees per second

    private float currentDirection = 0f;
    private Quaternion initialRotation;

    void Start()
    {
        if (targetObject != null)
        {
            initialRotation = targetObject.transform.rotation;
        }
    }

    void Update()
    {
        if (targetObject != null && currentDirection != 0f)
        {
            targetObject.transform.Rotate(Vector3.up, currentDirection * rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    // These public methods will be called from the Interactable Unity Event Wrapper
    public void RotateLeft()
    {
        currentDirection = 1f;
    }

    public void RotateRight()
    {
        currentDirection = -1f;
    }

    public void StopRotation()
    {
        currentDirection = 0f;
    }

    public void ResetRotation()
    {
        if (targetObject != null)
        {
            targetObject.transform.rotation = Quaternion.Euler(0f, 359.033295f, 0f);
            currentDirection = 0f;
        }
    }
}