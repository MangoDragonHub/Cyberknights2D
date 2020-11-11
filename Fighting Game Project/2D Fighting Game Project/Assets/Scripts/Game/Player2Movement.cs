using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    /// <summary>
    /// This player movement script is similar to a fighting game.
    /// This has been modified to work with a 2nd player via Keyboard/.
    /// Made by Rashad Patterson 10/14/20
    /// 
    /// </summary>

    [Header("Player Settings")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpHeight = 5;

    public bool isGrounded;
    public bool isFacingLeft;
    [Header("Camera Manager")]
    public GameObject camManager;

    // Start is called before the first frame update
    void Start()
    {
        isFacingLeft = true;
        isGrounded = !isGrounded;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        camManager.GetComponent<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        Jumping();
    }


    void Movement()
    {
        // Houses all Character Movement functionality
        //Get Horizontal Movement in the A(Backwards) and D(Forwards) keys

        //Forward(X+)
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Moves Right
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
            isFacingLeft = true;
            Flip();
            Debug.Log("Moving Forward");
        }
        else
        {
            //Stops
            transform.Translate(Vector3.zero);
        }
        //Backwards(X-)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Moves Left
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
            isFacingLeft = false;
            Flip();
            Debug.Log("Moving Backwards");
        }
        else
        {
            transform.Translate(Vector3.zero);
        }

        //Make Movement Stay in Camera Boundaries
        float camBounds = camManager.GetComponent<CameraManager>().camBoundariesMax;
        if (transform.position.x > camBounds)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.zero);
            }

        }
        else if (transform.position.x < -camBounds)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.zero);
            }
        }




    }
    void Jumping()
    {
        

        //Using the W key the player can jump
        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            }
        }
    }

    void Flip()
    {
        //Flips the Character's Direction based on the direction of the player.
        isFacingLeft = !isFacingLeft;
        // Multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Ground Check
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
