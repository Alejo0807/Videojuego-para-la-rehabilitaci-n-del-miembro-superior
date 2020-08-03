using UnityEngine;

public class Movimiento : MonoBehaviour {

    //private string[] mano = new string[5];
    //private float[] mano_num = new float[5];

    //private string mano;
    //private float mano_num;
    //SerialPort stream = new SerialPort("COM3", 9600);


    public float JumpForce;
    public Rigidbody2D personaje;
    public Transform comprobadorSuelo;
    public LayerMask mascaraSuelo;
    private Animator animator;

    //Saltar
    private float comprobadorRadio = 0.08f;
    private bool enSuelo = true;
    private bool dobleSalto = false;

    //Correr
    private float velocidad;
    private bool corriendo = false;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start () {
        //stream.Open();
        velocidad = 0;

    }

    /// <summary>
    /// 
    /// </summary>
    void FixedUpdate()
    {
        if (corriendo){
            velocidad = 3.5f;
            personaje.velocity = new Vector2(velocidad, personaje.velocity.y);
        }
        else
        {
            velocidad = 0;
            personaje.velocity = new Vector2(0f, personaje.velocity.y);
            NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeEmpiezaACorrer");
        }

        enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position,comprobadorRadio,mascaraSuelo);
        animator.SetBool("IsGrounded", enSuelo);
        animator.SetFloat("VelocidadX", velocidad);
        if (enSuelo) dobleSalto = false;
    }

    void Update () {

        //Mano - string
        //Arduino();

        //for (int i = 0; i < 5; i++)
        //{
            //Mano - angulo
            //mano_num = Convert.ToUInt16(mano);
        //}

        //Mano sin pulgar solo corre

        //Marcar tolerancia
        //Varias maneras de correr

        if (/*mano_num > 10*/Input.GetMouseButtonDown(0) /*Mano sin pulgar*/)
        {
            if (corriendo)
            {
                if ((enSuelo || !dobleSalto) /*&& Input.GetMouseButtonDown(0)*//*mano con pulgar corre y salta*/)
                {
                    personaje.velocity = new Vector2(personaje.velocity.x, JumpForce);
                    personaje.AddForce(new Vector2(0, JumpForce));
                    if (!enSuelo && !dobleSalto)
                    {
                        dobleSalto = true;
                    }
                }
            }
            else
            {
                corriendo = true;
                NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeEmpiezaACorrer");
            }
        }
        else
        {
            corriendo = false;
        }

    }

    //private void Arduino()
    //{
    //    //for (int i = 0; i < 5; i++)
    //    //{
    //    mano = stream.ReadLine();
    //    //}

    //}

    //private void CreateUser(string Nombre, string Apellido, string Dia, string Mes, string Año, string Genero, string Diagnostico)
    //{
    //    WWWForm form = new WWWForm();

    //    form.AddField("NombrePOST", Nombre);
    //    form.AddField("ApellidoPOST", Apellido);
    //    form.AddField("DiaPOST", Dia);
    //    form.AddField("MesPOST", Mes);
    //    form.AddField("AnhoPOST", Año);
    //    form.AddField("GeneroPOST", Genero);
    //    form.AddField("DiagnosticoPOST", Diagnostico);


    //    WWW www = new WWW(urlSend, form);
    //}

}
