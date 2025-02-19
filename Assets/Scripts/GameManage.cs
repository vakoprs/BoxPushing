using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalBoxs;
    public int finishBoxs;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetStage();
        }
    }

    void ResetStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void CheckFinish()
    {
        if (finishBoxs == totalBoxs)
        {
            print("WIN!");
            StartCoroutine(LoadNextStage());
        }

        
    }

    IEnumerator LoadNextStage()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
