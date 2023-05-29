using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    public void Iniciar()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void IniciarEstadisticas()
    {

    }

    public void Salir()
    {
        Debug.Log("CERRAR");
        Application.Quit();
    }
}
