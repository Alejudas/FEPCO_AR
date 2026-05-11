using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigManager : MonoBehaviour
{
    public PiezaSO data;
    public static BigManager Instance;

    public bool tutorialComplete;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
