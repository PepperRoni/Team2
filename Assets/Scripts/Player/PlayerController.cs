using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(TreeFollower))]
public class PlayerController : MonoBehaviour
{
    public bool inGoalArea;

    [SerializeField] float jumpForce = 20;  
    [SerializeField] float maxJumpTime;
    [SerializeField] float timeInAir;
    [SerializeField] bool grounded;
    [SerializeField] Animator animator;
    Vector3 v3Velocity;
    private float distanceToGround;
    private Vector3 startPosition;
    private Rigidbody rb;
    private TreeFollower treeFollower;


    [SerializeField] LayerMask floor;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        timeInAir = maxJumpTime;
        inGoalArea = false;
        rb = GetComponent<Rigidbody>();
        Vector3 v3Velocity = rb.velocity;
        treeFollower = GetComponent<TreeFollower>();
        startPosition = transform.position;
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void Update()
    {
        Respawn();
        Debug.Log(rb.velocity.y);
        animator.SetFloat("Velocity", rb.velocity.y);
        
    }
    void FixedUpdate()
    {
        Jump();
        if (Input.GetKey(KeyCode.D))
        {
            treeFollower.Left(0.3f);
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
            {
                treeFollower.Left(0.5f);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            treeFollower.Right(0.3f);
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
            {
                treeFollower.Right(0.5f);
            }
        }
    }

    void Respawn()
    {
        if (transform.position.y <= startPosition.y - 15)
        {
            string thisScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(thisScene);
        }
    }

    void Jump()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
                timeInAir += Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            timeInAir = 0;
        }

        if (timeInAir > maxJumpTime)
        {
            Physics.gravity = new Vector3(0, -50f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DeathZone"))
        {
            Respawn();
        }
        if(other.CompareTag("Goal"))
        {
            inGoalArea = true;
        }
        if (other.CompareTag("Floor"))
        {
            grounded = true;
        }
        else
            grounded = false;
    }

}
