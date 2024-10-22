using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;


    public int tries=0;
    public int fixedTimeTicks;
    public TMP_Text timeText;


    public TMP_Text triesText;

    public TMP_Text score;


    bool gameWon=false;

    [SerializeField]int guessed;

    private void OnEnable()
    {
        Actions.GameWon += UpdateGameWon;

    }

    private void OnDisable()
    {
        Actions.GameWon -= UpdateGameWon;
    }

    void UpdateGameWon() {

        gameWon = true;
        DispScore();
    }


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        triesText.text = "Tries: 0";
    }

    void FixedUpdate()
    {
        if (!gameWon) { fixedTimeTicks++; }

        DisplayTime();
    }

    void DisplayTime() {
        int min = (fixedTimeTicks / GlobVars.fixedUpdateRate) / 60;
        int sec = (fixedTimeTicks / GlobVars.fixedUpdateRate) % 60;

        timeText.text = string.Format("Time {0:00}:{1:00}", min, sec);


    }


    public void UpdateTries() {
        tries++;

        triesText.text = "Tries: " + tries;
    }

    public void AddGuessed() {
        guessed+=2;

    }

    void DispScore() {
        score.text = "Score: " + CalcScore();
    }

    public int GetGuessed() {

        return guessed;


    }


    public int CalcScore() {

        return (3750000 * Player.instance.GetFieldSize() ) / (fixedTimeTicks* tries);
    
    }
}
