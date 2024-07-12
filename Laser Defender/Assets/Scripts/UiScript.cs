using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] Sprite spriteDebug;
    [SerializeField] Slider healthSlider;
    [SerializeField] Image powerUpPanel;
    void Start()
    {
    }
    
    public void SetHealth(float value)
    {
        healthSlider.value = value;
    }

    public void SetScore(float score)
    {
        textMeshProUGUI.text = score.ToString("000000000");
    }
    public void SetPowerUpImage(Sprite sprite)
    {
        powerUpPanel.sprite = sprite;
        Debug.Log("elpepe");
    }
    void Update()
    {
        
    }
}
