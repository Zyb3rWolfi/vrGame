using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffDoorController : MonoBehaviour
{
    [SerializeField] private GameObject slidingDoor; // Reference to the sliding door GameObject
    private void OnEnable()
    {
            RetailStateManager.OpenStockRoom += OpenDoor;
    }

    private void OnDisable()
    {
            RetailStateManager.OpenStockRoom -= OpenDoor;
    }
    

    private void OpenDoor()
    {
        // For now we just log the door and make it disappear, but you can add an animation or sound effect here
        Debug.Log("Door opened!");
        // Using Lerp to move the door to the side over time
        BoxCollider doorCollider = slidingDoor.GetComponent<BoxCollider>();
        doorCollider.enabled = false; // Disable the collider to allow passage
        StartCoroutine(SlideDoor());
    }
    
    private IEnumerator SlideDoor()
    {
        Vector3 closedPosition = slidingDoor.transform.position;
        Vector3 openPosition = closedPosition + new Vector3(0, 0, -1f); // Adjust the open position as needed
        float duration = 1f; // Duration of the sliding animation
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            slidingDoor.transform.position = Vector3.Lerp(closedPosition, openPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        slidingDoor.transform.position = openPosition; // Ensure it ends at the exact open position
    }
}
