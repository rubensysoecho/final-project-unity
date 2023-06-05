using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatus : MonoBehaviour
{
    public GameManager gameManager;
    public Image fillImage;
    public Text hpText;
    public Text pointsText;
    public Text livesText;
    public Slider slider;

    void Start()
    {

    }

    void Update()
    {
        float fillValue = (float)gameManager.health / (float)gameManager.maxHealth;
        slider.value = fillValue;

        hpText.text = $"{gameManager.health}HP / {gameManager.maxHealth}HP";
        pointsText.text = $"{gameManager.levelPoints}";
        livesText.text = $"{gameManager.lives}";
    }
}
