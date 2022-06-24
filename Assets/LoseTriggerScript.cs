using UnityEngine;
using UnityEngine.UI;

public class LoseTriggerScript : MonoBehaviour
{
    public ScoreScript PlayerScore;     //Access player's score and GameEnd variable
    public GameObject LoseText;         //Access LoseText

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Upon touching the ground set score to 0, enable use of backspace to play again and display LoseText
        PlayerScore.Score = 0;
        PlayerScore.GameEnd = true;
        LoseText.SetActive(true);
    }
}
