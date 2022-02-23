using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class PlayerController : MonoBehaviour
{
    public float thrust = 100;
    public float timeInAir;
    public float distanceToGround;
    public bool isGrounded;

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
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * thrust);
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

    }
    
}
