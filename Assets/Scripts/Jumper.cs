using UnityEngine;

public class Jumper : MonoBehaviour
{
    //variables
    private float speed = 0;
    private bool isJumping = false;

    //constants
    private Rigidbody2D rigidBody;
    private float gravity = -0.02f;
    private float startingSpeed = 0.3f;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && !isJumping)
        {
            StartJump();
        }

        if (isJumping)
        {
            rigidBody.MovePosition(new Vector3(0, transform.position.y + speed * Globals.gameSpeed, 0));
            speed += gravity * Globals.gameSpeed;

            if (speed <= -startingSpeed)
            {
                EndJump();
            }
        }
    }

    void StartJump()
    {
        ScoreManager.Add(1);
        speed = startingSpeed;
        isJumping = true;
    }

    void EndJump()
    {
        ScoreManager.Add(1);
        ResetPosition();
    }

    void ResetPosition()
    {
        rigidBody.MovePosition(new Vector3(0, -1.44f, 0));
        speed = 0;
        isJumping = false;
    }

    void Lose()
    {
        ResetPosition();
        GameObject.Find("Ball").GetComponent<Ball>().ResetRotation();
        ScoreManager.Reset();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Lose();
    }
}
