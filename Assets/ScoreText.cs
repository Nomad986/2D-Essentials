using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoreText;              //Access Text used to display Score
    public ScoreScript PlayerScore;     //Access player's score
    
    void Update()
    {
        scoreText.text = "Score: " + PlayerScore.Score.ToString();  //Display score
    }
}
