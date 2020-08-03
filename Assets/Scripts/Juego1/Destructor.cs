using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour {

    //cuando entra en colisión con algun objeto
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeMuere");//si el personaje muere
            GameObject personaje = GameObject.FindGameObjectWithTag("Astro");  //personaje Astro
            personaje.SetActive(false); //Cuando colisionan se vuelve invisible
        }else{   
            Destroy(other.gameObject); //si no es el jugador el objeto se destruye 
        }
    }
}
