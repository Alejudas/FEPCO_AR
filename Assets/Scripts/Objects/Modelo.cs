using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Modelo : MonoBehaviour
{
    [Header("PiezaData")]
    [SerializeField] private GameObject modelo;
    [SerializeField] private Animator anim;
    [SerializeField] private PiezaSO data;

    [SerializeField] private Transform point;

    [Header("UI")]
    [SerializeField] private Slider vertical;
    [SerializeField] private Slider horizontal;
    [SerializeField] private Button reset;
    [SerializeField] private Button aumentar;
    [SerializeField] private Button disminuir;

    float y;
    float x;
    Quaternion targetRotation;

    [SerializeField] private float value;

    void Start()
    {
        vertical.onValueChanged.AddListener(RotationHandlerX);
        horizontal.onValueChanged.AddListener(RotationHandlerY);
        reset.onClick.AddListener(Resetear);
        disminuir.onClick.AddListener(Disminuir);
        aumentar.onClick.AddListener(Aumentar);

        modelo = BigManager.Instance.data.modelo;
        anim = BigManager.Instance.data.anim;
        if (modelo != null)
        {
            Iniciar();
        }
    }
    void Update()
    {
        point.transform.rotation = Quaternion.Slerp(
            point.transform.rotation,
            targetRotation,
            Time.deltaTime * 5f
            );

        if (!anim.isActiveAndEnabled)
        {
            Debug.LogWarning("ALGO ANDA MAL");
        }
    }

    //PRESENTACION DE LA PIEZA
    void Iniciar()
    {
        modelo = Instantiate(modelo, point.position, Quaternion.identity, point);
        anim = modelo.GetComponent<Animator>();
    }
    public void Cerrar()
    {
        if (anim != null)
        {
            anim.SetBool("cerrar", true);
        }
    }

    //MOVIMIENTO DE LA PIEZA
    void RotationHandlerX(float valor)
    {
        x = Mathf.Lerp(180f, -180f, valor / 100f);
        UpdateRotation();
    }
    void RotationHandlerY(float valor)
    {
        y = Mathf.Lerp(180f, -180f, valor / 100f);
        UpdateRotation();
    }
    void Resetear()
    {
        vertical.value = 50;
        horizontal.value = 50;
        modelo.transform.localScale = Vector3.one;
    }
    void UpdateRotation()
    {
        targetRotation = Quaternion.Euler(x, y, 0);
    }
    public void Aumentar()
    {
        float factor = 1.2f;
        modelo.transform.localScale *= factor;
    }
    public void Disminuir()
    {
        float factor = 1.2f;
        modelo.transform.localScale *= factor;
    }
}
