using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{



    public void LoadScene(string name) {

        SceneManager.LoadSceneAsync(name);
    }

    public void LoadScene(int idx)
    {

        SceneManager.LoadSceneAsync(idx);
    }
}
