using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CrearHistorial : MonoBehaviour {

    public Button button;   
    public Text Nombre_Button;
    public Text Apellido_Button;

    public Text Nombre_Apellido_Dato;
    public Text Fecha_Nacimiento_Dato;
    public Text Genero_Dato;
    public Text Diagnostico_Dato;

    private Item item;
    private NameScrollList ScrollList;

    // Use this for initialization
    void Start () {
        
	}

    public void Setup(Item currentItem, NameScrollList currentScrollList)
    {
        item = currentItem;
        Nombre_Button.text = currentItem.Nombre_Button;
        Apellido_Button.text = currentItem.Apellido_Button;
        ScrollList = currentScrollList;
    }

    public void HandleClick()
    {
        //Datos de NameScrollList
        Nombre_Apellido_Dato.text = item.Nombre_Button + " " + item.Apellido_Button;
        Fecha_Nacimiento_Dato.text = item.Dia_Button + " de " + item.Mes_Button + " de " + item.Año_Button;
        Diagnostico_Dato.text = item.Diagnostico_Button;

        SceneManager.LoadScene(3);
    }

}
