using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PiezaUI : MonoBehaviour
{
    [SerializeField] private Image localImage;
    [SerializeField] private TextMeshProUGUI localText;
    [SerializeField] private GameObject localModelo;

    public PiezaSO piezaData;
    public void AsignarDatos()
    {
        if (piezaData == null) return;
        localImage.sprite = piezaData.imagen;
        localText.text = piezaData.nombre;
        localModelo = piezaData.modelo;
    }
}
