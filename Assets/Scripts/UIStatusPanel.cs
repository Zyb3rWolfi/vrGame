using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIStatusPanel : MonoBehaviour
{
    public TextMeshProUGUI statusText;
    public GameObject shopLights;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToggleLights()
    {
        
        // Check if lights are currently on
        bool lightsAreOn = shopLights.activeSelf;

        // Flip the state
        shopLights.SetActive(!lightsAreOn);

        // Requirement: Update the UI text
        
        if (shopLights.activeSelf)
        {
            statusText.text = "System State: Lights ON";
        }
        else
        {
            statusText.text = "System State: Lights OFF";
        }
    }

    public void LightBrigtness(float brightnessSliderValue)
    {
        // Requirement: Adjust the brightness of the shop lights based on the slider value
        // Assuming the slider value is between 0 and 1, we can set the intensity of the lights accordingly
        Light[] lights = shopLights.GetComponentsInChildren<Light>();
        foreach (Light light in lights)
        {
            light.intensity = brightnessSliderValue; // Scale brightness as needed
        }
        
    } 
}
