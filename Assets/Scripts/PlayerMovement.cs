using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class PlayerCtrl2 : MonoBehaviour
{
    public float speed = 1.0f;
    public float drift = 2.0f;
    public float jumpForce = 5.0f;

    private Rigidbody rb;
    private float xPosition;
    private bool isRunning;

    private Animator animator;
    private CapsuleCollider coll;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider>();

        xPosition = rb.position.x;

        
    }

    void Update()
    {
        MoveHorizontal();
        MoveVertical();
        PauseMenu();
    }

    void MoveHorizontal()
    {
        Vector3 pos = rb.position;
        pos.x = Mathf.MoveTowards(pos.x, xPosition, drift * Time.deltaTime);
        rb.position = pos;

        if (Input.GetKeyDown(KeyCode.A) && pos.x % 1 == 0 && !(pos.x <= -1))
        {
            xPosition -= 1;
        }
        if (Input.GetKeyDown(KeyCode.D) && pos.x % 1 == 0 && !(pos.x >= 1))
        {
            xPosition += 1;
        }
    }

    void MoveVertical()
    {
        //allow for slide calcelation with jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())//&&!this.animator.GetCurrentAnimatorStateInfo(0).IsName("slide")
        {
            animator.SetTrigger("jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && !this.animator.GetCurrentAnimatorStateInfo(0).IsName("jump"))
        {
            animator.SetTrigger("slide");
            StartCoroutine(ChangeHitboxDuringSlide());
        }
    }

    bool isGrounded()
    {
        return rb.velocity.y == 0;
    }


    IEnumerator ChangeHitboxDuringSlide()
    {

        // Zmniejsz rozmiar hitboxa podczas animacji
        coll.height = 1.0f;
        coll.center = new Vector3(0, 0.5f, 0);

        // Czekaj do zakoñczenia animacji
        yield return new WaitForSeconds(1f); // Zast¹p animationTime czasem trwania animacji


        coll.height = 1.8f;
        coll.center = new Vector3(0, 0.9f, 0);
    }

    void PauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }





}

