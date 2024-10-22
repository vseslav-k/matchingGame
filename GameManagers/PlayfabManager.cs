using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabManager : MonoBehaviour
{
    public static PlayfabManager instance;


    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Login();
        
    }

    // Update is called once per frame
    void Login() {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);

    }

    void OnSuccess(LoginResult result) {
        Debug.Log("Succesful Login/ acct create");
        GetLeaderboard();
    }

    void OnError(PlayFabError error)
    {
        Debug.LogError("Error logging in/acct create");
        Debug.Log(error.GenerateErrorReport());
    }


    public void SendLeaderboard() {


        int score = ScoreManager.instance.CalcScore();
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate{
                    StatisticName = "TFGTryoutLeaderboard",
                    Value = score,
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);

    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result) {
        Debug.Log("Succesful leaderboard send");
    }

    public void GetLeaderboard() {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "TFGTryoutLeaderboard",
            StartPosition = 0,
            MaxResultsCount = 10
        };

        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }


    void OnLeaderboardGet(GetLeaderboardResult result) {

        Debug.Log(result.Leaderboard.Count);

        int[] scores = new int[10];
        string[] names = new string[10];


        for (int i=0;i< result.Leaderboard.Count;i++) {
            Debug.Log(result.Leaderboard[i].Position + " " + result.Leaderboard[i].PlayFabId + " " + result.Leaderboard[i].StatValue);

            scores[i] = result.Leaderboard[i].StatValue;
            names[i] = result.Leaderboard[i].PlayFabId;
        }


        Leaderboard.instance.SetLeaderboardInfos(names, scores);
    }


}
