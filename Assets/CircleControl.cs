using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleControl : MonoBehaviour
{
    private bool FloatingCircle = true;     //This value remains true as long as the player does not press space. When it turns false, player cannot use arrowkeys anymore.
    private float Direction = 0;            //Used to pass direction between Update and Fixed Update. -1 is left, 0 is none, 1 is right.
    public float MovementSpeed;             //Movement speed changeable in the Inspector.

    public ScoreScript PlayerScore;         //For access to GameEnd value stored in ScoreScript script

    public GameObject WinText;              //For access to ScoreText
    public GameObject LoseText;             //For access to LoseText
    Rigidbody2D CircleRigidBody;            //Used to lift Y constraint after pressing space.

    private void Start()
    {
        //assign RigidBody
        CircleRigidBody = GetComponent<Rigidbody2D>();  
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //This is executed when the player clicks backspace after the the ball has either touched the ground or fallen into one of the pots
        if (Input.GetKeyDown(KeyCode.Backspace) && PlayerScore.GameEnd == true)
        {
            transform.position = new Vector3(-0.15f, 4.34f);                        //Return ball to original position

            CircleRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;   //Set Y constraint

            CircleRigidBody.velocity = Vector2.zero;                                //Make sure no velocity remains applied to ball
            CircleRigidBody.angularVelocity = 0;                                    //Make sure no velocity remains applied to ball

            FloatingCircle = true;                                                  //Enable use of arrowkeys

            PlayerScore.GameEnd = false;                                            //Set GameEnd to false

            WinText.SetActive(false);                                               //Make sure no win/lose text is displayed
            LoseText.SetActive(false);                                              //Make sure no win/lose text is displayed
            return;
        }

        if (FloatingCircle)
        {
            //When space is pressed, arrowkeys do not work anymore and Y constraint is lifted
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FloatingCircle = false;
                Direction = 0;
                CircleRigidBody.constraints = RigidbodyConstraints2D.None;
                return;
            }

            //If space has not been pressed yet, arrowkeys are used to provide movement directions for Circle
            Direction = Input.GetAxisRaw("Horizontal");   
        }
    }
    

    private void FixedUpdate()
    {
        if (Direction == 1)
        {
            //Move right
            transform.position += new Vector3(1, 0, 0) * MovementSpeed;
        }
        else if (Direction == -1)
        {
            //Move left
            transform.position += new Vector3(-1, 0, 0) * MovementSpeed;
        }
    }
}
