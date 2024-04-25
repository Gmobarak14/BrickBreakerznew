using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer {get; private set;}
    [SerializeField] private Color[] states;
    public int health {get; private set;}
    public int points =  100; 
    public bool unbreakable;

    
    private void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!unbreakable){
            health = states.Length;
            spriteRenderer.color = states[health-1];

        }

    }
    private void Hit(){
        if (unbreakable) {
            return;
        }
        health --;

        if (health <= 0) {
            gameObject.SetActive(false);
        }
        else {
         spriteRenderer.color = states[health-1];
        }
        FindObjectOfType<GameManager>().Hit(this);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Ball"){
            Hit();
        }    
     }

}
