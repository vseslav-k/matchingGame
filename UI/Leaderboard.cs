using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] TMP_Text[] textBoxArr = new TMP_Text[10];

    [SerializeField] GameObject leaderboardPanel;
    bool showLeaderboard = false;


    int[] scores = new int[10];

    string[] names = new string[10];

    public static Leaderboard instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        leaderboardPanel.SetActive(showLeaderboard);
    }

    public void SetLeaderboardInfos(string[] names, int[] scores)
    {

        this.scores = scores;

        this.names = names;

        
    }




    public void UpdateLeaderboard()
    {
        string[] sortedNames = Toolbox.SortArrByArr((string[])names.Clone(), (int[])scores.Clone());
        int[] sortedScores = Toolbox.Sort(scores);

        string name = "";

        for (int i = 0; i < textBoxArr.Length; i++) {

            name = sortedNames[textBoxArr.Length - 1 - i];

            if ( (name == null || name =="") 
                  && sortedScores[textBoxArr.Length - 1 - i] == 0)
            {
                textBoxArr[i].text = "None";
                continue;
            }


            if (name == null ) {
                name = "Anonymous";
            }

            if (name.Length > 10) {
                name = name.Substring(0,10);
            }

            textBoxArr[i].text = name + ": " + sortedScores[textBoxArr.Length - 1 - i];
        }

    }


    public void ToggleLeaderboard() {
        showLeaderboard = !showLeaderboard;

        leaderboardPanel.SetActive(showLeaderboard);

        if (showLeaderboard) {
            UpdateLeaderboard();
        }
    }


}
