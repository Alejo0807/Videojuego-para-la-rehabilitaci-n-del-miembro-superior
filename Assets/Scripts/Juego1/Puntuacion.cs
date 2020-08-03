using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion : MonoBehaviour {

    private int puntuacion = 0;
	void Start () {
        NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
	}

    void IncrementarPuntos(Notification notificacion)
    {
        int puntoIncrementar = (int)notificacion.data;
        puntuacion += puntoIncrementar;
        Debug.Log("Incrementar " + puntoIncrementar + "puntos. Total ganados: " + puntuacion);
    }
	void Update () {
	    	
	}
}
