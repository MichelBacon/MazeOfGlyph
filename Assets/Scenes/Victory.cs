using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public GameObject dialogToShow;
    public AudioSource audioSource;
    private bool playerInBounds;
 
    void OnTriggerStay(Collider other){
        if(other.tag == "Player"){
            playerInBounds = true;
            dialogToShow.SetActive(true);
        }
    }
    
    void OnTriggerExit(Collider other){
        if(other.tag == "Player"){
            playerInBounds = false;
            dialogToShow.SetActive(false);
        }
    }

    private void Start() {
        dialogToShow.SetActive(false);
    }

    private void Update()
    {
        if (playerInBounds && Input.GetKeyDown(KeyCode.E) && !audioSource.isPlaying)
        {
            audioSource.Play();
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(4);
        Cursor.lockState = CursorLockMode.None;
    }
}
