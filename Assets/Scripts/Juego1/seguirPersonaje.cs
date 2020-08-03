using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguirPersonaje : MonoBehaviour {

    public Transform personaje;
    public float separacion = 0;

	void Update () {
        transform.position = new Vector3(personaje.position.x + separacion, transform.position.y, transform.position.z);
	}
}
