using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUIScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTextMeshPro;
    PointsCounter pointsCounter;
    private void Awake()
    {
        pointsCounter = FindObjectOfType<PointsCounter>();
    }
    void Start()
    {
        if (pointsCounter != null)
        {
            scoreTextMeshPro.text = pointsCounter.GetScore().ToString();
        }
    }

    void Update()
    {
        
    }
}
