using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Text textLifePlayer;
    [SerializeField] private Text textCountDiamond;
    [SerializeField] private Text textGame;

    private void Awake()
    {
        PlayerController.onLivesChange += OnLivesChangeHandler;
        Debug.Log("El script Canvas llama al evento onLivesChange");
    }
    void Start()
    {
        PlayerController.onDeath += OnDeadHandler;
        Debug.Log("El script Canvas llama al evento onDead");
        DiamondController.onCountDiamond += OnCountDiamondHandler;
        Debug.Log("El script Canvas llama al evento onCountDiamond");
    }

    public void OnLivesChangeHandler(int lives)
    {
        textLifePlayer.text = lives+"";
        Debug.Log("El script Canvas recibe el evento onLivesChange y actualiza el texto de la cantidad de vidas del Player");
    }

    public void OnCountDiamondHandler(int diamond)
    {
        textCountDiamond.text = diamond+"";
        Debug.Log("El script Canvas recibe el evento onCountDiamond y actualiza el texto de la cantidad de diamantes");
    }

    public void OnDeadHandler()
    {
        textGame.text = "Te quedaste sin vidas. Fin del juego";
        Debug.Log("El script Canvas recibe el evento onDead y actualiza el texto que da fin al juego");
    }
}
