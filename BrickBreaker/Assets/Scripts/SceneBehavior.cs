using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBehavior : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return)){
          GameManager gameManager = FindObjectOfType<GameManager>();

            if (gameManager != null)
            {
                gameManager.score= 0;
            }
            SceneManager.LoadScene("Level1");

        }
        
    }
}
