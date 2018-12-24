using UnityEngine;

public class Ball : MonoBehaviour
{
    //variables
    private float speed;
    private float acceleration = 0.08f;

    //constants
    private float startingSpeed = 180.0f;

    void Awake()
    {
        speed = startingSpeed;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed * Globals.gameSpeed);
        speed += acceleration * Globals.gameSpeed;
    }

    public void ResetRotation()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        speed = startingSpeed;
    }
}
