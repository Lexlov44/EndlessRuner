using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float startMoveSpeed;

    public float jumpForce;
    //private bool jumpControl;
    //private float jumpIterationTime = 0;
    //public int jumpValueIteration = 60;


    public GameObject JumpPoint;
    public GameObject DethPoint;

    private Rigidbody2D myRigidbody;

    public bool grounded;

    public LayerMask Grounds;

    private Animator myAnimator;

    public int countJump;

    public float curentMoveAcceleration;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myAnimator = GetComponent<Animator>();

        myAnimator.SetBool("UpJump", false);
        myAnimator.SetBool("DownFall", false);

    }

    void Update()
    {
        curentMoveAcceleration = 0.0001f + curentMoveAcceleration;
        myRigidbody.velocity = new Vector2(curentMoveAcceleration + startMoveSpeed, myRigidbody.velocity.y);

        Jump();

        CheckDeth();

        Animation();

    }

    private void CheckDeth()
    {
        if (transform.position.y < DethPoint.transform.position.y)
            RestartThisGame();
    }

    private void Jump()
    {
        /*
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (grounded) { jumpControl = true; }
        }
        else { jumpControl = false; }

        if (jumpControl)
        {
            if ((jumpIterationTime += Time.deltaTime) < jumpValueIteration)
            {
                myRigidbody.AddForce(Vector2.up * jumpForce / (jumpIterationTime * 10));
            }
        }
        else { jumpIterationTime = 0; }
        */

        //Фиксированный прыжок
         if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && countJump > 0)
         {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            countJump--;
         }

        if (grounded)
        {
            countJump = 1;
        }
    }


    private void Animation()
    {
        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);

        if (myRigidbody.velocity.y > 0)
        {
            myAnimator.SetBool("UpJump", true);
            myAnimator.SetBool("DownFall", false);
            myAnimator.SetBool("Grounded", false);
        }

        if (myRigidbody.velocity.y < 0)
        {
            myAnimator.SetBool("DownFall", true);
            myAnimator.SetBool("UpJump", false);
            myAnimator.SetBool("Grounded", false);
        }

        if (grounded)
        {
           myAnimator.SetBool("UpJump", false);
           myAnimator.SetBool("DownFall", false);
           myAnimator.SetBool("Grounded", true);
        }

    }

    private void RestartThisGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
