using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductInteractableHandler : MonoBehaviour
{
    public void OnGrab()
    {
        // Change the color of the product to indicate it has been picked up

        Debug.Log("Product grabbed: " + gameObject.name);
        Renderer renderer = GetComponent<Renderer>();
        // Change base color of the material to a bright color (e.g., yellow)
        if (renderer != null)
        {
            renderer.material.color = Color.green;
        }
    }
    
    public void OnRelease()
    {
        // Revert the color of the product to its original state
        Debug.Log("Product released: " + gameObject.name);
        Renderer renderer = GetComponent<Renderer>();
        // Change base color of the material back to white
        if (renderer != null)
        {
            renderer.material.color = Color.white;
        }
    }
}
