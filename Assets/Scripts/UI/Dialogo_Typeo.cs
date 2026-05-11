using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogo_Typeo : MonoBehaviour
{
    private bool dialogueStart;
    private bool isTyping;
    private Coroutine typingCoroutine;

    private int lineIndex;
    [SerializeField] private TMP_Text dialogue;
    [SerializeField, TextArea(4, 3)] private string[] mensaje;
    [SerializeField] private float timeCharacters = 0.05f;

    void Start()
    {
        StartDialogue();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            NextDialogue();
    }
    public void StartDialogue()
    {
        dialogueStart = true;
        lineIndex = 0;
        StartLine();
    }
    public void NextDialogue()
    {
        lineIndex++;

        if (isTyping && lineIndex < mensaje.Length)
        {
            // Completa la línea instantáneamente
            StopCoroutine(typingCoroutine);
            dialogue.text = mensaje[lineIndex];
            isTyping = false;
            return;
        }

        if (lineIndex < mensaje.Length)
        {
            StartLine();
        }
        else
        {
            dialogueStart = false;
        }
    }
    void StartLine()
    {
        if (dialogueStart)
        {
            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);

            typingCoroutine = StartCoroutine(ShowLine());
        }
    }
    private IEnumerator ShowLine()
    {
        isTyping = true;
        dialogue.text = string.Empty;

        foreach (char ch in mensaje[lineIndex])
        {
            dialogue.text += ch;
            yield return new WaitForSeconds(timeCharacters);
        }

        isTyping = false;
    }
}
