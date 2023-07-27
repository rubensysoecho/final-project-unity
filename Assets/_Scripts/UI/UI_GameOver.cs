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
        Scene actualScene = SceneManager.GetActiveScene();
        if (actualScene.name.Equals("Level01"))
            SceneManager.LoadScene("Level01");
        else if (actualScene.name.Equals("Level02"))
            SceneManager.LoadScene("Level02");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
