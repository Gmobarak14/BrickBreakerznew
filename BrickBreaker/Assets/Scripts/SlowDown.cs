using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour{
 [SerializeField] private float speedIncreaseAmount = -25f; 
   [SerializeField] private float powerupDuration = 7f;

   private Collider2D _collider; 
   private SpriteRenderer _sprite; 
  private bool isFalling = false;

    private void Start()
    {
        // Get references to Collider2D and SpriteRenderer components
        _collider = GetComponent<Collider2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _collider.enabled = false;
        _sprite.enabled = false; 
        Invoke("TurnOn", 0.5f);
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
        float randomDelay = Random.Range(5f, 10f);
        // Wait for a short delay before starting to fall to ensure the powerup is visible
        yield return new WaitForSeconds(randomDelay);

        // Start falling by enabling movement
        isFalling = true;
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
 
   private void OnTriggerEnter2D(Collider2D other) {
    PaddleMovement paddleMovement = other.gameObject.GetComponent<PaddleMovement>();
    if(paddleMovement != null){
        StartCoroutine(speedPowerUp(paddleMovement));
    }
   }
    public IEnumerator speedPowerUp(PaddleMovement paddleMovement){
        _collider.enabled = false; 
        _sprite.enabled = false; 
        ActivateSpeedUp(paddleMovement);
        yield return new WaitForSeconds(powerupDuration);
        DeactivateSpeedUp(paddleMovement);
       // Destroy(gameObject);
       _collider.enabled = true; 
       _sprite.enabled = true; 

    }

    private void ActivateSpeedUp(PaddleMovement paddleMovement)
    {
        paddleMovement.SetMoveSpeed(speedIncreaseAmount);
    }
   private void DeactivateSpeedUp(PaddleMovement paddleMovement)
    {
        paddleMovement.SetMoveSpeed(-speedIncreaseAmount);
    }
 }

