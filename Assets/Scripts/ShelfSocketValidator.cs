using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ShelfSocketValidator : MonoBehaviour
{
    public ProductData product;
    public static Action ItemPlacedCorrectly;
    public static Action ItemRemovedFromShelf;
    public GameObject ghostObject; // Reference to the ghost object to show when an item is placed
    public void OnPlacement(SelectEnterEventArgs args)
    {
        // Check if the placed object has the correct tag (e.g., "Product")
        if (args.interactableObject.transform.CompareTag("Product"))
        {
            Renderer renderer = args.interactableObject.transform.GetComponent<Renderer>();
            renderer.material.color = Color.white;
            Debug.Log("Correct product placed on shelf: " + args.interactableObject.transform.name);
            ItemPlacedCorrectly?.Invoke();
            ghostObject.SetActive(false);
        }
        else
        {
            Debug.Log("Incorrect item placed on shelf: " + args.interactableObject.transform.name);
            XRSocketInteractor socket = GetComponent<XRSocketInteractor>();
            socket.interactionManager.SelectExit(socket, args.interactableObject);
        }
    }
    
    public void ResetShelf()
    {
        ghostObject.SetActive(true); // Reset the ghost object to be visible again
        ItemRemovedFromShelf?.Invoke();
    }
}
