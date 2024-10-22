using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Class responsible for processing user input, as well as instantiating the level when it first loads

public class Player : MonoBehaviour
{
    public static Player instance;
    [SerializeField] int gameFieldSize;

    [SerializeField] InputManager inpManager;


    [SerializeField] Ore oreChoice1;
    [SerializeField] Ore oreChoice2;

    [SerializeField] float evalCooldown;
    int evalCooldownTick;
    bool evalCooledDown;



    private void Awake()
    {
        instance = this;
    }

    void OnEnable()
    {
        Actions.OrePressed += SelectOre;
    }


    public void SetEvalCooldown(float x) {
        evalCooldown = x;
    }


    public float GetEvalCooldown()
    {
        return evalCooldown;
    }


    public int GetFieldSize() {
        return gameFieldSize;
    }

    public void ForceSetOreSelection(Ore o1, Ore o2) {
        oreChoice1 = o1;
        oreChoice2 = o2;

        if (oreChoice1 != null && oreChoice2 != null)
        {

            evalCooledDown = false;
            EvaluateSelections(false);
        }
    }



    void SelectOre() {

        if (!evalCooledDown) {
            return;
        }

        if (oreChoice1 == null)
        {

            
            oreChoice1 = inpManager.GetLastObjectTouched().GetComponent<Ore>();


            oreChoice1.setSelected(true);

            Debug.Log("oreChoice1 " + oreChoice1.gameObject.name);
        }
        else {
            oreChoice2 = inpManager.GetLastObjectTouched().GetComponent<Ore>();
            oreChoice2.setSelected(true);

            Debug.Log("oreChoice2 " + oreChoice2.gameObject.name);
        }



        if (oreChoice1 != null && oreChoice2 != null) {

            evalCooledDown = false;
            EvaluateSelections();
        }
    }

    void InputTimer(bool forceReload = false) {

        if (forceReload) {
            evalCooledDown = true;
            evalCooldownTick = 0;
            return;
        }

        if (evalCooledDown) {
            return;
        }

        evalCooldownTick++;

        if (evalCooldownTick >= evalCooldown * GlobVars.fixedUpdateRate) {
            evalCooledDown = true;
            evalCooldownTick = 0;
        }


    }

    private void FixedUpdate()
    {
        InputTimer();
    }
    void EvaluateSelections(bool countTry = true) {


        if (countTry){
            Debug.Log("Try Counted "+ countTry);
            ScoreManager.instance.UpdateTries();
        }

        if (oreChoice1.getGemIdx() == oreChoice2.getGemIdx() &&
            oreChoice1 != oreChoice2)
        {

            oreChoice1.setGuessed(true);
            oreChoice2.setGuessed(true);

            InputTimer(true);


            ScoreManager.instance.AddGuessed(); 



            if (ScoreManager.instance.GetGuessed() == gameFieldSize) {
                Actions.GameWon();
            }

        }
        else {
            oreChoice1.tempReveal();
            oreChoice2.tempReveal();
        }

        oreChoice1.setSelected(false);
        oreChoice2.setSelected(false);

        oreChoice1 = null;
        oreChoice2 = null;

    }



    void Start()
    {
        evalCooldown = GlobVars.gameSpeed;
        AssignGems();




    }


    void AssignGems() {
        List<int> lst = GenGemAssignementLst();

        GameObject[] ores = GameObject.FindGameObjectsWithTag(GlobVars.oreTag);

        for (int i = 0; i < ores.Length; i ++) {

            ores[i].GetComponent<Ore>().instantiateGem(lst[i]);
        }
    }


    List<int> GenGemAssignementLst() {

        List<int> lst = new List<int>();

        int i = 0;
        while (lst.Count != GlobVars.gems.Length)
        {
            lst.Add(i);
            i++;
        }


        while (lst.Count > gameFieldSize / 2)
        {
            lst.RemoveAt(Random.Range(0, lst.Count));
        }


        lst.AddRange(lst);


        lst = Toolbox.Shuffle<int>(lst,1000);


        Debug.Log(Toolbox.LstToStr(lst));

        return lst;
    }


    void Update()
    {
        
    }



    void OnDisable()
    {
        Actions.OrePressed -= SelectOre;
    }
}
