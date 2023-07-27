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
            case "Level2":
                if (PlayerPrefs.GetInt("lvl_completados") == 1)
                {
                    objectColor = Color.HSVToRGB(149, 77, 84);
                }
                break;
            case "Level3":
                if (PlayerPrefs.GetInt("lvl_completados") == 2)
                {
                    objectColor = Color.HSVToRGB(149, 77, 84);
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
