using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TotalPoints : MonoBehaviour
{
    public Text txt_puntos;
    void Start()
    {
        int totalPoints = PlayerPrefs.GetInt("totalPoints");
        txt_puntos.text = totalPoints.ToString();
    }
}
