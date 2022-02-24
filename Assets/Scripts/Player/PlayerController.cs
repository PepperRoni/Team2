using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(TreeFollower))]
public class PlayerController : MonoBehaviour
{
    public bool inGoalArea;
    public int collectedItems;

    [SerializeField] float jumpForce = 20;  
    [SerializeField] float maxJumpTime;
    [SerializeField] TextMeshProUGUI getMoreCollectables;

    bool inInteract;
    float jumpTime;
    [SerializeField] bool grounded;
    Animator animator;

    private Vector3 startPosition;
    private Rigidbody rb;
    private TreeFollower treeFollower;

    [SerializeField] LayerMask floor;
    private bool jumping;
    SpriteRenderer spriteRenderer;
    private bool isWalking;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        jumpTime = maxJumpTime;
        inGoalArea = false;
        rb = GetComponent<Rigidbody>();
        treeFollower = GetComponent<TreeFollower>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Respawn();
        }

        if (Math.Abs(rb.velocity.y) < 0.1)
            animator.SetFloat("Velocity", 0);
        else
            animator.SetFloat("Velocity", rb.velocity.y);
    }
    void FixedUpdate()
    {
        Jump();
        if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.flipX = false;
            treeFollower.Left(0.2f);
            //if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
            //{
            //    treeFollower.Left(0.21f);
            //}
        }

        if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.flipX = true;

            treeFollower.Right(0.2f);
            //if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
            //{
            //    treeFollower.Right(0.21f);
            //}
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            animator.SetBool("IsWalking", true);
        else
            animator.SetBool("IsWalking", false);
    }

    void Respawn()
    {
            string thisScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(thisScene);
    }

    void Jump()
    {

        if (grounded && Input.GetKey(KeyCode.Space))
        {
            jumping = true;
            grounded = false;
            jumpTime = 0;         
        }

        if(jumping)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            jumpTime += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space) | jumpTime > maxJumpTime)
        {
            jumping = false;
            Physics.gravity = new Vector3(0, -50f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Goal"))
        {
            inGoalArea = true;
            if(inGoalArea && collectedItems == 4)
            {
                print("Woooooooo you have collected all four items!!!!!!!!!!!!!!!");
                //TODO: Play win cut scene 
            }
            else
            {

                getMoreCollectables.text = "You need to get all the collectables!";
            }
        }

        if (other.GetComponent<IInteractable>() != null)
        {
            inInteract = true;
            if (inInteract)
            {
                IInteractable _interactable = other.GetComponent<IInteractable>();
                _interactable.Interact(this);
                inInteract = false;
            }
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Floor"))
            grounded = true;
        else
            grounded = false;
    }
}