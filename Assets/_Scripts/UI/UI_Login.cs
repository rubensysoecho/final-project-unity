using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Login : MonoBehaviour
{
    public PlayfabManager playmanager;

    public void Submit()
    {
        playmanager.SubmitNameButton();
    }
}
