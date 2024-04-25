using UnityEngine;
using System.Collections;

public class PaddleMovement : MonoBehaviour
{
 public new Rigidbody2D rigidbody {get; private set;}
 public Vector2 direction { get; private set;}
 [SerializeField] private float speed = 35f;
 public float MaxBounceAngle = 75f;
private Coroutine flickerCoroutine;
private Coroutine flickerslowCoroutine;
 private SpriteRenderer spriteRenderer;
 private void Awake(){
    rigidbody = GetComponent<Rigidbody2D>();
    spriteRenderer = GetComponent<SpriteRenderer>();
 }

 public void ResetPaddle(){
    transform.position = new Vector2(0f, transform.position.y);
    rigidbody.velocity = Vector2.zero;
 }
 private void Update() {
    if (Input.GetKey(KeyCode.LeftArrow)){
        direction = Vector2.left;
    }
    else if (Input.GetKey(KeyCode.RightArrow)){
        direction = Vector2.right;
    }
    else{
        direction = Vector2.zero;
    }
    }
 private void FixedUpdate() { 
    if (direction != Vector2.zero){
        rigidbody.AddForce(this.direction * this.speed);
    }  
 }

 public void SetMoveSpeed(float newSpeedAdjustment)
 {
    speed += newSpeedAdjustment;
 }
 private void OnCollisionEnter2D(Collision2D collision) {
    BallMovement ball = collision.gameObject.GetComponent<BallMovement>();
    SpeedPowerup speedPowerup = collision.gameObject.GetComponent<SpeedPowerup>();
    if (ball != null){
        Vector3 paddlePosition = this.transform.position;
        Vector2 contactPoint = collision.GetContact(0).point;
       
        float offset = paddlePosition.x - contactPoint.x;
        float width = collision.otherCollider.bounds.size.x / 2;

        float CurrentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);
        float bounceAngle = (offset/width) * this.MaxBounceAngle;
        float NewAngle = Mathf.Clamp(CurrentAngle * bounceAngle, -this.MaxBounceAngle, this.MaxBounceAngle);
        
        Quaternion rotation = Quaternion.AngleAxis(NewAngle,Vector3.forward);
        ball.rigidbody.velocity = rotation * Vector2.up * ball.rigidbody.velocity.magnitude;
    }
    
  }
 private void OnTriggerEnter2D(Collider2D other) {
    SpeedPowerup speedPowerup = other.gameObject.GetComponent<SpeedPowerup>();
    SlowDown slowDown = other.gameObject.GetComponent<SlowDown>();
     if (speedPowerup != null && flickerCoroutine == null){
            {
                Debug.Log("Starting flicker coroutine");
                flickerCoroutine = StartCoroutine(FlickerPaddleSpeedUp());
            }
      }
      if (slowDown != null && flickerslowCoroutine == null){
            {
                Debug.Log("Starting flicker2 coroutine");
                flickerslowCoroutine = StartCoroutine(FlickerSlowDown());
            }
      }
 }
 private IEnumerator FlickerPaddleSpeedUp()
    {
      Debug.Log("Flicker coroutine started");
        int flickerCount = 0;
        spriteRenderer.color = Color.yellow;
        

        while (flickerCount < 3)
        {
            // Toggle paddle visibility
            spriteRenderer.enabled = !spriteRenderer.enabled;
            // Wait for a short duration
            yield return new WaitForSeconds(0.15f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.15f);
            flickerCount++;
        }

        // Wait for 5 seconds after flickering
        yield return new WaitForSeconds(7f);

        flickerCount = 0;

        while (flickerCount < 3)
        {
            // Toggle paddle visibility
            spriteRenderer.enabled = !spriteRenderer.enabled;

            // Wait for a short duration
            yield return new WaitForSeconds(0.15f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.15f);
            flickerCount++;
        }
       spriteRenderer.color = new Color(204f,250f,247f);
        // Reset flicker coroutine
        flickerCoroutine = null;
    }
 private IEnumerator FlickerSlowDown()
    {
      Debug.Log("Flicker2 coroutine started");
        spriteRenderer.color = Color.red;
        
        yield return new WaitForSeconds(8f);
         flickerslowCoroutine = null;
         Debug.Log("Flicker2 coroutine end");
         spriteRenderer.color = new Color(204f,250f,247f);
        // Reset flicker coroutine
        
    }
}










