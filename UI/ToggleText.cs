using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleText : MonoBehaviour
{
    [SerializeField] GameObject infoText;

    [SerializeField] bool isActive;

    private void Start()
    {
        infoText.SetActive(isActive);
    }
    public void Toggle() {
        isActive = !isActive;


        infoText.SetActive(isActive);

    }
    
}
