using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;
    public GameObject gameOverText, restartButton;

    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    // Use this for initialization
    void Start () {
        // False because only needed in game over state when player is dead
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
    } // Start
	
	// Update is called once per frame
	void Update () {
        // Value from -1 and 1 that will change from user input
        // Left arrow key is -1, Right arrow key is 1
        // Debug.Log() can be used to see inputs entered
        // Not recommended to move char in update method
        // this method gets input from player
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Uses the horizontalMove as speed to judge if animation should change
        // Mathf.Abs() used to always give positive value
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // If Jump button is pressed
        if (Input.GetButton("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        } // If

        // If Crouch button is pressed
        // If Crouch button released then stop player crouching
        if (Input.GetButton("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        } // Else if
    } // Update

    // This allows jump animation to transition back when landing
    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false); 
    } // OnLanding

    // This allows Crouch animation to transition properly
    public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    } // OnCrouching

    // Checks if player is touched by enemy checking the tag set
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            // If collision occurs then activate the game over text 
            // and restart button
            gameOverText.SetActive(true);
            restartButton.SetActive(true);

            // Set false because player is dead
            gameObject.SetActive(false);
        } // if
      
    }

    void FixedUpdate()
    {
        // This method applies the inputs
        // move the character
        // controller.Move(Move, Crouch, Jump)
        // Time.fixedDeltaTime allows us to move same amount no matter
        // how much the function is called
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        
        // So we do not keep jumping forever
        jump = false;
    } // FixedUpdate

}
