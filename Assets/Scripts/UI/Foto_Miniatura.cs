using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Foto_Miniatura : MonoBehaviour
{
    [SerializeField] private GameObject panelMiniatura;
    [SerializeField] private RawImage imagenMiniatura;

    [SerializeField] private Vector2 inicio;
    [SerializeField] private Vector2 final;
    [SerializeField] private Vector2 finalSave;

    [SerializeField] private Vector3 inicialScale;
    [SerializeField] private Vector3 finalScale;
    public void MostrarMiniatura(Texture2D foto)
    {
        StartCoroutine(AnimacionMiniatura(foto));
    }
    IEnumerator AnimacionMiniatura(Texture2D foto)
    {
        panelMiniatura.SetActive(true);

        imagenMiniatura.texture = foto;

        RectTransform rt = panelMiniatura.GetComponent<RectTransform>();

        rt.anchoredPosition = inicio;
        float tiempo = 0;

        while (tiempo < 1)
        {
            tiempo += Time.deltaTime * 2f;

            rt.anchoredPosition = Vector2.Lerp(inicio, final, tiempo);
            rt.localScale = Vector3.Lerp(inicialScale, finalScale, tiempo);
            yield return null;
        }

        tiempo = 0;
        yield return new WaitForSeconds(2f);

        while (tiempo < 1)
        {
            tiempo += Time.deltaTime * 4;
            rt.anchoredPosition = Vector2.Lerp(final, finalSave, tiempo);
            yield return null;
        }

        panelMiniatura.SetActive(false);
    }
}
