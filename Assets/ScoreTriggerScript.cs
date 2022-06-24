using UnityEngine;
using UnityEngine.UI;

public class ScoreTriggerScript : MonoBehaviour
{
    public ScoreScript PlayerScore;     //Access player's score and GameEnd variable
    public GameObject WinText;          //Access ScoreText
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Upon entering the pot, increase score by 1, enable use of backspace to play again and display WinText
        PlayerScore.Score += 1;
        PlayerScore.GameEnd = true;
        WinText.SetActive(true);
    }
}
