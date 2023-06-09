using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_LevelFinished : MonoBehaviour
{
    public Text pointsText;

    public void Setup(float puntos)
    {
        gameObject.SetActive(true);
        pointsText.text = puntos.ToString() + " PUNTOS";
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene("Level02");
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelection");
    }
}
