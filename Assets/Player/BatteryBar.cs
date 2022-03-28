using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{
    public Slider batteryBar;
    public Flashlight flashlight;

    private void Start()
    {
        flashlight = GameObject.FindGameObjectWithTag("Player").GetComponent<Flashlight>();
        batteryBar = GetComponent<Slider>();
        batteryBar.maxValue = flashlight.maxBatteryPourcentage;
        batteryBar.value = flashlight.currentBatteryPourcentage;
    }

    public void SetHealth(float hp)
    {
        batteryBar.value = hp;
    }
}