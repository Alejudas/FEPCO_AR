using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private PiezaUI seleccionada;
    [SerializeField] private PiezaInfo _info;
    [SerializeField] private Button boton;

    [Header("sring Nombre de escena")]
    [SerializeField] private string nombreEscena;

    [Header("Tipo de Boton")]
    [SerializeField] private BotonesEnum currentOpc;

    [Header("Listas de GameObjects")]
    [SerializeField] private GameObject[] encender;
    [SerializeField] private GameObject[] apagar;

    [Header("Animaciones y variables en relacion")]
    public bool abierto;
    public static bool firstTime;

    [SerializeField] private Animator anim;

    [SerializeField] private string entrada, salida;

    [SerializeField] private Animator[] animsE;
    [SerializeField] private Animator[] animsS;

    public PiezaInfo Info { get => _info; }
    public Animator Anim { get => anim;}

    void Start()
    {
        boton = GetComponent<Button>();
        boton.onClick.AddListener(EjecutarFuncionBoton);

        firstTime = true;
    }
    //METODO DE FUNCION QUE REALIZA BOTON
    public void EjecutarFuncionBoton()
    {
        switch (currentOpc)
        {
            case BotonesEnum.cambiarObjetos:
                CambiarObjetos();
                break;
            case BotonesEnum.cambiarEscena:
                CambiarEscena(nombreEscena);
                break;
            case BotonesEnum.tomarFoto:
                TomarCaptura();
                break;
            case BotonesEnum.abrirInfo:
                MBLS();
                break;
            case BotonesEnum.abrirMenu:
                AbrirMenu();
                break;
            case BotonesEnum.entrada:
                Entrada();
                break;
        }
    }
    //METODO ESPECIFICO PARA PANEL DE INFORMACION
    public void MBLS()
    {
        seleccionada = GetComponentInChildren<PiezaUI>();

        if (seleccionada != null && _info != null)
        {
            _info.piezaData = seleccionada.piezaData;

            _info.Abrir();
        }
    }
    //METODO PARA CAMBIAR DE ESCENA
    public void CambiarEscena(string nombreEscena)
    {
        if (!string.IsNullOrEmpty(nombreEscena))
            SceneManager.LoadScene(nombreEscena);
    }
    //METODO PARA DESACTIVAR OBJETOS Y DESACTIVAR OBJETOS
    public void CambiarObjetos()
    {
        if (encender.Length > 0)
        {
            foreach (GameObject go in encender)
                go.SetActive(true);
        }

        if (apagar.Length > 0)
        {
            foreach (GameObject go in apagar)
                go.SetActive(false);
        }
    }
    //METODO ESPECIFICO PARA ABRIR Y CERRAR EL MENU DE OPCIONES
    public void AbrirMenu()
    {
        abierto = !abierto;

        if (abierto)
        {
            anim.Play("Entrada");
        }
        else
        {
            anim.Play("Salida");
        }
    }
    //METODO DE ENTRADA DE BOTON O GRUPO DE OBJETOS SELECCION ESPECIFICA DEL MENU DE OPCIONES
    public void Entrada()
    {
        if (firstTime)
        {
            foreach (Animator anim in animsE)
            {
                anim.Play(entrada);
            }
            firstTime = false;
        }
        else
        {
            foreach (Animator anim in animsE)
            {
                anim.Play(entrada);
            }

            foreach (Animator anim in animsS)
            {
                anim.Play(salida);
            }
        }
    }
    //METODO ESPECIFICO DE CAPTURA DE PANTALLA
    public void TomarCaptura()
    {
        ScreenCapture.CaptureScreenshot("ScreenShot");
    }
}
