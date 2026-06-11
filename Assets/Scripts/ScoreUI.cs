using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Update()
    {
        //check if GameManager exists
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager is NULL - make sure it exists in the scene!");
            return;
        }

        //check if scoreText is assigned
        if (scoreText == null)
        {
            Debug.LogError("ScoreText is NOT assigned in Inspector!");
            return;
        }

        //update score
        scoreText.text = "Score: " + GameManager.Instance.score;
    }
}