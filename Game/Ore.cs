using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    GameObject rock;
    SpriteRenderer rockSpriteRenderer;

    GameObject gem;
    SpriteRenderer gemSpriteRenderer;

    int gemIdx;

    bool selected;

    bool guessed;




    [SerializeField] float revealTime;
    int revealTick;
    bool revealing;

    void Start()
    {

        revealTime = GlobVars.gameSpeed;
        rock = transform.GetChild(0).gameObject;
        rockSpriteRenderer = rock.GetComponent<SpriteRenderer>();



    }


    public int getGemIdx() {
        return gemIdx;
    }


    public bool isSelected() {
        return selected;
    }


    public void setSelected(bool INselected)
    {
        selected = INselected;
        updateAppearance();
    }


    public bool isGuessed()
    {
        return guessed;
    }


    public void setGuessed(bool INguessed)
    {
        guessed = INguessed;
        updateAppearance();
    }



    void updateAppearance() {

        if (revealing) {
            rockSpriteRenderer.enabled = false;
            return;
        }

        rockSpriteRenderer.enabled = !(selected || guessed);

        if (guessed) {
            gemSpriteRenderer.color = new Color(0.5f, 0.5f, 0.5f);
        }

    }


    void FixedUpdate()
    {

        revealTimer();


    }
    public void tempReveal() {
        revealing = true;
        updateAppearance();
    }

    public void revealTimer() {
        if (revealing)
        {
            revealTick++;
        }

        if (revealTick >= revealTime * GlobVars.fixedUpdateRate)
        {
            revealing = false;
            revealTick = 0;
            updateAppearance();
        }
    }

    public void instantiateGem(int gemIdx) {

        gem = new GameObject("gem");

        gem.AddComponent<SpriteRenderer>()
            .sprite = GlobVars.gems[gemIdx];

        this.gemIdx = gemIdx;


        gem.transform.SetParent(gameObject.transform);
        gem.transform.localPosition = new Vector3(0, 0, 0);
        gem.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);


        gemSpriteRenderer = gem.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
