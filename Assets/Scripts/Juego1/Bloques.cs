using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloques : MonoBehaviour {

    private bool HaColisonado = false;
    private int puntosGanados = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (!HaColisonado && (collision.collider.gameObject.name == "PiernaDerechaA" || collision.collider.gameObject.name == "PiernaIzquierdaA"))
        {
            HaColisonado = true;
            NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", puntosGanados);
        }
        
    }
}
