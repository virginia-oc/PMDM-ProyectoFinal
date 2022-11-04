using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private int puntos;
    [SerializeField] TMPro.TextMeshProUGUI HUD;
    [SerializeField] TMPro.TextMeshProUGUI gameOverText;  

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            puntos = FindObjectOfType<GameStatus>().puntos;
            HUD.text = "Score: " + puntos;
            StartCoroutine(GameOverEffect());
        }  
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            float salto = Input.GetAxisRaw("Jump");
            if (salto > 0)           
                SceneManager.LoadScene("WelcomeScene");           
        }
      
        if (SceneManager.GetActiveScene().name == "WelcomeScene")
        {           
            if (Input.anyKey)           
                SceneManager.LoadScene("Level1");           
        }
    }

    public void LanzarJuego()
    {
        FindObjectOfType<GameStatus>().SendMessage("ResetGameStatus");
        SceneManager.LoadScene("Level1");
    }

    private IEnumerator GameOverEffect()
    {
        yield return new WaitForSeconds(0.5f);
        if (gameOverText.enabled == true)
            gameOverText.enabled = false;
        else
            gameOverText.enabled = true;
        StartCoroutine(GameOverEffect());
    }
}
