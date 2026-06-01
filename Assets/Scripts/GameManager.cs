using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game State Trackers")]
    private bool isGameOver = false;
    public int targetsRemaining = 5; // Set how many asteroids need to be destroyed for victory

    private void Awake()
    {
        if (Instance == null)
        {
            //keeps alive on wake
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //track vicroey conditions and loss conditions
    public void TargetDestroyed()
    {
        if (isGameOver) return;

        targetsRemaining--;
        Debug.Log("Targets remaining for victory: " + targetsRemaining);

        if (targetsRemaining <= 0)
        {
            TriggerVictory();
        }
    }

    public void PlayerDied()
    {
        if (isGameOver) return;

        isGameOver = true;
        Debug.Log("Game Over!");

        //freeze game on loss
        Time.timeScale = 0f;
    } 

    private void TriggerVictory()
    {
        isGameOver = true;
        Debug.Log("You Win!");

        //freeze game on victory
        Time.timeScale = 0f;
    } 
}
