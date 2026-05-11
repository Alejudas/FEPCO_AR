using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NativeGalleryNamespace;
using System.IO;
public class Foto : MonoBehaviour
{
    [SerializeField] private Foto_Miniatura miniatura;
    [SerializeField] private GameObject[] objs;

    public void ScreenShot()
    {
        StartCoroutine(ScreenShotCode());
    }

    private IEnumerator ScreenShotCode()
    {
        foreach (GameObject go in objs)
            go.SetActive(false);

        yield return new WaitForEndOfFrame();

        string nombre = "IMG_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";

        string ruta = Path.Combine(@"C:\Users\ahernandez\OneDrive - fepco.com.co\Documentos\Pruebas Unity\Pruebas AR",nombre);

        ScreenCapture.CaptureScreenshot(nombre);

        Debug.Log("Ruta: " + ruta);

        float tiempo = 0f;
        float maxTiempo = 10f;

        while (!File.Exists(ruta) && tiempo < maxTiempo)
        {
            tiempo += Time.deltaTime;
            yield return null;
        }

        if (!File.Exists(ruta))
        {
            Debug.LogError("No se pudo crear la captura");

            foreach (GameObject go in objs)
                go.SetActive(true);

            yield break;
        }

        yield return new WaitForSeconds(0.1f);

        NativeGallery.SaveImageToGallery(ruta, "MiApp", nombre);

        Debug.Log("Guardado en galería");

        byte[] bytes = File.ReadAllBytes(ruta);

        Texture2D tex = new Texture2D(2, 2);

        tex.LoadImage(bytes);

        miniatura.MostrarMiniatura(tex);

        yield return new WaitForSeconds(0.5f);

        foreach (GameObject go in objs)
            go.SetActive(true);
    }
}