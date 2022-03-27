using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightMech : MonoBehaviour
{
	public bool isOn = false;
	public GameObject lightSource;
	public AudioSource clickSoundOn;
	public AudioSource clickSoundOff;
	public bool failSafe = false;

    void Update()
    {
       if (Input.GetButtonDown("FKey"))
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
		}
    }
	IEnumerator FailSafe()
	{
		yield return new WaitForSeconds(0.25f);
		failSafe = false;
	}

}
