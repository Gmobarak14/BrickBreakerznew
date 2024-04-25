using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;

public class GameManager : MonoBehaviour

{
    public BallMovement ball { get; private set;}
    public PaddleMovement paddle { get; private set;}
    public Brick[] bricks { get; private set;}
    public int level = 1;
    public int score = 0;
    public int  lives= 3; 
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI LivesText;

   private void Awake(){
    DontDestroyOnLoad(gameObject);
    SceneManager.sceneLoaded += OnLevelLoaded;
    //SceneManager.LoadScene("Home"); 
   }
    
    private void Start(){
        NewGame();
    }

    private void NewGame(){
        score =0;
        lives =3;
        LoadLevel(1);
        

    }
    private void LoadLevel(int level){
        this.level = level;
        SceneManager.LoadScene("Home"); 
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        ball = FindObjectOfType<BallMovement>();
        paddle = FindObjectOfType<PaddleMovement>();
        bricks = FindObjectsOfType<Brick>();
      if (scene.name == "Level2") {
        if (lives < 3){
            lives = 3;
        }
      if (scene.name == "Level1") {
        score=0; }
      }
    }

    private void ResetLevel(){
        ball.ResetBall();
        paddle.ResetPaddle();
    }

    private void GameOver(){
        //score = 0;
        lives =3;
        SceneManager.LoadScene("EndMenu") ;
    }
    
    public void Miss(){
        lives --;
        if( lives > 0){
            ResetLevel();
        }
        else {
            GameOver();
        }

    }
    public void Hit(Brick brick){
        score += brick.points;
        if (Cleared() && SceneManager.GetActiveScene().name != "Level2"){
            SceneManager.LoadScene("Level2"); }
        if(Cleared()&& SceneManager.GetActiveScene().name == "Level2"){
            SceneManager.LoadScene("Win");
        }
    }

    private bool Cleared()
        {
         for (int i = 0; i < bricks.Length; i++)
 {
            if (bricks[i].gameObject.activeInHierarchy && !bricks[i].unbreakable) {
                return false;
            }
        }

        return true;
    }
 public void GiveExtraLife()
{
    lives++;
}

}


