using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Optional: Assign this if you want to use a prefab instead of primitive
    public GameObject spherePrefab;

    // Fixed spawn position as per your request
    private Vector3 spawnPosition = new Vector3(-1.36399996f, 0.953999996f, 8.87044907f);

    // Method called by onSelect() event from Meta XR Interactable Event Wrapper
    public void SpawnSphere()
    {
        if (spherePrefab != null)
        {
            Instantiate(spherePrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            // Create primitive sphere if no prefab assigned
            GameObject newSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            newSphere.transform.position = spawnPosition;
        }
    }
}
