using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTurret : MonoBehaviour
{
    public AudioSource audioSource;
    public Flashlight flashlight;
    public HealthBarScript healthBarScript;

    private bool playerInBounds;
 
    void OnTriggerStay(Collider other){
        if(other.tag == "Player"){
            playerInBounds = true;
        }
    }
    
    void OnTriggerExit(Collider other){
        if(other.tag == "Player"){
            playerInBounds = false;
        }
    }

    void Update() {
        if(playerInBounds && !audioSource.isPlaying) {
            flashlight = GameObject.FindGameObjectWithTag("Player").GetComponent<Flashlight>();
            healthBarScript = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBarScript>();
            if(flashlight.isOn) {
                healthBarScript.DamagePlayer(20);
                audioSource.Play();
            }
        }
    }
}
