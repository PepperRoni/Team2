using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float thrust = 100;
    [SerializeField] float timeInAir;
    [SerializeField] float maxJumpTime;
    [SerializeField] float distanceToGround;
    [SerializeField] bool isGrounded;
    [SerializeField] bool isJumping;

    private Vector3 startPosition;
    private Rigidbody rb;
    [SerializeField] LayerMask floor;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        distanceToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void Update()
    {
        Respawn();
    }
    void FixedUpdate()
    {
        Jump();
    }

    void Respawn()
    {
        Camera.main.transform.position =
        new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        if (transform.position.y <= startPosition.y - 15)
        {
            string thisScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(thisScene);
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && timeInAir <= maxJumpTime)
        {
            rb.AddForce(Vector2.up * thrust);
            isJumping = true;
        }

        if (rb.velocity.y < -0.1f || timeInAir >= maxJumpTime)
        {
            Physics.gravity = new Vector3(0, -25f, 0);
        }

        if (!Physics.Raycast(transform.position, Vector3.down, distanceToGround + 1f, floor))
        {
            isGrounded = false;
            timeInAir += Time.deltaTime;
        }
        else
        {
            isGrounded = true;
            timeInAir = 0;
        }

        if (timeInAir > 2f)
        {
            ResetJump();
        }

    }
    void ResetJump()
    {
        Physics.gravity = new Vector3(0, -9f, 0);
        isJumping = false;
        timeInAir = 0;
    }
}
