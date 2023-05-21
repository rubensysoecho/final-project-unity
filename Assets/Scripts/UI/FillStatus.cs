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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float fillValue = gameManager.health / gameManager.maxHealth;
        slider.value = fillValue;

        hpText.text = $"{gameManager.health}HP / {gameManager.maxHealth}HP";
        pointsText.text = $"{gameManager.totalPoints}";
        livesText.text = $"{gameManager.lives}";
    }
}
