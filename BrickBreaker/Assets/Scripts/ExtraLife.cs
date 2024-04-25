using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
 private Collider2D _collider; 
 private SpriteRenderer _sprite; 
 private bool isFalling = false;
 private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _collider.enabled = false;
        _sprite.enabled = false; 
        Invoke("TurnOn", 0.5f);
    }
    private void Update()
    {
        if (isFalling)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 5f);
        }
        if (transform.position.y < -15){
            Invoke("TurnOn", 16);}

    }
  private void TurnOn(){
        _collider.enabled = true;
        _sprite.enabled = true;
        float randomX = Random.Range(-13f, 13f);
        Vector3 randomPosition = new Vector3(randomX, 12, 0);
        transform.position = randomPosition;
        StartCoroutine(FallCoroutine());
        
    }
    private IEnumerator FallCoroutine()
    {
        float randomDelay = Random.Range(8f, 20f);
        yield return new WaitForSeconds(randomDelay);

        isFalling = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision is with the player's paddle
        PaddleMovement paddleMovement = other.gameObject.GetComponent<PaddleMovement>();
        if(paddleMovement != null){}
        {

            GameManager gameManager = FindObjectOfType<GameManager>();
             Debug.Log("Gamemanage");

    
            if (gameManager != null)
            {
                gameManager.GiveExtraLife();
                Debug.Log("added");
            }
             _sprite.enabled = false;
          
        }
    }
}
