using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Botones : MonoBehaviour {


    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Boton_Jugar"))
        {
            SceneManager.LoadScene(7);
        }
        else if (gameObject.CompareTag("Astro"))
        {
            SceneManager.LoadScene(5);
        }
    }
}
