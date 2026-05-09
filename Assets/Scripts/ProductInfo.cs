using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProductInfo : MonoBehaviour
{
    [Header("Product Data")]
    [SerializeField] ProductData data; // Reference to the ScriptableObject holding product info
    [Header("UI Reference")]
    public GameObject infoCanvas; // The small Canvas on the product
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI priceText;

    void Start()
    {
        // Data-Driven: Fill the text from variables
        nameText.text = data.productName;
        priceText.text = $"£{data.price:F2}";
        // Hide UI by default
        infoCanvas.SetActive(false);
        
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = data.weight; // Set the mass of the product based on the weight from the ScriptableObject
    }

    // Called by XR Interactor Events
    public void ShowUI() => infoCanvas.SetActive(true);
    public void HideUI() => infoCanvas.SetActive(false);
}
