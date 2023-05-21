using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_GameOver : MonoBehaviour
{
    public Text pointsText;

    public void Setup(float puntos)
    {
        gameObject.SetActive(true);
        pointsText.text = puntos.ToString() + " PUNTOS";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Level01");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
