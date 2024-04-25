using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
   
    private GameManager gameManager; 
    private TextMeshProUGUI LivesText; 

    private void Start()
    {
   
        gameManager = FindObjectOfType<GameManager>();

        
        LivesText = GetComponent<TextMeshProUGUI>();

        UpdateLivesText();
    }

    private void Update()
    {
   
        UpdateLivesText();
    }

    private void UpdateLivesText()
    {
       
        if (gameManager != null && LivesText != null)
        {
            LivesText.text = "Lives: " + gameManager.lives.ToString();
        }
    }
}

