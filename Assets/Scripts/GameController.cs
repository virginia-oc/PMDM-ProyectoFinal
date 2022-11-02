using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int puntos;
    private int vidas;
    private int nivelActual;
    [SerializeField] TMPro.TextMeshProUGUI HUD;

    // Start is called before the first frame update
    void Start()
    {
        puntos = FindObjectOfType<GameStatus>().puntos;
        vidas = FindObjectOfType<GameStatus>().vidas;
        nivelActual = FindObjectOfType<GameStatus>().nivelActual;
        HUD.text = "Lives left: " + vidas  + "    " +
            "Score: " + puntos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnotarItemRecogido()
    {
        puntos += 500;
        FindObjectOfType<GameStatus>().puntos = puntos;
    }

    public void PerderVida()
    {
        vidas--;
        FindObjectOfType<GameStatus>().vidas = vidas;
        UpdateHUD();
    }

    private void AvanzarNivel()
    {
        nivelActual++;
        if (nivelActual > FindObjectOfType<GameStatus>().nivelMaximo)
            nivelActual = 1;
        FindObjectOfType<GameStatus>().nivelActual = nivelActual;
        SceneManager.LoadScene("Level" + nivelActual);
    }

    public void AnotarBubbleAlone()
    {
        puntos += 10;
        FindObjectOfType<GameStatus>().puntos = puntos;
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        HUD.text = "Lives left: " + vidas + "    " +
            "Score: " + puntos;
    }
}
