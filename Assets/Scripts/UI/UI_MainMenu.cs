using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    public void Iniciar()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void IniciarEstadisticas()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void Salir()
    {
        Debug.Log("CERRAR");
        Application.Quit();
    }
}
