using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
[System.Serializable]
public class Item
{
    public string Nombre_Button;
    public string Apellido_Button;
    public string Dia_Button;
    public string Mes_Button;
    public string Año_Button;
    public string Genero_Button;
    public string Diagnostico_Button;
}
public class NameScrollList : MonoBehaviour {

    public List<Item> itemList;
    public Transform contentPanel;
    public SimpleObjectPool buttonObjectPool;

    private string[] items_sql;
    private string nombre, apellido, dia, mes, año, genero, diagnostico, todos_los_nombres;
    private IEnumerator coroutine;

    void Start()
    {
        IniciarSQL_Botones();
    }

    private void AddItem(Item itemToAdd, NameScrollList nameList)
    {
        nameList.itemList.Add(itemToAdd);
    }

    private void RemoveItem(Item itemToRemove, NameScrollList nameList)
    {
        for (int i = nameList.itemList.Count - 2; i >= 0; i--)
        {
            if (nameList.itemList[i] == itemToRemove)
            {
                nameList.itemList.RemoveAt(i);
            }
        }
    }

    private void RemoveButton()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

   
    public void IniciarSQL_Botones()
    {
        /*
        WWW userInfo = new WWW("http://localhost/Proyecto_DB/GetData.php");
        yield return userInfo;
        string userInfoString = userInfo.text;

        //En items_sql todos los datos de los pacientes
        items_sql = userInfoString.Split(';');
        */
        StreamReader Nombres = new StreamReader(@"G:\PUCP\Proyecto\Nombres\Nombres.txt");
        todos_los_nombres = Nombres.ReadLine();
        
        items_sql = todos_los_nombres.Split('|');

        ////Getting patient's data
        for (int i = 0; i< items_sql.Length - 1; i++)
        { 
            nombre = items_sql[i];
            
            Item item = itemList[i];

            //Crea el Boton con los datos
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);
            CrearHistorial sampleButton = newButton.GetComponent<CrearHistorial>();
            item.Nombre_Button = nombre;
            sampleButton.Setup(item, this);

        }

    }

    private string SepararData(string data, string index)
    {
        string data1 = data.Substring(data.IndexOf(index) + index.Length);
        if (data1.Contains("|")) data1 = data1.Remove(data1.IndexOf('|'));
        return data1;
    }

}
