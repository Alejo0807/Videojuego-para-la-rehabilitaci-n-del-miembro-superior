using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using System.IO.Ports;
using UnityEngine;

public class Calibrar : MonoBehaviour {


    private string[] mano = new string[5];
    private int[] mano_num = new int[5];
    
    SerialPort stream = new SerialPort("COM3", 9600);

    private string urlSend_E = "http://localhost/Proyecto_DB/SendAngles_E.php";
    private string urlSend_C = "http://localhost/Proyecto_DB/SendAngles_C.php";


    private void OnMouseDown()
    {

        if (gameObject.CompareTag("Calibrar_Extend"))
        {
            Arduino();
            Calibracion_E(PlayerPrefs.GetInt("ID"), mano_num[0], mano_num[1], mano_num[2], mano_num[3], mano_num[4]);
            SceneManager.LoadScene(6);

        }
        else if (gameObject.CompareTag("Calibrar_Cerrar"))
        {
            Arduino();
            Calibracion_E(PlayerPrefs.GetInt("ID"), mano_num[0], mano_num[1], mano_num[2], mano_num[3], mano_num[4]);
            SceneManager.LoadScene(4);
        }
        else if (gameObject.CompareTag("Volver_Main"))
        {
            SceneManager.LoadScene(4);
        }
        stream.Close();
    }

    private void Arduino()
    {
        stream.Open();
        for (int i = 0; i < 5; i++)
        {
            mano[i] = stream.ReadLine();
            mano_num[i] = Convert.ToUInt16(mano[i]);
        }

    }

    private void Calibracion_E(int ID, int Pulgar, int Indice, int Medio, int Anular, int Menhique)
    {
        WWWForm form = new WWWForm();

        form.AddField("IDPOST", ID);
        form.AddField("PulgarPOST", Pulgar);
        form.AddField("IndicePOST", Indice);
        form.AddField("MedioPOST", Medio);
        form.AddField("AnularPOST", Anular);
        form.AddField("MenhiquePOST", Menhique);

        WWW www = new WWW(urlSend_E, form);
    }


    private void Calibracion_C(int ID, int Pulgar, int Indice, int Medio, int Anular, int Menhique)
    {
        WWWForm form = new WWWForm();

        form.AddField("IDPOST", ID);
        form.AddField("PulgarPOST", Pulgar);
        form.AddField("IndicePOST", Indice);
        form.AddField("MedioPOST", Medio);
        form.AddField("AnularPOST", Anular);
        form.AddField("MenhiquePOST", Menhique);

        WWW www = new WWW(urlSend_C, form);
    }

}
