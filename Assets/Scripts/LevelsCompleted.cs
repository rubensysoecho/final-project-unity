using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class LevelsCompleted : MonoBehaviour
{
    static bool lvl1_completado = false;
    static bool lvl2_completado = false;
    static bool lvl3_completado = false;
    static bool lvl4_completado = false;

    public static void CompletarNivel(int nivel)
    {
        switch (nivel)
        {
            case 1:
                lvl1_completado = true;
                break;
            case 2:
                lvl2_completado = true;
                break;
            case 3:
                lvl3_completado = true;
                break;
            case 4:
                lvl4_completado = true;
                break;
            default:
                Debug.Log("ERROR: Nivel no encontrado");
                break;
        }
    }

    public static bool IsNivelCompletado(int nivel)
    {
        switch (nivel)
        {
            case 1:
                return lvl1_completado;
            case 2:
                return lvl2_completado;
            case 3:
                return lvl3_completado;
            case 4:
                return lvl4_completado;
            default:
                Debug.Log("ERROR: Nivel no encontrado");
                return false;
        }
    }

}
