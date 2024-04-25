
using UnityEngine;

public class BallMovement : MonoBehaviour
{
 public new Rigidbody2D rigidbody {get; private set;}
 public float speed = 400f;
//public float minSpeed = 300f;
 
 private void Awake(){
    rigidbody = GetComponent<Rigidbody2D>();
  }
  private void Start(){
  
    ResetBall();

  }
 private void SetRandomTrajectory(){
    Vector2 force = Vector2.zero;

    do
    {
        force.x = Random.Range(-1f, 1f);
        force.y = 1f;
    }
    while (Mathf.Approximately(force.x, 0f) && Mathf.Approximately(force.y, 0f));

    rigidbody.AddForce(force.normalized * speed);
 }
 public void ResetBall(){
   transform.position = new Vector2(0f,-8.5f);
   rigidbody.velocity = Vector2.zero;
   
   Invoke(nameof(SetRandomTrajectory),1f);
 }
  private void FixedUpdate()
    {
        rigidbody.velocity = rigidbody.velocity.normalized * speed;
    }

    
}

