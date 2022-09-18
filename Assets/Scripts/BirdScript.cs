using UnityEngine;

public class BirdScript : MonoBehaviour
{

    // public/private are access modifiers
    // public: the type or member can be accessed by any other code
    // private: only members of this class have access to it.

    // We use public variables to access the variables direct from the unity editor

    public float jumpForce = 5.0f;
    public float speed = 1.0f;

    // An attached Rigidbody controls the object position through physics simulation.
    private Rigidbody2D body;

    private bool jump = false;
    public bool alive = true;

    // Use this for initialization
    void Start()
    {
        // GetComponent is the primary way of accessing other components. 
        // It returns the component of Type type Rigidbody2D if the game object has one attached, null if it doesn't.
        body = GetComponent<Rigidbody2D>();

        ResetScene();
    }

    // FixedUpdate runs at a fixed time interval. Used for applying forces, torque and other physics related functions.
    void FixedUpdate()
    {
        // Calls the MoveRight Method.
        // A method is a code block that contains a series of statements. 
        MoveRight();

        // Do we have to jump that
        if (jump)
        {
            // Calls the Jump method.
            Jump();
            // Handled jump
            jump = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Is only executed when the user starts pressing down the key Space.
        if (Input.GetKeyDown(KeyCode.Space))
            jump = true;
        // wait for any input after a collision to restart the game 
        if (!alive && Input.anyKey)
            ResetScene();
    }

    // Set the velocity of the bird to "jumpForce". Will cause the physics engine to move the bird up.
    void Jump()
    {
        body.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
    }

    // Moves the bird with "speed" per second on the x-axis.
    void MoveRight()
    {
        transform.position += new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime;
    }

    // Is called when the collider of the bird intersects with an other collider 
    void OnCollisionEnter2D()
    {
        // Time scale = 0.0f pauses the game, 
        // All frame dependent functions are not longer called e.g. FixedUpdate
        Time.timeScale = 0.0f;

        // Colors the bird "black"
        GetComponent<SpriteRenderer>().color = Color.black;

        // Set the game over sprite as background, disable normal background
        GameObject.FindGameObjectWithTag("background").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindGameObjectWithTag("gameover").GetComponent<SpriteRenderer>().enabled = true;

        // Help flag, indicates that we have to wait until the player restarts the game
        alive = false;
    }

    void ResetScene()
    {
        // Reset to original bird color
        GetComponent<SpriteRenderer>().color = Color.white;

        // Move the bird to the start position
        transform.position = new Vector3(0, 0, 0);

        // Help flag, indicates the normal play mode
        alive = true;

        // Reset the background
        GameObject.FindGameObjectWithTag("background").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.FindGameObjectWithTag("gameover").GetComponent<SpriteRenderer>().enabled = false;

        // Unpause the game, FixedUpdate is called again every frame.
        Time.timeScale = 1.0f;
    }
}
