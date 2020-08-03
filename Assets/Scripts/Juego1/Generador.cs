using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour {

    public GameObject[] obj;

    public float tiempoMin = 1f;
    public float tiempoMax = 2f;

    private bool fin = false;
    private int flag = 1;
    // Use this for initialization
    void Start() {
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeMuere");
        NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeParado");
        //Generar();
    }

    void PersonajeEmpiezaACorrer(Notification not)
    {
        flag = 1;
        Generar();
    }

    void PersonajeParado()
    {
        flag = 0;
        Generar();
    }

    void PersonajeMuere()
    {
        fin = true;
    }

    private void Generar()
    {
        if (!fin && flag == 1)
        {
            Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
            Invoke("Generar", Random.Range(tiempoMin, tiempoMax));
        }
        else
        {
            CancelInvoke();
        }
    }
}
