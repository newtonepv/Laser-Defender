using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    public float score = 0;
    UiScript uiScript;
    static PointsCounter instance;
    private void Awake()
    {
        ManageDestructionLogic();
    }
    void ManageDestructionLogic()
    {
        if (instance != null)
        {
            instance.gameObject.SetActive(false);
            Destroy(instance.gameObject);

        }

        instance = this;
        DontDestroyOnLoad(instance);
    }
    public void SetScore(float score)
    {
        this.score = score;
        if(uiScript!=null){
            uiScript.SetScore(score);
        }
    }
    public float GetScore()
    {
        return score;
    }
    void Start()
    {
        uiScript = FindObjectOfType<UiScript>();
        SetScore(0);
    }

    void Update()
    {
        
    }
}
