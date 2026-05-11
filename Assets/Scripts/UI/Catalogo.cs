using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catalogo : MonoBehaviour
{
    public PiezaSO[] piezas;
    public GameObject itemPrefab;
    public Transform[] contenedor;
    private void Start()
    {
        for (int i = 0; i < piezas.Length && i < contenedor.Length; i++)
        {
            GameObject obj = Instantiate(itemPrefab, contenedor[i]);
            PiezaUI ui = obj.GetComponent<PiezaUI>();
            ui.piezaData = piezas[i];
            ui.AsignarDatos();
        }
    }
}
