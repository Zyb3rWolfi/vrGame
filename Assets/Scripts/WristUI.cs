using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WristUI : MonoBehaviour
{
    public GameObject tabletCanvas; // Reference to the tablet UI canvas
    public Transform wristTransform; // Reference to the wrist transform
    public float angleThreshold = 45f; // Angle threshold for showing the UI
    public TextMeshProUGUI countText; // Reference to the TextMeshProUGUI component for displaying count

    private void OnEnable()
    {
        RetailStateManager.UpdateCountUI += UpdateCount;
        RetailStateManager.OnStateChange += SwitchState;
    }

    private void OnDisable()
    {
        RetailStateManager.UpdateCountUI -= UpdateCount;
        RetailStateManager.OnStateChange -= SwitchState;
    }

    private void UpdateCount(int count)
    {
        countText.text = $"Stock the shop shelfs with the correct products. {count}/10";
    }

    void Update()
    {
        float dist = Vector3.Distance(Camera.main.transform.position, wristTransform.position);

        // If hand is within 40cm of your face, show tablet
        if (dist < 0.4f) 
        {
            tabletCanvas.SetActive(true);
        }
        else 
        {
            tabletCanvas.SetActive(false);
        }
    }

    private void SwitchState(RetailState state)
    {
        switch (state)
        {
            case RetailState.Validating:
                countText.text = "Staff room unlocked! Check the shelves for any misplaced items.";
                break;
        }
    }
}
