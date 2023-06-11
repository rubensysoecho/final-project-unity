using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_MainMenu : MonoBehaviour
{
    public void Iniciar()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void IniciarOpciones()
    {
        SceneManager.LoadScene("Options");
    }

    public void IniciarEstadisticas()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
