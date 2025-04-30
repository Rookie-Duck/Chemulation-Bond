using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public GameObject[] objectsToRotate; // Array to hold the objects to rotate
    private float rotationSpeed = 45f; // Speed of rotation in degrees per second
    private float targetAngle = 0f; // Target angle for rotation
    private float currentAngle = 0f; // Current angle of rotation

    // Method to rotate objects to the left
    public void RotateLeft()
    {
        targetAngle += 15f; // Set target angle to rotate left
        StartCoroutine(RotateObjects());
    }

    // Method to rotate objects to the right
    public void RotateRight()
    {
        targetAngle -= 15f; // Set target angle to rotate right
        StartCoroutine(RotateObjects());
    }

    // Coroutine to smoothly rotate the objects
    private IEnumerator RotateObjects()
    {
        while (Mathf.Abs(currentAngle - targetAngle) > 0.01f)
        {
            currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
            foreach (GameObject obj in objectsToRotate)
            {
                if (obj != null)
                {
                    obj.transform.rotation = Quaternion.Euler(0, currentAngle, 0);
                }
            }
            yield return null; // Wait for the next frame
        }
        currentAngle = targetAngle; // Snap to the target angle
    }
}