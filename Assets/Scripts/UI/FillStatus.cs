using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatus : MonoBehaviour
{
    public GameManager gameManager;
    public Image fillImage;
    public Text fillText;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float fillValue = gameManager.health / gameManager.maxHealth;
        slider.value = fillValue;
        fillText.text = $"{gameManager.health}HP / {gameManager.maxHealth}HP"; 
    }
}
