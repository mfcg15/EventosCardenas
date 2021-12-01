using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int diamonds = 0;

    private int diamondsInstanciado = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayerController.onDeath += GameOver;
        Debug.Log("El script GameManager llama al evento onDead");
    }

    private void GameOver()
    {
        diamondsInstanciado = 0;
        Debug.Log("El script GameManager recibe el evento onDead");
    }

    public void IncreseDiamonds()
    {
        instance.diamondsInstanciado ++;
    }

    public static int GetCountDiamonds()
    {
        return instance.diamondsInstanciado;
    }
}
