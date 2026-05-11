using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptQueSalioDeMBLS : MonoBehaviour
{
    //ESTE SCRIPT ES NETAMENTE PARA USO DE PRUEBAS INDETERMINADAS, DESDE HACER PRUEBA DE METODOS, FUNCIONES O CUALQUIER PARACECIDO
    //TODO CON EL FIN DE NO HACER PRUEBAS INNECESARIAS EN OTROS SCRIPTS

    public GameObject modelo;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            UI_Tutorial.tuto = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Aumentar();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Disminuir();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            modelo.transform.localScale = Vector3.one;
        }
    }

    public void OstiaQueMeTocan()
    {
        Debug.Log("Ostia que me han tocado");
        UI_Tutorial.tuto = true;
    }

    public void Aumentar()
    {
        float factor = 1.2f;
        modelo.transform.localScale *= factor;
    }
    public void Disminuir()
    {
        float factor = 1.2f;
        modelo.transform.localScale /= factor;
    }

}

