using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// This player movement script is similar to a fighting game. 
    /// Made by Rashad Patterson 10/14/20
    /// 
    /// </summary>

    [Header("Player Settings")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpHeight = 5;

    public bool isGrounded;
    public bool isFacingRight;
    [Header("Camera Manager")]
    public GameObject camManager;

    // Start is called before the first frame update
    void Start()
    {

        isFacingRight = true;
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


    public void Movement() 
    {
        // Houses all Character Movement functionality
        //Get Horizontal Movement in the A(Backwards) and D(Forwards) keys

        //Forward(X+)
        if (Input.GetKey(KeyCode.D))
        {
            //Moves Right
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
            Flip(1f);
            Debug.Log("Moving Forward");
        }
        else 
        {
            //Stops
            transform.Translate(Vector3.zero);
        }
        //Backwards(X-)
        if (Input.GetKey(KeyCode.A))
        {
            //Moves Left
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
            Flip(-1f);

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
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.zero);
            }

        }
        else if (transform.position.x < -camBounds) 
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.zero);
            }
        }




    }
    public void Jumping() 
    {
        isGrounded = !isGrounded;
        //Using the W key the player can jump
        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            }
        }
    }

    public void Flip(float horizontal) 
    {
        //If the Horizontal Input is greater than zero, your are facing right. Vice Versa.
        if (horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector2 personalScale = transform.localScale;

            //Rotates on the X
            personalScale.x *= -1;
            transform.localScale = personalScale;
        }

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
