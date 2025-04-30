using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public GameObject objectToRotate; // Single object to rotate
    private float rotationSpeed = 45f; // Speed of rotation in degrees per second
    private float currentAngle = 0f; // Current angle of rotation

    // Reset position and rotation variables
    public Vector3 resetPosition = new Vector3(-0.970000029f, 1.08000004f, 9.52999973f); // Desired reset position
    public Quaternion resetRotation = Quaternion.Euler(0, -0.967f, 0); // Desired reset rotation

    // Method to rotate the object to the left
    public void RotateLeft()
    {
        StartCoroutine(RotateObject(-15f)); // Rotate left by 15 degrees
    }

    // Method to rotate the object to the right
    public void RotateRight()
    {
        StartCoroutine(RotateObject(15f)); // Rotate right by 15 degrees
    }

    // Coroutine to smoothly rotate the object
    private IEnumerator RotateObject(float angle)
    {
        float targetAngle = currentAngle + angle; // Calculate the target angle

        while (Mathf.Abs(currentAngle - targetAngle) > 0.01f)
        {
            currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
            if (objectToRotate != null)
            {
                // Smoothly rotate the object
                objectToRotate.transform.rotation = Quaternion.Euler(0, currentAngle, 0);
            }
            yield return null; // Wait for the next frame
        }

        currentAngle = targetAngle; // Update currentAngle to the targetAngle
    }

    // Method to reset the object's position and rotation
    public void ResetObject()
    {
        if (objectToRotate != null)
        {
            objectToRotate.transform.position = resetPosition; // Reset position
            objectToRotate.transform.rotation = resetRotation; // Reset rotation
            currentAngle = resetRotation.eulerAngles.y; // Update currentAngle to match the reset rotation
        }
    }
}