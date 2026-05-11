using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Tutorial : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject[] popUps;
    [SerializeField] private Button[] botones;
    [SerializeField] private Dialogo_Typeo typeo;
    [SerializeField] private Botones[] bot;
    [SerializeField] private LugaresTutoEnum currentLugar;
    [SerializeField] GameObject[] tutoObjs;
    private int popUpsIndex;

    public static bool tuto;
    private float timer;
    public float time;
    private void Start()
    {
        if (tuto == true)
            Debug.Log("tuto es true");
        else
            Debug.Log("tuto es false");
    }
    private void Update()
    {
        if (tuto)
        {
            if (tutoObjs != null && tutoObjs.Length > 0)
            {
                int[] indice = { 1, 2 };

                for (int i = 0; i < 2; i++)
                {
                    tutoObjs[i].SetActive(true);
                }

                tutoObjs[2].SetActive(false);
            }

            if (currentLugar == LugaresTutoEnum.catalogo)
            {
                for (int i = 0; i < 9; i++)
                {
                    botones[i].interactable = false;
                }
            }
            else
            {
                for (int i = 0; i > 2; i++)
                {
                    tutoObjs[i].SetActive(true);
                }
            }

            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }

            if (timer <= 0)
            {
                CompleteStep();

                timer = time;
            }

        }
        else
        {
            if (tutoObjs != null && tutoObjs.Length > 0)
            {
                int[] indice = { 1, 2 };

                for (int i = 0; i < 2; i++)
                {
                    tutoObjs[i].SetActive(false);
                }

                tutoObjs[2].SetActive(true);
            }
        }

        switch (currentLugar)
        {
            case LugaresTutoEnum.catalogo:
                EscenaCatalogo();
                break;
            case LugaresTutoEnum.muestra:
                EscenaMuestra();
                break;
        }
    }
    //METODOS TUTO
    public void CompleteStep()
    {
        if (popUpsIndex >= 0)
        {
            popUpsIndex++;
            typeo.NextDialogue();
            Debug.Log("el indice actual es " + popUpsIndex);
        }
    }
    public void EndTutorial()
    {
        tuto = false;
        bot[1].CambiarEscena("Catalogo");
    }
    //PROGRESION POR ESCENAS
    private void EscenaCatalogo()
    {
        if (popUpsIndex == 2)
        {
            for (int i = 0; i < 9; i++)
            {
                botones[i].interactable = true;
            }

            botones[9].interactable = false;
        }
        else if (popUpsIndex == 3)
        {
            bot[0].MBLS();
        }
        else if (popUpsIndex == 4)
        {
            botones[10].interactable = true;
            tutoObjs[3].SetActive(true);
        }
        else if (popUpsIndex == 5)
        {
            tutoObjs[3].SetActive(false);
            botones[10].interactable = false;
        }
        else if (popUpsIndex == 6)
        {
            botones[9].interactable = false;
            botones[11].interactable = true;
        }
        else if (popUpsIndex == 7)
        {
            bot[0].CambiarEscena("Muestra");
        }
    }
    private void EscenaMuestra()
    {
        if (popUpsIndex == 1)
        {
            int[] indices = { 6, 7, 8 };

            foreach (int i in indices)
            {
                botones[i].interactable = false;
            }
        }
        else if (popUpsIndex == 2)
        {
            foreach (GameObject go in popUps)
            {
                go.SetActive(true);
            }
            botones[4].interactable = false;

            botones[0].onClick.Invoke();

            botones[1].interactable = true;
        }
        else if (popUpsIndex == 3)
        {
            int[] indices = { 2, 3 };
            foreach (int i in indices)
            {
                botones[i].interactable = false;
            }
            bot[0].Anim.Play("Entrada");
        }
        else if (popUpsIndex == 4)
        {
            bot[0].Anim.Play("Salida");
            bot[1].Anim.Play("Entrada");

        }
        else if (popUpsIndex == 5)
        {
            botones[1].interactable = false;

            bot[0].Anim.Play("Entrada");
            bot[1].Anim.Play("Salida");

            botones[2].interactable = true;
        }
        else if (popUpsIndex == 6)
        {
            botones[1].interactable = false;

            bot[0].Anim.Play("Salida");
            bot[2].Anim.Play("Entrada");

            botones[2].interactable = false;

        }
        else if (popUpsIndex == 7)
        {
            int[] indice = { 7, 8 };

            foreach (int i in indice)
            {
                botones[i].interactable = true;
            }
        }
        else if (popUpsIndex == 8)
        {
            botones[6].interactable = true;
        }
        else if (popUpsIndex == 9)
        {
            bot[2].Anim.Play("Salida");
            bot[0].Anim.Play("Entrada");
            botones[3].interactable = true;
        }
        else if (popUpsIndex == 10)
        {
            EndTutorial();
        }
    }
}
