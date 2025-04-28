using Oculus.Interaction.HandGrab;
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour
{
    public GameObject objectPrefab; // Reference to the prefab you want to instantiate

    private void OnTriggerEnter(Collider other)
    {
        // Disable the child object "ISDK_HandGrabInteraction" if it exists
        Transform childTransform = other.transform.Find("ISDK_HandGrabInteraction");
        if (childTransform != null)
        {
            childTransform.gameObject.SetActive(false); // Disable the child object
        }

        // Disable all relevant interaction components if they exist
        DisableComponents(other);

        // Start a coroutine to handle destruction and instantiation
        StartCoroutine(HandleDestruction(other.gameObject));
    }

    private void DisableComponents(Collider other)
    {
        var grabbable = other.GetComponent<Grabbable>();
        if (grabbable != null)
        {
            grabbable.enabled = false;
        }

        var handGrabInteractable = other.GetComponent<HandGrabInteractable>();
        if (handGrabInteractable != null)
        {
            handGrabInteractable.enabled = false;
        }

        var grabInteractable = other.GetComponent<GrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.enabled = false;
        }
    }

    private IEnumerator HandleDestruction(GameObject obj)
    {
        yield return null; // Wait for the end of the frame
        Destroy(obj);

        // Optionally instantiate a new object if needed
        Instantiate(objectPrefab, transform.position, transform.rotation);
    }
}
