using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameMenu : MonoBehaviour
{

    [SerializeField] GameObject menu;

    private void OnEnable()
    {
        Actions.GameWon += Appear;

    }

    private void OnDisable()
    {
        Actions.GameWon -= Appear;
    }



    void Appear() {

        menu.SetActive(true);

    }
    void Start()
    {
        menu.SetActive(false);
    }

}
