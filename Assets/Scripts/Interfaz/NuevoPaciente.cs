using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class NuevoPaciente : MonoBehaviour
{
    /**
     * Listas que contienen todos los dias y meses del año
     * esto para que se pueda escoger la fecha de nacimiento del paciente
     */
    List<string> Dia = new List<string>() {"Día", "1","2", "3", "4", "5", "6", "7",
                                           "8", "9", "10", "11", "12", "13", "14", "15",
                                           "16", "17", "18", "19", "20", "21", "22","23",
                                           "24", "25", "26", "27", "28", "29", "30","31"};

    List<string> Mes = new List<string>() {"Mes", "Enero","Febrero", "Marzo", "Abril", "Mayo",
                                           "Junio", "Julio", "Agosto","Setiembre", "Octubre",
                                           "Noviembre", "Diciembre"};

    List<string> Año = new List<string>() {"Año", "1980","1981", "1982", "1983", "1984", "1985", "1986",
                                           "1987", "1988","1989", "1990", "1991", "1992", "1993", "1994",
                                           "1995", "1996","1997", "1998", "1999", "2000", "2001", "2002",
                                           "2003", "2004","2005", "2006" };

    List<string> Genero = new List<string>() {" ", "M", "F"};

    //Nombre de la casillas
    public InputField nombre_1;
    public InputField apellido_1;
    public InputField diagnostico_1;

    public Dropdown dia_1;
    public Dropdown mes_1;
    public Dropdown año_1;
    public Dropdown genero_1;

    private string nombre, apellido, diagnostico, dia, mes, año ,genero, nombre_completo;

    void Start()
    {
        /*Todas las casillas de la interfaz aparecen por default
         * vacías o, como en el caso del la fecha de nacimineto
         * con un dato predeterminado
         */
        AgregarListas();
        PlayerPrefs.SetString("nombre", " ");
        PlayerPrefs.SetString("apellido", " ");
        PlayerPrefs.SetString("dia", "Día");
        PlayerPrefs.SetString("mes", "Mes");
        PlayerPrefs.SetString("año", "Año");
        PlayerPrefs.SetString("genero", " ");
        PlayerPrefs.SetString("diagnostico", " ");
    }

    private void AgregarListas()
    {
        dia_1.AddOptions(Dia);
        mes_1.AddOptions(Mes);
        año_1.AddOptions(Año);
        genero_1.AddOptions(Genero);
    }

    public void AgregarDatos()
    {
        string nombre_2 = nombre_1.text;
        PlayerPrefs.SetString("nombre",nombre_2);

        string apellido_2 = apellido_1.text;
        PlayerPrefs.SetString("apellido",apellido_2);

        string diagnostico_2 = diagnostico_1.text;
        PlayerPrefs.SetString("diagnostico", diagnostico_2);
    }

    public void AsignarDia(int index)
    {
        string dia_2 = Dia[index];
        PlayerPrefs.SetString("dia", dia_2);
    }

    public void AsignarMes(int index)
    {
        string mes_2 = Mes[index];
        PlayerPrefs.SetString("mes", mes_2);
    }

    public void AsignarAño(int index)
    {
        string año_2 = Año[index];
        PlayerPrefs.SetString("año", año_2);
    }

    public void AsignarGenero(int index)
    {
        string genero_2 = Genero[index];
        PlayerPrefs.SetString("genero", genero_2);
    }

    public void Aceptar()
    {
        AgregarDatos();
        //Obtiene cada dato de la interfaz y la guarda en cada variable
        nombre = PlayerPrefs.GetString("nombre");
        apellido = PlayerPrefs.GetString("apellido");
        diagnostico = PlayerPrefs.GetString("diagnostico");
        dia = PlayerPrefs.GetString("dia");
        mes = PlayerPrefs.GetString("mes");
        año = PlayerPrefs.GetString("año");
        genero = PlayerPrefs.GetString("genero");
        nombre_completo = nombre + " " + apellido;

        if ((nombre != null && nombre != " ") && (apellido != null && apellido != " ") && (dia != null && dia != "Día") &&
            (mes != null && mes != "Mes") && (año != null && año != "Año") && (genero != null && genero != " ") && (diagnostico != null && diagnostico != " "))
        {

            /*
             *Revisa si ya existe una carpeta con el mismo nombre
             * si no es así crea una nueva con un archivo donde se encuentra 
             * el nombre, apellido, fecha de nacimiento y diagnóstico
             */

            if (!Directory.Exists(@"G:\PUCP\Proyecto\Nombres\" + nombre_completo))
            {
                Directory.CreateDirectory(@"G:\PUCP\Proyecto\Nombres\" + nombre_completo);
                StreamWriter File = new StreamWriter(@"G:\PUCP\Proyecto\Nombres\" + nombre_completo + @"\DatosPaciente.txt");
                File.Write(nombre + "\r\n");
                File.Write(apellido + "\r\n");
                File.Write(dia + "\r\n");
                File.Write(mes + "\r\n");
                File.Write(año + "\r\n");
                File.Write(genero + "\r\n");
                File.Write(diagnostico + "\r\n");
                File.Close();

                StreamWriter Nombres = new StreamWriter(@"G:\PUCP\Proyecto\Nombres\Nombres.txt",true);
                Nombres.Write(nombre_completo + "|");
                Nombres.Close();   
            }
            PlayerPrefs.SetInt("nuevo", 1);
            for (int i = 0; i < 10000000; i++);
            SceneManager.LoadScene(1);
        }

    }

}
