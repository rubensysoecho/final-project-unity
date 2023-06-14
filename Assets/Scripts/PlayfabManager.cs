using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayfabManager : MonoBehaviour
{
    [Header("Referencias Leaderboard")]
    public GameObject rowPrefab;
    public Transform rowsParent;

    [Header("Referencias Interfaz")]
    public GameObject loggingWindow;
    public GameObject loginWindow;
    public GameObject menuWindow;
    public Text nameInput;
    void Start()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Successful login/account create!");
        string name = null;
        if (result.InfoResultPayload.PlayerProfile != null)
            name = result.InfoResultPayload.PlayerProfile.DisplayName;

        if (name == null)
        {
            loggingWindow.SetActive(false);
            loginWindow.SetActive(true);
        }
        else
        {
            try
            {
                loggingWindow.SetActive(false);
                loginWindow.SetActive(false);
                menuWindow.SetActive(true);
            }
            catch (Exception e)
            {

            }
            
        }
            
    }
    
    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInput.text,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }

    private void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Nick actualizado!");
        loginWindow.SetActive(false);
        menuWindow.SetActive(true);
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("ERROR");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderboard(int puntos)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Puntos",
                    Value = puntos
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Datos de leaderboard enviados");
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Puntos",
            StartPosition = 0,
            MaxResultsCount = 5
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {

        foreach(Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }

    }

}
