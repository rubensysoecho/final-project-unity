using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_LevelSelection : MonoBehaviour
{
    void Start()
    {
        Color objectColor = gameObject.GetComponent<Image>().color;
        switch (gameObject.name)
        {
            case "Level1":
                if (LevelsCompleted.IsNivelCompletado(1))
                {
                    objectColor = Color.HSVToRGB(149, 77, 84);
                }
                else
                {
                    objectColor = Color.HSVToRGB(8, 82, 84);
                }
                break;
            case "Level2":
                if (LevelsCompleted.IsNivelCompletado(2))
                {
                    objectColor = Color.HSVToRGB(149, 77, 84);
                }
                else
                {
                    objectColor = Color.HSVToRGB(8, 82, 84);
                }
                break;
            case "Level3":
                if (LevelsCompleted.IsNivelCompletado(3))
                {
                    objectColor = Color.HSVToRGB(149, 77, 84);
                }
                else
                {
                    objectColor = Color.HSVToRGB(8, 82, 84);
                }
                break;
            case "Level4":
                if (LevelsCompleted.IsNivelCompletado(4))
                {
                    objectColor = Color.HSVToRGB(149, 77, 84);
                }
                else
                {
                    objectColor = Color.HSVToRGB(8, 82, 84);
                }
                break;
        }
        
    }
    public void StartLevel1()
    {
        SceneManager.LoadScene("Level01");
    }
    public void StartLevel2()
    {
        SceneManager.LoadScene("Level02");
    }
    public void StartLevel3()
    {
        SceneManager.LoadScene("Level03");
    }
    public void StartLevel4()
    {
        SceneManager.LoadScene("Level04");
    }
}
