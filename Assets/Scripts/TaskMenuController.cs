using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMenuController : MonoBehaviour
{
    public GameObject taskMenuUI; // Reference to the task menu UI GameObject

    public void ToggleMenu()
    {
        bool isActive = taskMenuUI.activeSelf; // Check if the menu is currently active
        taskMenuUI.SetActive(!isActive); // Toggle the menu's active state
    }
}
