using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int Score = 0;           //Variable for storing the player's score
    public bool GameEnd = false;    //This variable turns true when the ball touches the ground or falls into a pot. When true, player can click backspace to play again.
} 
