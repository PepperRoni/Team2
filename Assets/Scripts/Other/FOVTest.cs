using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVTest : MonoBehaviour
{
    [Header("Enviorment")]
    [SerializeField] private Transform rotationParent;

    [Header("Settings")]
    [SerializeField] private float distanceFromParent;
    [SerializeField] private float angle;

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
            angle++;
        if (Input.GetKey(KeyCode.Q))
            angle--;

        UpdateTarget();
    }

    Vector3 CalculatePosition()
    {

        Vector3 myPosition = this.transform.forward;

        this.transform.rotation = Quaternion.Euler(0, angle, 0);

        myPosition.x = myPosition.x * distanceFromParent;
        //myPosition.y = myPosition.y * distanceFromParent;
        myPosition.z = myPosition.z * distanceFromParent;

        return rotationParent.position + myPosition;
    }


    void UpdateTarget()
    {
        this.transform.position = CalculatePosition();
    }
}
