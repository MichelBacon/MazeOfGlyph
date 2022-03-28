using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
	public bool isOn = false;
	public GameObject lightSource;
	public AudioSource clickSoundOn;
	public AudioSource clickSoundOff;
	public bool failSafe = false;
    public float currentBatteryPourcentage = 0;
    public float maxBatteryPourcentage = 100;

    public BatteryBar batteryBar;

    void Start()
    {
        currentBatteryPourcentage = maxBatteryPourcentage;
    }

    void Update()
    {
        if (Input.GetButtonDown("FKey") && currentBatteryPourcentage > 0)
		{
			if (isOn == false && failSafe == false)
			{
				failSafe = true;
				lightSource.SetActive(true);
				clickSoundOn.Play();
				isOn = true;
				StartCoroutine(FailSafe());
			}
			if (isOn == true  && failSafe == false)
			{
				failSafe = true;
				lightSource.SetActive(false);
				clickSoundOff.Play();
				isOn = false;
				StartCoroutine(FailSafe());
			}
		} else if(currentBatteryPourcentage < 0) {
            failSafe = true;
            lightSource.SetActive(false);
            clickSoundOff.Play();
            isOn = false;
            StartCoroutine(FailSafe());
        }

        if(isOn) {
            currentBatteryPourcentage -= (Time.deltaTime/1.5f);   
            batteryBar.SetHealth( currentBatteryPourcentage );
        }
    }
	IEnumerator FailSafe()
	{
		yield return new WaitForSeconds(0.25f);
		failSafe = false;
	}

}