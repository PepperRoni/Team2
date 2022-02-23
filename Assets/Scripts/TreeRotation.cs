using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0.0f, Input.GetAxis("Horizontal") * rotationSpeed, 0.0f);
    }
}