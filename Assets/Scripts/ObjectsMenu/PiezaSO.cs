using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Nueva Pieza", menuName = "Catalogo/Pieza")]
public class PiezaSO : ScriptableObject
{
    public string nombre;

    public Sprite imagen;

    public string contenido;

    public GameObject modelo;

    public Animator anim;
}
