using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class PiezaInfo : MonoBehaviour
{
    [Header("Datos Datos Pieza")]
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI piezaName;
    [SerializeField] private TextMeshProUGUI info;
    public PiezaSO piezaData;

    [Header("Referencias Componentes")]
    [SerializeField] private Animator anim;
    public void Abrir()
    {
        gameObject.SetActive(true);
        anim.Play("Panel_Entrada");
        if (piezaData != null)
        {
            image.sprite = piezaData.imagen;
            piezaName.text = piezaData.nombre;
            info.text = piezaData.contenido;

            BigManager.Instance.data = piezaData;
        }
    }
    public void Cerrar()
    {
        anim.Play("Panel_Salida");
    }
    public void Apagar()
    {
        gameObject.SetActive(false);
    }
}
