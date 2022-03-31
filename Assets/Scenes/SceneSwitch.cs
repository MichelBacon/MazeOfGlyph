using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public GameObject dialogToShow;
    private bool isInRange;
 
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            isInRange = true;
            dialogToShow.SetActive(true);
        }
    }
 
    void OnTriggerExit(Collider other) {
 
        if (other.gameObject.tag == "Player")
        {
            isInRange = false;
            dialogToShow.SetActive(false);
        }
 
    }

    private void Start() {
        dialogToShow.SetActive(false);
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(2);
        }
    }
}
