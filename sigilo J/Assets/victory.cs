using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;


public class victory : MonoBehaviour
{

    public GameObject cartel;

    private void OnCollisionEnter(Collision gano)
    {
        if (gano.gameObject.tag == "Player")
        {
            Invoke("ganar", 1f);
            Debug.Log("Gano");
            cartel.SetActive(true);
        }
    }

    void ganar ()
    {

        EditorSceneManager.LoadScene("SampleScene");
    }



}
