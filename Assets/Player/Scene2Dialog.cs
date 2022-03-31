using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2Dialog : MonoBehaviour
{
    public GameObject dialog;
    // Start is called before the first frame update
    void Start()
    {
        dialog.SetActive(true);
        StartCoroutine("WaitForSec");
    }

    IEnumerator WaitForSec() {
        yield return new WaitForSeconds(5);
        dialog.SetActive(false);
    }
}
