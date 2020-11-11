using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimSystem : MonoBehaviour
{
    /// <summary>
    /// This holds all the Animation Data for the player and allows the player play the animations.
    /// This is made by Rashad Patterson 10/22/2020
    /// 
    /// </summary>

    private const string anim_idle = "Test_Idle";
    private const string anim_attack = "Test_Attack";
    private const string anim_jump = "Test_Jump";
    private const string anim_knockback = "Test_Knockback";

    public Animation anim;
    public PlayerMovement playerMovement;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        ///If they player press specific key, do this animation.
        //Play Jump Animation
        if (Input.GetKeyDown(KeyCode.W) && playerMovement.isGrounded == false)
        {
            anim.Play(anim_jump);
        }


        //Play Attack Animation
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.M)) 
        {
            anim.Play(anim_attack);
        }
    }

}
