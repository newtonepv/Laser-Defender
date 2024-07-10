using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] float delayForChangingScene;
    Coroutine changeSceneCoroutine;
    public void LoadLevel1()
    {
        string scene = "Level1";
        if (changeSceneCoroutine == null)
        {
            changeSceneCoroutine = StartCoroutine(WaitAndLoad(scene, delayForChangingScene));
        }
        else
        {
            StopCoroutine(changeSceneCoroutine);
            changeSceneCoroutine = StartCoroutine(WaitAndLoad(scene, delayForChangingScene));
        }
    }
    public void LoadGameOver()
    {
        string scene = "GameOver";
        if (changeSceneCoroutine == null)
        {
            changeSceneCoroutine = StartCoroutine(WaitAndLoad(scene, delayForChangingScene));
        }
        else
        {
            StopCoroutine(changeSceneCoroutine);
            changeSceneCoroutine = StartCoroutine(WaitAndLoad(scene, delayForChangingScene));
        }
    }

    public void LoadMainMenu()
    {
        string scene = "MainMenu";
        if (changeSceneCoroutine == null)
        {
            changeSceneCoroutine = StartCoroutine(WaitAndLoad(scene, delayForChangingScene));
        }
        else
        {
            StopCoroutine(changeSceneCoroutine);
            changeSceneCoroutine = StartCoroutine(WaitAndLoad(scene, delayForChangingScene));
        }
    }

    public void Quit()
    {
        Debug.Log("exiting the game");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string scene, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
}

