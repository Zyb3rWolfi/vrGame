using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum RetailState
{
    Stocking,
    Validating,
    Completing
}
public class RetailStateManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stockingUI;
    public RetailState currentState = RetailState.Stocking;
    public int RequiredProducts = 10;
    public static Action OpenStockRoom;
    [SerializeField] private int currentProductCount = 0;

    public static Action<int> UpdateCountUI;
    public static Action<RetailState> OnStateChange;
    public void SetState(RetailState newState)
    {
        currentState = newState;
    }
    

    private void OnEnable()
    {
        ShelfSocketValidator.ItemPlacedCorrectly += UpdateProductCount;
        ShelfSocketValidator.ItemRemovedFromShelf += ProductRemoved;
    }
    
    private void OnDisable()
    {
        ShelfSocketValidator.ItemPlacedCorrectly -= UpdateProductCount;
        ShelfSocketValidator.ItemRemovedFromShelf -= ProductRemoved;
    }

    private void Start()
    {
        SetState(RetailState.Stocking);
    }
    
    private void ProductRemoved()
    {
        if (currentProductCount > 0)
        {
            currentProductCount -= 1;
            UpdateCountUI?.Invoke(currentProductCount);
        }
    }
    private void UpdateProductCount()
    {
        currentProductCount += 1;
        UpdateCountUI?.Invoke(currentProductCount);
        if (currentProductCount == RequiredProducts)
        {
            Debug.Log("All products correctly placed! Transitioning to Validating state.");
            currentState = RetailState.Validating;
            SetState(RetailState.Validating);
            OnStateChange?.Invoke(currentState);
            OpenStockRoom?.Invoke();
        }
    } 
}
